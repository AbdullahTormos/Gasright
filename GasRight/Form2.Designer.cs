namespace GasRight
{
    partial class Dashboard
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
            dashheader = new Label();
            txtVIN = new TextBox();
            label1 = new Label();
            btnSearch = new Button();
            txtResult = new TextBox();
            btnLogout = new Button();
            numLitersToFill = new NumericUpDown();
            btnFillGas = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numLitersToFill).BeginInit();
            SuspendLayout();
            // 
            // dashheader
            // 
            dashheader.AutoSize = true;
            dashheader.Font = new Font("Segoe UI", 36F);
            dashheader.Location = new Point(172, 9);
            dashheader.Name = "dashheader";
            dashheader.Size = new Size(481, 65);
            dashheader.TabIndex = 0;
            dashheader.Text = "Attendant Dashboard";
            // 
            // txtVIN
            // 
            txtVIN.Location = new Point(207, 149);
            txtVIN.MaxLength = 17;
            txtVIN.Name = "txtVIN";
            txtVIN.PlaceholderText = "VIN";
            txtVIN.Size = new Size(174, 23);
            txtVIN.TabIndex = 1;
            txtVIN.TextChanged += txtVIN_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 152);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 2;
            label1.Text = "Enter VIN Number:";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(413, 149);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(88, 211);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(400, 187);
            txtResult.TabIndex = 6;
            txtResult.TextChanged += txtResult_TextChanged;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(713, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // numLitersToFill
            // 
            numLitersToFill.Location = new Point(590, 257);
            numLitersToFill.Name = "numLitersToFill";
            numLitersToFill.Size = new Size(120, 23);
            numLitersToFill.TabIndex = 8;
            numLitersToFill.ValueChanged += numLitersToFill_ValueChanged;
            // 
            // btnFillGas
            // 
            btnFillGas.Location = new Point(609, 295);
            btnFillGas.Name = "btnFillGas";
            btnFillGas.Size = new Size(75, 23);
            btnFillGas.TabIndex = 9;
            btnFillGas.Text = "Fill";
            btnFillGas.UseVisualStyleBackColor = true;
            btnFillGas.Click += btnFillGas_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(535, 259);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 10;
            label2.Text = "Liters:";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnFillGas);
            Controls.Add(numLitersToFill);
            Controls.Add(btnLogout);
            Controls.Add(txtResult);
            Controls.Add(btnSearch);
            Controls.Add(label1);
            Controls.Add(txtVIN);
            Controls.Add(dashheader);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)numLitersToFill).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dashheader;
        private TextBox txtVIN;
        private Label label1;
        private Button btnSearch;
        private TextBox txtResult;
        private Button btnLogout;
        private NumericUpDown numLitersToFill;
        private Button btnFillGas;
        private Label label2;
    }
}