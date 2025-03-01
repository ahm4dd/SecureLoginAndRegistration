namespace SecureLoginAndRegistration
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            loginFormButton = new Button();
            registerButton = new Button();
            passwordBox = new TextBox();
            usernameBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 298);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(44, 199);
            label1.Name = "label1";
            label1.Size = new Size(210, 41);
            label1.TabIndex = 1;
            label1.Text = "Register Page";
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
            // 
            // loginFormButton
            // 
            loginFormButton.BackColor = Color.DarkSlateGray;
            loginFormButton.FlatStyle = FlatStyle.Flat;
            loginFormButton.ForeColor = Color.Black;
            loginFormButton.Location = new Point(530, 231);
            loginFormButton.Name = "loginFormButton";
            loginFormButton.Size = new Size(96, 40);
            loginFormButton.TabIndex = 15;
            loginFormButton.Text = "Login";
            toolTip4.SetToolTip(loginFormButton, "Switch to the login form");
            loginFormButton.UseVisualStyleBackColor = false;
            loginFormButton.Click += loginFormButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.RoyalBlue;
            registerButton.Enabled = false;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Location = new Point(321, 232);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(142, 39);
            registerButton.TabIndex = 14;
            registerButton.Text = "Register";
            toolTip3.SetToolTip(registerButton, "Register the data and make an account");
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // passwordBox
            // 
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.Location = new Point(321, 177);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.PlaceholderText = "E.g Ahmed12!";
            passwordBox.Size = new Size(305, 27);
            passwordBox.TabIndex = 13;
            toolTip2.SetToolTip(passwordBox, "A minimum of 8 characters with at least one uppercase, one number, and one special character.");
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // usernameBox
            // 
            usernameBox.BorderStyle = BorderStyle.FixedSingle;
            usernameBox.Location = new Point(321, 110);
            usernameBox.Name = "usernameBox";
            usernameBox.PlaceholderText = "E.g ahm4dd";
            usernameBox.Size = new Size(305, 27);
            usernameBox.TabIndex = 12;
            toolTip1.SetToolTip(usernameBox, "Accepts alphanumeric values only (Only digits and numbers).");
            usernameBox.TextChanged += usernameBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(321, 154);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 11;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(318, 87);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 10;
            label3.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(321, 40);
            label2.Name = "label2";
            label2.Size = new Size(305, 25);
            label2.TabIndex = 9;
            label2.Text = "ENTER YOUR INFORMATION";
            label2.Click += label2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(653, 298);
            Controls.Add(panel1);
            Controls.Add(loginFormButton);
            Controls.Add(registerButton);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button loginFormButton;
        private Button registerButton;
        private TextBox passwordBox;
        private TextBox usernameBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
    }
}