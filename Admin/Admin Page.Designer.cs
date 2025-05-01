using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Admin
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
            comboBox = new ComboBox();
            deleteButton = new Button();
            addButton = new Button();
            registerButton = new Button();
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
            // 
            // comboBox
            // 
            resources.ApplyResources(comboBox, "comboBox");
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { resources.GetString("comboBox.Items"), resources.GetString("comboBox.Items1"), resources.GetString("comboBox.Items2"), resources.GetString("comboBox.Items3"), resources.GetString("comboBox.Items4") });
            comboBox.Name = "comboBox";
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // deleteButton
            // 
            resources.ApplyResources(deleteButton, "deleteButton");
            deleteButton.ForeColor = Color.FromArgb(241, 250, 238);
            deleteButton.Name = "deleteButton";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // addButton
            // 
            resources.ApplyResources(addButton, "addButton");
            addButton.ForeColor = Color.FromArgb(241, 250, 238);
            addButton.Name = "addButton";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // registerButton
            // 
            resources.ApplyResources(registerButton, "registerButton");
            registerButton.ForeColor = Color.FromArgb(241, 250, 238);
            registerButton.Name = "registerButton";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += RegisterButton_Click;
            // 
            // AdminPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(registerButton);
            Controls.Add(addButton);
            Controls.Add(deleteButton);
            Controls.Add(comboBox);
            Controls.Add(dataGridView1);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            Name = "AdminPage";
            FormClosed += AdminPage_FormClosed;
            Load += AdminPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLabel;
        private DataGridView dataGridView1;
        private ComboBox comboBox;
        private Button deleteButton;
        private Button addButton;
        private Button registerButton;
    }
}
