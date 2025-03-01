using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SecureLoginAndRegistration
{
    public partial class Form2 : Form
    {
        bool isUsernameValid = false;
        bool isPasswordValid = false;

        const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\range\\source\\repos\\SecureLoginAndRegistration\\SecureLoginAndRegistration\\Database1.mdf;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation.ValidateUsername(usernameBox.Text))
            {
                usernameBox.BackColor = Color.Green;
                isUsernameValid = true;
                
            }
            else
            {
                usernameBox.BackColor = Color.Crimson;
                isUsernameValid = false;
            }
            if (isPasswordValid && isUsernameValid) { registerButton.Enabled = true; }
            else { registerButton.Enabled = false; }
        }


        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation.ValidatePassword(passwordBox.Text))
            {
                passwordBox.BackColor = Color.Green;
                isPasswordValid = true;
                
            }
            else
            {
                passwordBox.BackColor = Color.Crimson;
                isPasswordValid = false;
            }
            if (isUsernameValid && isPasswordValid) { registerButton.Enabled = true; }
            else { registerButton.Enabled = false; }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_login (Username, PasswordHash, Salt) VALUES (@Username, @PasswordHash, @Salt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        Byte[] salt = Hashing.GenerateSalt();

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                        cmd.Parameters.AddWithValue("@PasswordHash", Hashing.GenerateSha256Hash(passwordBox.Text, salt));
                        cmd.Parameters.AddWithValue("@Salt", salt);
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.ExecuteNonQuery();
                        }
                        MessageBox.Show("User registered successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't register user: " + ex.Message);
            }
            Clear();
        }

        private void loginFormButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            usernameBox.Clear();
            passwordBox.Clear();
        }
    }
}
