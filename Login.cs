using System;
using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Login : Form
{
    internal static Form MainForm;

    internal Login() => InitializeComponent();

    private void loginButton_Click(object sender, EventArgs e)
    {
        progressBarPanel.Show();
        progressBarTimer.Start();
    }

    private void progressBarTimer_Tick(object sender, EventArgs e)
    {
        if (progressBarPanel.Width == progressBarPanel.MaximumSize.Width) return;

        progressBarPanel.Width += progressBarPanel.MaximumSize.Width / 50;

        if (progressBarPanel.Width != progressBarPanel.MaximumSize.Width) return;

        progressBarTimer.Stop();

        switch (Authenticate(usernameTextBox.Text, passwordTextBox.Text))
        {
            case "Customer": MainForm = new HomePage(); break;
            case "Admin": MainForm = new AdminPage(); break;
            case "Seller": MainForm = new SellerPage(); break;
            default: 
                MessageBox.Show("Incorrect credentials, please check your info and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBarPanel.Hide();
                progressBarPanel.Size = new Size(6, 75);
                return;
        }
        
        Hide();
        MainForm.ShowDialog();
    }

    private string Authenticate(string username, string password)
    {
        var loginType = loginTypeComboBox.SelectedItem;
        var result = Program.DatabaseHandler.ExecuteQuery($"SELECT * FROM {loginType} WHERE Email = '{username}' AND Pass_Hashed = '{password}'"); ;

        return string.IsNullOrWhiteSpace(result.ToString()) ? null : loginType.ToString();
    }

    private void registerLabel_Click(object sender, EventArgs e)
    {
        Hide();
        new Register().ShowDialog();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Login_Load(object sender, EventArgs e)
    {
        loginTypeComboBox.SelectedIndex = 0;
    }
}