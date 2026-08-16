using System;
using System.Configuration;
using System.Data.SqlClient;

namespace InventoryWebApp
{
    public partial class Login : System.Web.UI.Page
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                pnlAlert.Visible = true;
                lblMessage.Text = "Username dan Password wajib diisi!";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = "SELECT Id, Username, Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Simpan session user
                                Session["UserId"] = reader["Id"].ToString();
                                Session["Username"] = reader["Username"].ToString();
                                Session["Role"] = reader["Role"].ToString();

                                // Redirect ke halaman utama / DataBarang
                                Response.Redirect("DataBarang.aspx");
                            }
                            else
                            {
                                pnlAlert.Visible = true;
                                lblMessage.Text = "Username atau Password salah!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pnlAlert.Visible = true;
                lblMessage.Text = "Terjadi kesalahan: " + ex.Message;
            }
        }
    }
}