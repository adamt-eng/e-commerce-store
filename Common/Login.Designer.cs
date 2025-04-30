using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Common
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            loginButton = new Button();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            registerLabel = new Label();
            progressBarPanel = new Panel();
            progressBarTimer = new Timer(components);
            loginTypeComboBox = new ComboBox();
            loginTypeLabel = new Label();
            successIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)successIcon).BeginInit();
            SuspendLayout();
            // 
            // loginButton
            // 
            resources.ApplyResources(loginButton, "loginButton");
            loginButton.ForeColor = Color.FromArgb(241, 250, 238);
            loginButton.Name = "loginButton";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(emailTextBox, "emailTextBox");
            emailTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            emailTextBox.Name = "emailTextBox";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(passwordTextBox, "passwordTextBox");
            passwordTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            passwordTextBox.Name = "passwordTextBox";
            // 
            // registerLabel
            // 
            registerLabel.Cursor = Cursors.Hand;
            resources.ApplyResources(registerLabel, "registerLabel");
            registerLabel.ForeColor = Color.FromArgb(230, 57, 70);
            registerLabel.Name = "registerLabel";
            registerLabel.Click += registerLabel_Click;
            // 
            // progressBarPanel
            // 
            progressBarPanel.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(progressBarPanel, "progressBarPanel");
            progressBarPanel.Name = "progressBarPanel";
            // 
            // progressBarTimer
            // 
            progressBarTimer.Interval = 1;
            progressBarTimer.Tick += progressBarTimer_Tick;
            // 
            // loginTypeComboBox
            // 
            resources.ApplyResources(loginTypeComboBox, "loginTypeComboBox");
            loginTypeComboBox.FormattingEnabled = true;
            loginTypeComboBox.Items.AddRange(new object[] { resources.GetString("loginTypeComboBox.Items"), resources.GetString("loginTypeComboBox.Items1"), resources.GetString("loginTypeComboBox.Items2") });
            loginTypeComboBox.Name = "loginTypeComboBox";
            // 
            // loginTypeLabel
            // 
            resources.ApplyResources(loginTypeLabel, "loginTypeLabel");
            loginTypeLabel.ForeColor = Color.FromArgb(241, 250, 238);
            loginTypeLabel.Name = "loginTypeLabel";
            // 
            // successIcon
            // 
            resources.ApplyResources(successIcon, "successIcon");
            successIcon.Name = "successIcon";
            successIcon.TabStop = false;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(successIcon);
            Controls.Add(loginTypeLabel);
            Controls.Add(loginTypeComboBox);
            Controls.Add(progressBarPanel);
            Controls.Add(registerLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(loginButton);
            MaximizeBox = false;
            Name = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)successIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private Label registerLabel;
        private Panel progressBarPanel;
        private System.Windows.Forms.Timer progressBarTimer;
        private ComboBox loginTypeComboBox;
        private Label loginTypeLabel;
        private PictureBox successIcon;
    }
}
