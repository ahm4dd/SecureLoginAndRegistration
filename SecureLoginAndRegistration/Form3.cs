using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SecureLoginAndRegistration
{
    public partial class Form3 : Form
    {
        const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\range\\source\\repos\\SecureLoginAndRegistration\\SecureLoginAndRegistration\\Database1.mdf;Integrated Security=True";
        bool isNameValid = false;
        bool isAgeValid = false;
        bool isEmailValid = false;
        bool isPhoneValid = false;


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_data_insert (Name, Age, Email, Phone) VALUES (@Name, @Age, @Email, @Phone)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", nameBox.Text);
                        cmd.Parameters.AddWithValue("@Age", ageBox.Text);
                        cmd.Parameters.AddWithValue("@Email", emailBox.Text);
                        cmd.Parameters.AddWithValue("@Phone", phoneBox.Text);
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

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation.ValidateName(nameBox.Text))
            {
                nameBox.BackColor = Color.Green;
                isNameValid = true;

            }
            else
            {
                nameBox.BackColor = Color.Crimson;
                isNameValid = false;
            }
            if (isAgeValid && isEmailValid && isPhoneValid && isNameValid) { submitButton.Enabled = true; submitButton.BackColor = Color.Green; }
            else { submitButton.Enabled = false; submitButton.BackColor = Color.Crimson; }
        }

        private void ageBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Validation.ValidateAge(int.Parse(ageBox.Text)))
                {
                    ageBox.BackColor = Color.Green;
                    isAgeValid = true;
                }
                else
                {
                    ageBox.BackColor = Color.Crimson;
                    isAgeValid = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (isAgeValid && isEmailValid && isPhoneValid && isNameValid) { submitButton.Enabled = true; submitButton.BackColor = Color.Green; }
            else { submitButton.Enabled = false; submitButton.BackColor = Color.Crimson; }
        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation.ValidateEmail(emailBox.Text))
            {
                emailBox.BackColor = Color.Green;
                isEmailValid = true;
            }
            else
            {
                emailBox.BackColor = Color.Crimson;
                isEmailValid = false;
            }
            if (isAgeValid && isEmailValid && isPhoneValid && isNameValid) { submitButton.Enabled = true; submitButton.BackColor = Color.Green; }
            else { submitButton.Enabled = false; submitButton.BackColor = Color.Crimson; }
        }

        private void phoneBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation.ValidatePhone(phoneBox.Text))
            {
                phoneBox.BackColor = Color.Green;
                isPhoneValid = true;
            }
            else
            {
                phoneBox.BackColor = Color.Crimson;
                isPhoneValid = false;
            }
            if (isAgeValid && isEmailValid && isPhoneValid && isNameValid) { submitButton.Enabled = true; submitButton.BackColor = Color.Green; }
            else { submitButton.Enabled = false; submitButton.BackColor = Color.Crimson; }
        }

        private void Clear()
        {
            nameBox.Clear();
            ageBox.Clear();
            emailBox.Clear();
            phoneBox.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
