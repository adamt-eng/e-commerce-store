using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class AdminPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPage));
            titleLabel = new Label();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            loginButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBox1
            // 
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { resources.GetString("comboBox1.Items"), resources.GetString("comboBox1.Items1"), resources.GetString("comboBox1.Items2"), resources.GetString("comboBox1.Items3"), resources.GetString("comboBox1.Items4") });
            comboBox1.Name = "comboBox1";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // loginButton
            // 
            resources.ApplyResources(loginButton, "loginButton");
            loginButton.ForeColor = Color.FromArgb(241, 250, 238);
            loginButton.Name = "loginButton";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click_1;
            // 
            // AdminPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(loginButton);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(titleLabel);
            Name = "AdminPage";
            Load += AdminPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLabel;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Button loginButton;
    }
}
