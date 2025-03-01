namespace SecureLoginAndRegistration
{
    partial class Form3
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
            nameLabel = new Label();
            nameBox = new TextBox();
            ageBox = new TextBox();
            label2 = new Label();
            emailBox = new TextBox();
            label3 = new Label();
            phoneBox = new TextBox();
            label4 = new Label();
            submitButton = new Button();
            clearButton = new Button();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            toolTip6 = new ToolTip(components);
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.FlatStyle = FlatStyle.Flat;
            nameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.ForeColor = SystemColors.ButtonHighlight;
            nameLabel.Location = new Point(80, 56);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(83, 31);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // nameBox
            // 
            nameBox.BorderStyle = BorderStyle.FixedSingle;
            nameBox.Location = new Point(185, 56);
            nameBox.Multiline = true;
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Enter your name";
            nameBox.Size = new Size(360, 34);
            nameBox.TabIndex = 1;
            toolTip1.SetToolTip(nameBox, "Name: Only letters (No numbers or special characters).");
            nameBox.TextChanged += nameBox_TextChanged;
            // 
            // ageBox
            // 
            ageBox.BorderStyle = BorderStyle.FixedSingle;
            ageBox.Location = new Point(185, 111);
            ageBox.Multiline = true;
            ageBox.Name = "ageBox";
            ageBox.PlaceholderText = "Enter your age";
            ageBox.Size = new Size(360, 34);
            ageBox.TabIndex = 3;
            toolTip2.SetToolTip(ageBox, "Age: Only numbers (18-100 range).");
            ageBox.TextChanged += ageBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(80, 111);
            label2.Name = "label2";
            label2.Size = new Size(62, 31);
            label2.TabIndex = 2;
            label2.Text = "Age:";
            // 
            // emailBox
            // 
            emailBox.BorderStyle = BorderStyle.FixedSingle;
            emailBox.Location = new Point(185, 167);
            emailBox.Multiline = true;
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter your email";
            emailBox.Size = new Size(360, 34);
            emailBox.TabIndex = 5;
            toolTip3.SetToolTip(emailBox, "Email: Valid format (e.g user@example.com)");
            emailBox.TextChanged += emailBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(80, 167);
            label3.Name = "label3";
            label3.Size = new Size(79, 31);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // phoneBox
            // 
            phoneBox.BorderStyle = BorderStyle.FixedSingle;
            phoneBox.Location = new Point(185, 224);
            phoneBox.Multiline = true;
            phoneBox.Name = "phoneBox";
            phoneBox.PlaceholderText = "Enter your phone number";
            phoneBox.Size = new Size(360, 34);
            phoneBox.TabIndex = 7;
            toolTip4.SetToolTip(phoneBox, "Phone Number: Allow only digits (10-15 characters).");
            phoneBox.TextChanged += phoneBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(80, 224);
            label4.Name = "label4";
            label4.Size = new Size(88, 31);
            label4.TabIndex = 6;
            label4.Text = "Phone:";
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.Crimson;
            submitButton.Enabled = false;
            submitButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitButton.Location = new Point(12, 310);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(123, 41);
            submitButton.TabIndex = 8;
            submitButton.Text = "Submit";
            toolTip5.SetToolTip(submitButton, "Submit: A button to insert the data into the database (Disabled by default, and only turns green when all fields are filled).");
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.SlateGray;
            clearButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearButton.Location = new Point(512, 310);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(123, 41);
            clearButton.TabIndex = 9;
            clearButton.Text = "Clear";
            toolTip6.SetToolTip(clearButton, "Clears all input fields");
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(647, 363);
            Controls.Add(clearButton);
            Controls.Add(submitButton);
            Controls.Add(phoneBox);
            Controls.Add(label4);
            Controls.Add(emailBox);
            Controls.Add(label3);
            Controls.Add(ageBox);
            Controls.Add(label2);
            Controls.Add(nameBox);
            Controls.Add(nameLabel);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox nameBox;
        private TextBox ageBox;
        private Label label2;
        private TextBox emailBox;
        private Label label3;
        private TextBox phoneBox;
        private Label label4;
        private Button submitButton;
        private Button clearButton;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip6;
    }
}