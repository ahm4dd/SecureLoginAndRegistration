using System.Data;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System.Threading;

namespace SecureLoginAndRegistration
{
    public partial class Form1 : Form
    {
        bool isUsernameValid = false;
        bool isPasswordValid = false;
        int attempts = 0;

        const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\range\\source\\repos\\SecureLoginAndRegistration\\SecureLoginAndRegistration\\Database1.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
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
            if (isPasswordValid && isUsernameValid) { loginButton.Enabled = true; }
            else { loginButton.Enabled = false; }
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
            if (isUsernameValid && isPasswordValid) { loginButton.Enabled = true; }
            else { loginButton.Enabled = false; }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (attempts == 3)
            {
                MessageBox.Show("Too Many Attempts! Please wait for 2m");
                Thread.Sleep(1000);
                attempts--;
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Salt, PasswordHash FROM tbl_login WHERE Username = @Username AND Role = @Role";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.VarChar, 255).Value = usernameBox.Text;
                        cmd.Parameters.AddWithValue("@Role", roleComboBox.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] storedSalt = (byte[])reader["Salt"];
                                byte[] storedHash = (byte[])reader["PasswordHash"];

                                byte[] enteredHash = Hashing.GenerateSha256Hash(passwordBox.Text, storedSalt);

                                if (CryptographicOperations.FixedTimeEquals(storedHash, enteredHash))
                                {
                                    MessageBox.Show("Login successful!");
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password.");
                                    attempts++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("User not found.");
                                attempts++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
                attempts++;
            }
            Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            usernameBox.Clear();
            passwordBox.Clear();
        }
    }
}

