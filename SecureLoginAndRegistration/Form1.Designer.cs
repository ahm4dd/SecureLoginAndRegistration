namespace SecureLoginAndRegistration
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            roleComboBox = new ComboBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            registerFormButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            loginButton = new Button();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(roleComboBox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 298);
            panel1.TabIndex = 0;
            // 
            // roleComboBox
            // 
            roleComboBox.Cursor = Cursors.Hand;
            roleComboBox.FlatStyle = FlatStyle.Flat;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Admin", "Member" });
            roleComboBox.Location = new Point(67, 242);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(153, 28);
            roleComboBox.Sorted = true;
            roleComboBox.TabIndex = 8;
            roleComboBox.Text = "Select Role";
            toolTip5.SetToolTip(roleComboBox, "A combox for selecting the user's role");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(58, 194);
            label1.Name = "label1";
            label1.Size = new Size(173, 41);
            label1.TabIndex = 1;
            label1.Text = "Login Page";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login;
            pictureBox1.Location = new Point(67, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 158);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // registerFormButton
            // 
            registerFormButton.BackColor = Color.DarkSlateGray;
            registerFormButton.FlatStyle = FlatStyle.Flat;
            registerFormButton.ForeColor = Color.Black;
            registerFormButton.Location = new Point(526, 230);
            registerFormButton.Name = "registerFormButton";
            registerFormButton.Size = new Size(96, 40);
            registerFormButton.TabIndex = 7;
            registerFormButton.Text = "Register";
            toolTip4.SetToolTip(registerFormButton, "Switch to the registration form.");
            registerFormButton.UseVisualStyleBackColor = false;
            registerFormButton.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(317, 43);
            label2.Name = "label2";
            label2.Size = new Size(305, 25);
            label2.TabIndex = 1;
            label2.Text = "ENTER YOUR INFORMATION";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(317, 87);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 2;
            label3.Text = "Username:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(317, 154);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 3;
            label4.Text = "Password:";
            // 
            // usernameBox
            // 
            usernameBox.BorderStyle = BorderStyle.FixedSingle;
            usernameBox.Location = new Point(317, 110);
            usernameBox.Name = "usernameBox";
            usernameBox.PlaceholderText = "E.g ahm4dd";
            usernameBox.Size = new Size(305, 27);
            usernameBox.TabIndex = 4;
            toolTip1.SetToolTip(usernameBox, "Accepts alphanumeric values only (Only digits and numbers).");
            usernameBox.TextChanged += usernameBox_TextChanged;
            // 
            // passwordBox
            // 
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.Location = new Point(317, 177);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.PlaceholderText = "E.g Ahmed12!";
            passwordBox.Size = new Size(305, 27);
            passwordBox.TabIndex = 5;
            toolTip2.SetToolTip(passwordBox, "A minimum of 8 characters with at least one uppercase, one number, and one special character.");
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.RoyalBlue;
            loginButton.Enabled = false;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Location = new Point(317, 230);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(142, 39);
            loginButton.TabIndex = 6;
            loginButton.Text = "Login";
            toolTip3.SetToolTip(loginButton, "Login with the data you have entered in the input fields.");
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(653, 298);
            Controls.Add(registerFormButton);
            Controls.Add(loginButton);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox usernameBox;
        private TextBox passwordBox;
        private Button loginButton;
        private Button registerFormButton;
        private ComboBox roleComboBox;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
    }
}
