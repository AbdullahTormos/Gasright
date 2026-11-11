using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GasRight
{
    public partial class Admin : Form
    {
        private readonly string cs = @"Server=TURBO\SQLEXPRESS;Database=GasRightDB;User Id=sa;Password=123;TrustServerCertificate=True;";

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadProfessionsIntoComboBoxes();
            RefreshVehicleGrid();
            RefreshProfessionsGrid();
        }

        private List<Profession> GetProfessionsFromDB()
        {
            List<Profession> list = new List<Profession>();
            string query = "SELECT ProfessionID, Title, WeeklyLimitLiters FROM Professions";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Profession
                        {
                            ProfessionID = Convert.ToInt32(reader["ProfessionID"]),
                            Title = reader["Title"].ToString(),
                            WeeklyLimitLiters = Convert.ToInt32(reader["WeeklyLimitLiters"])
                        });
                    }
                }
            }

            return list;
        }

        private void LoadProfessionsIntoComboBoxes()
        {
            List<Profession> professionsList = GetProfessionsFromDB();


            cmbProfession.DataSource = null;
            cmbProfession.DisplayMember = "Title";
            cmbProfession.ValueMember = "ProfessionID";
            cmbProfession.DataSource = new List<Profession>(professionsList);
            cmbProfession.SelectedIndex = -1;

            cmbProfession2.DataSource = null;
            cmbProfession2.DisplayMember = "Title";
            cmbProfession2.ValueMember = "ProfessionID";
            cmbProfession2.DataSource = new List<Profession>(professionsList);
            cmbProfession2.SelectedIndex = -1;
        }

        private void RefreshVehicleGrid()
        {
            string query = @"
                SELECT 
                    v.VIN, 
                    v.OwnerName, 
                    ISNULL(p.Title, 'Unknown') AS Profession, 
                    ISNULL(p.WeeklyLimitLiters, 0) AS LimitLiters
                FROM Vehicles v
                LEFT JOIN Professions p ON v.ProfessionID = p.ProfessionID";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvVehicles.DataSource = null;
                dgvVehicles.DataSource = dt;
            }
        }

        private void RefreshProfessionsGrid()
        {
            string query = "SELECT Title AS Profession, WeeklyLimitLiters AS LimitLiters FROM Professions";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProfessions.DataSource = null;                dgvProfessions.DataSource = dt;
            }
        }



        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVIN.Text) || string.IsNullOrWhiteSpace(txtOwnerName.Text) || cmbProfession.SelectedValue == null)
            {
                MessageBox.Show("Please complete all registration fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newVIN = txtVIN.Text.Trim();

            // Duplicate VIN Check in SQL
            if (IsVinExists(newVIN))
            {
                MessageBox.Show("A vehicle with this VIN already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedProfessionId = Convert.ToInt32(cmbProfession.SelectedValue);
            string insertQuery = "INSERT INTO Vehicles (VIN, OwnerName, ProfessionID) VALUES (@VIN, @OwnerName, @ProfessionID)";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", newVIN);
                cmd.Parameters.AddWithValue("@OwnerName", txtOwnerName.Text.Trim());
                cmd.Parameters.AddWithValue("@ProfessionID", selectedProfessionId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Vehicle registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshVehicleGrid();
            ClearInputs();
        }

        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            string vinToDelete = "";

            if (dgvVehicles.CurrentRow != null && dgvVehicles.CurrentRow.Cells["VIN"]?.Value != null)
            {
                vinToDelete = dgvVehicles.CurrentRow.Cells["VIN"].Value.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(txtVIN.Text))
            {
                vinToDelete = txtVIN.Text.Trim();
            }

            if (string.IsNullOrEmpty(vinToDelete))
            {
                MessageBox.Show("Please select a vehicle row from the grid or enter a VIN to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deleteQuery = "DELETE FROM Vehicles WHERE VIN = @VIN";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", vinToDelete);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Vehicle record ({vinToDelete}) removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshVehicleGrid();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("No vehicle found matching that VIN.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool IsVinExists(string vin)
        {
            string query = "SELECT COUNT(1) FROM Vehicles WHERE VIN = @VIN";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VIN", vin);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private void ClearInputs()
        {
            txtVIN.Clear();
            txtOwnerName.Clear();
            cmbProfession.SelectedIndex = -1;
        }

        private void cmbProfession2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProfession2.SelectedItem is Profession selectedProf)
            {
                numFuelLimit.Value = selectedProf.WeeklyLimitLiters;

                foreach (DataGridViewRow row in dgvProfessions.Rows)
                {
                    if (row.Cells["Profession"]?.Value?.ToString() == selectedProf.Title)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbProfession2.SelectedItem is Profession selectedProf)
            {
                int newLimit = (int)numFuelLimit.Value;
                string updateQuery = "UPDATE Professions SET WeeklyLimitLiters = @Limit WHERE ProfessionID = @ID";

                using (SqlConnection conn = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Limit", newLimit);
                    cmd.Parameters.AddWithValue("@ID", selectedProf.ProfessionID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Fuel allocation rule updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh UI components
                RefreshProfessionsGrid();
                RefreshVehicleGrid();
                LoadProfessionsIntoComboBoxes();

                cmbProfession2.SelectedIndex = -1;
                numFuelLimit.Value = 0;
            }
            else
            {
                MessageBox.Show("Please select a profession from the dropdown first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void dvgVehilcles_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void VehicleManagement_Click(object sender, EventArgs e) { }
        private void txtProfessionTitle_TextChanged(object sender, EventArgs e) { }
        private void dgvProfessions_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dgvProfessions_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class Profession
    {
        public int ProfessionID { get; set; }
        public string Title { get; set; }
        public int WeeklyLimitLiters { get; set; }
    }
}