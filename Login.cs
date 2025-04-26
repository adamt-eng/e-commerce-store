using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Login : Form
{
    internal static Form HomePageInstance;

    internal Login() => InitializeComponent();

    private void loginButton_Click(object sender, EventArgs e)
    {
        HomePageInstance = new HomePage();
        Hide();
        HomePageInstance.ShowDialog();

        //progressBarTimer.Start();
    }

    private void progressBarTimer_Tick(object sender, EventArgs e)
    {
        while (progressBarPanel.Width != loginButton.Width - 2)
        {
            progressBarPanel.Width += (loginButton.Width - 2) / 20;

            if (progressBarPanel.Width != loginButton.Width - 2) continue;

            progressBarTimer.Stop();

            HomePageInstance = new HomePage();
            Hide();
            HomePageInstance.ShowDialog();
        }
    }

    private void forgotPasswordLabel_Click(object sender, EventArgs e)
    {
        Hide();
        new Register().ShowDialog();
    }
}