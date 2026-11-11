using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GasRight
{
    public partial class Form1 : Form
    {
        private string cs = @"Server=TURBO\SQLEXPRESS;Database=GasRightDB;User Id=sa;Password=123;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Make sure to fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string inputEmail = txtEmail.Text.Trim();
            string inputPassword = txtPass.Text.Trim();

            User foundUser = AuthenticateUser(inputEmail, inputPassword);

            if (foundUser != null)
            {
                MessageBox.Show($"Login successful! Welcome, {foundUser.Role}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                if (foundUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    Admin adminDashboard = new Admin();
                    adminDashboard.Show();
                }
                else
                {
                    Dashboard attendantDashboard = new Dashboard();
                    attendantDashboard.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid Email or Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private User AuthenticateUser(string email, string password)
        {

            string query = "SELECT Email, Role " +
                           "FROM Users " +
                           "WHERE LOWER(Email) = LOWER(@e) AND Password = @p";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", password);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Email = reader["Email"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void password_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }

    public class User
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }
}