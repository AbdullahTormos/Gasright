namespace GasRight
{
    partial class Admin
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
            label1 = new Label();
            tabCtrl = new TabControl();
            VehicleManagement = new TabPage();
            btnDeleteVehicle = new Button();
            btnAddVehicle = new Button();
            groupBox2 = new GroupBox();
            dgvVehicles = new DataGridView();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            cmbProfession = new ComboBox();
            txtOwnerName = new TextBox();
            txtVIN = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            LimitSettings = new TabPage();
            dvgProfessions = new GroupBox();
            dgvProfessions = new DataGridView();
            groupBox3 = new GroupBox();
            cmbProfession2 = new ComboBox();
            btnSaveChanges = new Button();
            numFuelLimit = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            btnLogout = new Button();
            tabCtrl.SuspendLayout();
            VehicleManagement.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            LimitSettings.SuspendLayout();
            dvgProfessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfessions).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFuelLimit).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F);
            label1.Location = new Point(99, 9);
            label1.Name = "label1";
            label1.Size = new Size(623, 65);
            label1.TabIndex = 0;
            label1.Text = "Admin Management System";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabCtrl
            // 
            tabCtrl.Controls.Add(VehicleManagement);
            tabCtrl.Controls.Add(LimitSettings);
            tabCtrl.Location = new Point(1, 89);
            tabCtrl.Name = "tabCtrl";
            tabCtrl.SelectedIndex = 0;
            tabCtrl.Size = new Size(796, 360);
            tabCtrl.TabIndex = 2;
            // 
            // VehicleManagement
            // 
            VehicleManagement.Controls.Add(btnDeleteVehicle);
            VehicleManagement.Controls.Add(btnAddVehicle);
            VehicleManagement.Controls.Add(groupBox2);
            VehicleManagement.Controls.Add(groupBox1);
            VehicleManagement.Location = new Point(4, 24);
            VehicleManagement.Name = "VehicleManagement";
            VehicleManagement.Padding = new Padding(3);
            VehicleManagement.Size = new Size(788, 332);
            VehicleManagement.TabIndex = 0;
            VehicleManagement.Text = "VehicleManagement";
            VehicleManagement.UseVisualStyleBackColor = true;
            VehicleManagement.Click += VehicleManagement_Click;
            // 
            // btnDeleteVehicle
            // 
            btnDeleteVehicle.Location = new Point(540, 281);
            btnDeleteVehicle.Name = "btnDeleteVehicle";
            btnDeleteVehicle.Size = new Size(144, 40);
            btnDeleteVehicle.TabIndex = 2;
            btnDeleteVehicle.Text = "Delete";
            btnDeleteVehicle.UseVisualStyleBackColor = true;
            btnDeleteVehicle.Click += btnDeleteVehicle_Click;
            // 
            // btnAddVehicle
            // 
            btnAddVehicle.Location = new Point(119, 281);
            btnAddVehicle.Name = "btnAddVehicle";
            btnAddVehicle.Size = new Size(144, 40);
            btnAddVehicle.TabIndex = 2;
            btnAddVehicle.Text = "Add";
            btnAddVehicle.UseVisualStyleBackColor = true;
            btnAddVehicle.Click += btnAddVehicle_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvVehicles);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(421, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(345, 252);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Active Database Records";
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicles.Location = new Point(30, 39);
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(295, 188);
            dgvVehicles.TabIndex = 0;
            dgvVehicles.CellContentClick += dgvVehicles_CellContentClick;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 39);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(295, 169);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbProfession);
            groupBox1.Controls.Add(txtOwnerName);
            groupBox1.Controls.Add(txtVIN);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(20, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 252);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registeration";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cmbProfession
            // 
            cmbProfession.FormattingEnabled = true;
            cmbProfession.Location = new Point(18, 185);
            cmbProfession.Name = "cmbProfession";
            cmbProfession.Size = new Size(201, 23);
            cmbProfession.TabIndex = 2;
            // 
            // txtOwnerName
            // 
            txtOwnerName.Location = new Point(18, 118);
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.Size = new Size(199, 23);
            txtOwnerName.TabIndex = 1;
            txtOwnerName.TextChanged += textBox1_TextChanged;
            // 
            // txtVIN
            // 
            txtVIN.Location = new Point(18, 52);
            txtVIN.MaxLength = 17;
            txtVIN.Name = "txtVIN";
            txtVIN.Size = new Size(199, 23);
            txtVIN.TabIndex = 1;
            txtVIN.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 167);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 0;
            label4.Text = "Profession:";
            label4.Click += label3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 100);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 0;
            label3.Text = "Owners Full Name:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 34);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 0;
            label2.Text = "Vehicle VIN Number:";
            // 
            // LimitSettings
            // 
            LimitSettings.Controls.Add(dvgProfessions);
            LimitSettings.Controls.Add(groupBox3);
            LimitSettings.Location = new Point(4, 24);
            LimitSettings.Name = "LimitSettings";
            LimitSettings.Padding = new Padding(3);
            LimitSettings.Size = new Size(788, 332);
            LimitSettings.TabIndex = 1;
            LimitSettings.Text = "LimitSettings";
            LimitSettings.UseVisualStyleBackColor = true;
            // 
            // dvgProfessions
            // 
            dvgProfessions.Controls.Add(dgvProfessions);
            dvgProfessions.Location = new Point(416, 25);
            dvgProfessions.Name = "dvgProfessions";
            dvgProfessions.Size = new Size(319, 276);
            dvgProfessions.TabIndex = 1;
            dvgProfessions.TabStop = false;
            dvgProfessions.Text = "Current Profession Allocation";
            // 
            // dgvProfessions
            // 
            dgvProfessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfessions.Location = new Point(19, 37);
            dgvProfessions.Name = "dgvProfessions";
            dgvProfessions.Size = new Size(282, 215);
            dgvProfessions.TabIndex = 0;
            dgvProfessions.CellContentClick += dgvProfessions_CellContentClick_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbProfession2);
            groupBox3.Controls.Add(btnSaveChanges);
            groupBox3.Controls.Add(numFuelLimit);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(57, 25);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(308, 276);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Manage Limits";
            // 
            // cmbProfession2
            // 
            cmbProfession2.FormattingEnabled = true;
            cmbProfession2.Location = new Point(57, 64);
            cmbProfession2.Name = "cmbProfession2";
            cmbProfession2.Size = new Size(192, 23);
            cmbProfession2.TabIndex = 4;
            cmbProfession2.SelectedIndexChanged += cmbProfession2_SelectedIndexChanged;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(82, 181);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(154, 35);
            btnSaveChanges.TabIndex = 3;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += button1_Click;
            // 
            // numFuelLimit
            // 
            numFuelLimit.Location = new Point(57, 140);
            numFuelLimit.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numFuelLimit.Name = "numFuelLimit";
            numFuelLimit.Size = new Size(192, 23);
            numFuelLimit.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 109);
            label6.Name = "label6";
            label6.Size = new Size(108, 15);
            label6.TabIndex = 0;
            label6.Text = "Weekly Fuel Limits:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 37);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 0;
            label5.Text = "Professions:";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(713, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(tabCtrl);
            Controls.Add(label1);
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            Load += Admin_Load;
            tabCtrl.ResumeLayout(false);
            VehicleManagement.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            LimitSettings.ResumeLayout(false);
            dvgProfessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProfessions).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFuelLimit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabCtrl;
        private TabPage VehicleManagement;
        private TabPage LimitSettings;
        private GroupBox groupBox1;
        private TextBox txtVIN;
        private Label label3;
        private Label label2;
        private TextBox txtOwnerName;
        private ComboBox cmbProfession;
        private Label label4;
        private Button btnAddVehicle;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridView dgvVehicles;
        private Button btnDeleteVehicle;
        private GroupBox groupBox3;
        private Label label5;
        private Button btnSaveChanges;
        private NumericUpDown numFuelLimit;
        private Label label6;
        private GroupBox dvgProfessions;
        private DataGridView dgvProfessions;
        private Button btnLogout;
        private ComboBox cmbProfession2;
    }
}