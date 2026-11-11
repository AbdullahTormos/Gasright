namespace GasRight
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
            txtEmail = new TextBox();
            txtPass = new TextBox();
            label1 = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(275, 158);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(240, 23);
            txtEmail.TabIndex = 0;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtPass
            // 
            txtPass.BackColor = SystemColors.Window;
            txtPass.ForeColor = SystemColors.WindowText;
            txtPass.Location = new Point(275, 203);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Password";
            txtPass.Size = new Size(240, 23);
            txtPass.TabIndex = 0;
            txtPass.TextChanged += password_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F);
            label1.Location = new Point(289, 9);
            label1.Name = "label1";
            label1.Size = new Size(217, 65);
            label1.TabIndex = 1;
            label1.Text = "GasRight";
            label1.Click += label1_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Green;
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(321, 264);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(142, 35);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(txtPass);
            Controls.Add(txtEmail);
            Name = "Form1";
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtPass;
        private Label label1;
        private Button btnLogin;
    }
}
