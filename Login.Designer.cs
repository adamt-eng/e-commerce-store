using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store
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
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            titleLabel = new Label();
            forgotPasswordLabel = new Label();
            progressBarPanel = new Panel();
            progressBarTimer = new Timer(components);
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
            // usernameTextBox
            // 
            usernameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(usernameTextBox, "usernameTextBox");
            usernameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            usernameTextBox.Name = "usernameTextBox";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(passwordTextBox, "passwordTextBox");
            passwordTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            passwordTextBox.Name = "passwordTextBox";
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // forgotPasswordLabel
            // 
            forgotPasswordLabel.Cursor = Cursors.Hand;
            resources.ApplyResources(forgotPasswordLabel, "forgotPasswordLabel");
            forgotPasswordLabel.ForeColor = Color.FromArgb(230, 57, 70);
            forgotPasswordLabel.Name = "forgotPasswordLabel";
            forgotPasswordLabel.Click += forgotPasswordLabel_Click;
            // 
            // progressBarPanel
            // 
            progressBarPanel.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(progressBarPanel, "progressBarPanel");
            progressBarPanel.Name = "progressBarPanel";
            // 
            // progressBarTimer
            // 
            progressBarTimer.Interval = 40;
            progressBarTimer.Tick += progressBarTimer_Tick;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(progressBarPanel);
            Controls.Add(forgotPasswordLabel);
            Controls.Add(titleLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(loginButton);
            Name = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label titleLabel;
        private Label forgotPasswordLabel;
        private Panel progressBarPanel;
        private System.Windows.Forms.Timer progressBarTimer;
    }
}
