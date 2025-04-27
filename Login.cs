using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Login : Form
{
    internal static Form HomePageInstance;

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

        HomePageInstance = new HomePage();
        Hide();
        HomePageInstance.ShowDialog();
    }

    private bool Authenticate(string username, string password)
    {
        // SQL query to get userId with the specified username and password
        // Say incorrect information if not found
        // If admin show admin page
        // If seller show seller page
        // If user show user page

        return false;
    }

    private void registerLabel_Click(object sender, EventArgs e)
    {
        Hide();
        new Register().ShowDialog();
    }
}