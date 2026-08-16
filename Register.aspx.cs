using System;
using System.Configuration;
using System.Data.SqlClient; // Driver resmi untuk SQL Server

namespace InventoryWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        private string GetConnectionString()
        {
            var connStr = ConfigurationManager.ConnectionStrings["DbConn"];
            if (connStr != null && !string.IsNullOrEmpty(connStr.ConnectionString))
            {
                return connStr.ConnectionString;
            }
            throw new Exception("Connection String 'DbConn' tidak ditemukan di Web.config!");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string role = ddlRole.SelectedValue;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowAlert("danger", "Username dan Password tidak boleh kosong!");
                return;
            }

            if (password != confirmPassword)
            {
                ShowAlert("danger", "Konfirmasi password tidak cocok!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    // 1. Cek apakah username sudah pernah terdaftar
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            ShowAlert("danger", "Username sudah terdaftar! Gunakan username lain.");
                            return;
                        }
                    }

                    // 2. Simpan user baru ke tabel Users
                    string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Role", role);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                ShowAlert("success", "Registrasi berhasil! Silakan login.");
                ClearForm();
            }
            catch (Exception ex)
            {
                ShowAlert("danger", "Terjadi kesalahan: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            ddlRole.SelectedIndex = 0;
        }

        private void ShowAlert(string type, string message)
        {
            pnlAlert.Visible = true;
            pnlAlert.CssClass = "alert alert-" + type;
            lblMessage.Text = message;
        }
    }
}