
# Secure Login and Registration System - Feature Report

This report summarizes the key features of the provided C# WinForms application, which implements a secure login and registration system.

## Table of Contents

1.  [User Registration](#user-registration)
2.  [User Login](#user-login)
3.  [Data Input (After Successful Login)](#data-input)
4.  [Input Validation](#input-validation)
5.  [Password Hashing and Salting](#password-hashing-and-salting)

## 1. User Registration

**Description:** Allows new users to create accounts by providing a username and password.  The system securely hashes and salts the password before storing it in the database.

**Screenshot:**

![Registration Form](https://github.com/user-attachments/assets/61938aac-d27f-4ad8-ab23-24b0944cad84)
*Form2: Registration Page*

**Code Snippet (Form2.cs - `registerButton_Click`):**

```csharp
private void registerButton_Click(object sender, EventArgs e)
{
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO tbl_login (Username, PasswordHash, Salt, Role) VALUES (@Username, @PasswordHash, @Salt, @Role)"; //Added Role
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                byte[] salt = Hashing.GenerateSalt(); // Generate a unique salt

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                // Hash the password with the salt
                cmd.Parameters.AddWithValue("@PasswordHash", Hashing.GenerateSha256Hash(passwordBox.Text, salt));
                cmd.Parameters.AddWithValue("@Salt", salt); // Store the salt
                cmd.Parameters.AddWithValue("@Role", roleComboBox.Text);  //Added Role.
                using (SqlDataAdapter sda = new SqlDataAdapter())  //Best practice to use DataAdapter
                {
                    sda.InsertCommand = cmd;  //Set the insert command.
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
```

**Key Points:**

*   Uses a `SqlConnection` to connect to the database.
*   Uses parameterized SQL queries (`@Username`, `@PasswordHash`, `@Salt`) to prevent SQL injection vulnerabilities.
*   Calls `Hashing.GenerateSalt()` to create a unique salt for each user.
*   Calls `Hashing.GenerateSha256Hash()` to hash the password with the salt.
*   Stores the username, *hashed* password, and salt in the `tbl_login` table.
*   Includes error handling (`try-catch`) for database operations.
*   **Added Role** Includes Role comboBox selection.

## 2. User Login

**Description:** Allows registered users to log in by providing their username and password.  The system retrieves the stored salt, re-hashes the entered password, and compares it to the stored hash.

**Screenshot:**

![Login Form](https://github.com/user-attachments/assets/f1eba32d-3cb4-4aad-bf42-aea570b61ed0)
*Form1: Login Form*

**Code Snippet (Form1.cs - `loginButton_Click`):**

```csharp
private void loginButton_Click(object sender, EventArgs e)
{
    if (attempts == 3)
    {
        MessageBox.Show("Too Many Attempts! Please wait for 2m");
        Thread.Sleep(120000); // Corrected sleep time to 2 minutes (120000 ms)
        attempts = 0; // Reset attempts after the wait
        return;
    }
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT Salt, PasswordHash FROM tbl_login WHERE Username = @Username AND Role = @Role"; //Added Role.
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 255).Value = usernameBox.Text;
                cmd.Parameters.AddWithValue("@Role", roleComboBox.Text); //Added Role
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
                            Form3 form3 = new Form3(); // Example: Navigate to Form3 on success
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
        attempts++; // Increment attempts even on exceptions
    }
    Clear();
}
```

**Key Points:**

*   Retrieves the stored salt and hashed password from the database based on the entered username.
*   Re-hashes the entered password using the retrieved salt.
*   Uses `CryptographicOperations.FixedTimeEquals()` for a constant-time comparison of the stored hash and the newly generated hash (prevents timing attacks).
*   Implements a login attempt limit (3 attempts) with a lockout (2 minutes).
*  **Added Role** The login now also check for the user role using a combobox.

## 3. Data Input (After Successful Login)

**Description:** After successful login, the user is presented with a form to enter additional personal information (Name, Age, Email, Phone).

**Screenshot:**

![Data Input Form](https://github.com/user-attachments/assets/23ebdd11-2d09-47a8-9267-e9cbfa618902)
*Form3: Data Input Form*

**Code Snippet (Form3.cs - `submitButton_Click`):**

```csharp
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
                cmd.Parameters.AddWithValue("@Age", ageBox.Text); // Storing as string; consider int
                cmd.Parameters.AddWithValue("@Email", emailBox.Text);
                cmd.Parameters.AddWithValue("@Phone", phoneBox.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.InsertCommand = cmd;
                    sda.InsertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("User registered successfully!"); // Message should say "Data saved"
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Couldn't register user: " + ex.Message); // More descriptive error message
    }
    Clear();
}
```

**Key Points:**

*   This form is displayed *after* successful login.
*   Collects additional user data (Name, Age, Email, Phone).
*   Uses parameterized SQL queries to insert the data into the `tbl_data_insert` table.
* **Improvement:** The "Age" should ideally be stored as an integer (`INT`) in the database, not as a string.  The code could be improved by parsing the `ageBox.Text` to an integer *before* inserting it.

## 4. Input Validation

**Description:** The application validates user input on both the registration and login forms, as well as Form 3, providing real-time feedback (changing the background color of textboxes).

**Code Snippet (Validation.cs):**

```csharp
internal class Validation
{
    // ... (other validation methods) ...

    public static bool ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password)) return false;

        bool hasUppercase = false;
        bool hasLowercase = false;
        bool hasDigit = false;
        bool hasSpecialChar = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUppercase = true;
            else if (char.IsLower(c)) hasLowercase = true;
            else if (char.IsDigit(c)) hasDigit = true;
            else if (!char.IsLetterOrDigit(c)) hasSpecialChar = true;
        }

        return hasUppercase && hasLowercase && hasDigit && hasSpecialChar && password.Length >= 8;
    }

    public static bool ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return false;
        foreach (char c in username) { if (!char.IsLetterOrDigit(c)) return false; }
        return true;
    }
     public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            int atIndex = email.IndexOf('@');
            if (atIndex <= 0 || atIndex >= email.Length - 1) return false;

            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);

            if (string.IsNullOrEmpty(localPart) || localPart.Length > 64) return false;
            if (string.IsNullOrEmpty(domainPart) || domainPart.Length > 255) return false;
            if (localPart.Contains("..") || domainPart.Contains("..")) return false;
            if (localPart.StartsWith(".") || localPart.EndsWith(".")) return false;
            if (domainPart.StartsWith(".") || domainPart.EndsWith(".")) return false;
            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-' && c != '+') return false;
            }

            int dotIndex = domainPart.IndexOf('.');
            if (dotIndex <= 0 || dotIndex >= domainPart.Length - 1) return false;

            foreach (char c in domainPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '-') return false;
            }

            return true;
        }

        public static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return phone.Length >= 10 && phone.Length <= 15;
        }

        public static bool ValidateAge(int age)
        {
            return age >= 18 && age <= 100;
        }
}
```

**Key Points:**

*   **`Validation` Class:**  Contains static methods for validating different input fields.
*   **`ValidatePassword`:** Checks for minimum length, uppercase, lowercase, digit, and special character.
*   **`ValidateUsername`:** Checks that the username contains only alphanumeric characters.
*   **Real-time Feedback:** The `TextChanged` events of the textboxes call the validation methods and change the background color to green (valid) or crimson (invalid).
*  **Added Validation** The code now includes validation methods for name, email, phone number and age.

## 5. Password Hashing and Salting

**Description:**  The application uses SHA-256 hashing with a unique, randomly generated salt for each user to securely store passwords.

**Code Snippet (Hashing.cs):**

```csharp
internal class Hashing
{
    public static byte[] GenerateSalt()
    {
        const int saltSize = 64;
        byte[] salt = new byte[saltSize];
        using (var rng = RandomNumberGenerator.Create()) // Use 'using' for proper disposal
        {
           rng.GetBytes(salt);
        }
        return salt;
    }

    public static byte[] GenerateSha256Hash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];
        Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
        Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);
         using (SHA256 sha256 = SHA256.Create())  //Use using for the hashing algorithm
         {
            return sha256.ComputeHash(saltedPassword);
         }
    }
}
```

**Key Points:**

*   **`GenerateSalt()`:**  Generates a 64-byte cryptographically secure random salt using `RandomNumberGenerator`.
*   **`GenerateSha256Hash()`:**
    *   Combines the password and salt using `Buffer.BlockCopy`.
    *   Hashes the combined data using `SHA256.HashData`.
    *   Returns the hash as a `byte[]`.
*   **Best Practices:**  Uses industry-standard best practices for password hashing:
    *   SHA-256 hashing algorithm.
    *   Unique salt per user.
    *   Cryptographically secure random number generator.

