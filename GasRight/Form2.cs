
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GasRight
{
    public partial class Dashboard : Form
    {
        private string cs = @"Server=TURBO\SQLEXPRESS;Database=GasRightDB;User Id=sa;Password=123;TrustServerCertificate=True;";

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string inputVIN = txtVIN.Text.Trim();

            if (string.IsNullOrEmpty(inputVIN))
            {
                txtResult.Text = "Please enter a valid VIN number.";
                return;
            }

            string vehicleQuery = @"
                SELECT 
                    v.OwnerName, 
                    ISNULL(p.Title, 'Unknown') AS Title, 
                    ISNULL(p.WeeklyLimitLiters, 0) AS WeeklyLimitLiters
                FROM Vehicles v
                LEFT JOIN Professions p ON v.ProfessionID = p.ProfessionID
                WHERE v.VIN = @VIN";

            string ownerName = "";
            string professionTitle = "";
            int weeklyLimit = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(vehicleQuery, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", inputVIN);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ownerName = reader["OwnerName"].ToString();
                        professionTitle = reader["Title"].ToString();
                        weeklyLimit = Convert.ToInt32(reader["WeeklyLimitLiters"]);
                    }
                    else
                    {
                        txtResult.Text = "Vehicle VIN not found in the system.";
                        return;
                    }
                }
            }

            int usedLiters = GetUsedLitersInLast7Days(inputVIN);
            int remainingLiters = weeklyLimit - usedLiters;
            string lastFillText = GetLastFillDate(inputVIN);

            txtResult.Text = $"Owner Name: {ownerName}" + Environment.NewLine +
                             $"Profession: {professionTitle}" + Environment.NewLine +
                             $"Weekly Limit: {weeklyLimit} Liters" + Environment.NewLine +
                             $"Date of Last Fill: {lastFillText}" + Environment.NewLine +
                             $"Remaining Allowance: {remainingLiters} Liters";
        }

        private void btnFillGas_Click(object sender, EventArgs e)
        {
            string inputVIN = txtVIN.Text.Trim();
            int litersToFill = (int)numLitersToFill.Value;

            if (string.IsNullOrEmpty(inputVIN))
            {
                MessageBox.Show("Please search for a vehicle VIN first.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (litersToFill <= 0)
            {
                MessageBox.Show("Please enter a valid amount of liters to fill.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vehicleQuery = @"
                SELECT ISNULL(p.WeeklyLimitLiters, 0) AS WeeklyLimitLiters
                FROM Vehicles v
                INNER JOIN Professions p ON v.ProfessionID = p.ProfessionID
                WHERE v.VIN = @VIN";

            int weeklyLimit = -1;

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(vehicleQuery, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", inputVIN);
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    weeklyLimit = Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Vehicle VIN not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int usedLiters = GetUsedLitersInLast7Days(inputVIN);
            int remainingLiters = weeklyLimit - usedLiters;

            if (litersToFill > remainingLiters)
            {
                MessageBox.Show($"Cannot fill {litersToFill} Liters! Vehicle only has {remainingLiters} Liters remaining in allowance.", "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string insertTransactionQuery = "INSERT INTO FuelTransactions (VIN, LitersFilled, FillDate) VALUES (@VIN, @Liters, @FillDate)";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(insertTransactionQuery, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", inputVIN);
                cmd.Parameters.AddWithValue("@Liters", litersToFill);
                cmd.Parameters.AddWithValue("@FillDate", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show($"Successfully filled {litersToFill} Liters!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            numLitersToFill.Value = 0;
            btnSearch_Click(sender, e);
        }


        private int GetUsedLitersInLast7Days(string vin)
        {
            string query = @"
                SELECT ISNULL(SUM(LitersFilled), 0) 
                FROM FuelTransactions 
                WHERE VIN = @VIN AND FillDate >= DATEADD(day, -7, GETDATE())";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", vin);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private string GetLastFillDate(string vin)
        {
            string query = "SELECT TOP 1 FillDate FROM FuelTransactions WHERE VIN = @VIN ORDER BY FillDate DESC";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", vin);
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDateTime(result).ToString("yyyy-MM-dd HH:mm");
                }
            }

            return "Never";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e) { }
        private void txtVIN_TextChanged(object sender, EventArgs e) { }
        private void txtResult_TextChanged(object sender, EventArgs e) { }
        private void numLitersToFill_ValueChanged(object sender, EventArgs e) { }
    }
}