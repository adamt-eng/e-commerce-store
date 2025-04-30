using System;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

internal partial class ChangePassword : Form
{
    internal ChangePassword() => InitializeComponent();

    private void doneButton_Click(object sender, EventArgs e)
    {
        var newPassword = passwordTextBox.Text.Trim();

        if (string.IsNullOrEmpty(newPassword))
        {
            MessageBox.Show("Please type in your new password.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Program.DatabaseHandler.ExecuteQuery($"UPDATE Customer SET Pass_Hashed = '{newPassword}' WHERE Customer_ID = {Login.User.Value}");

        MessageBox.Show("Password changed successfully!", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

        Close();
    }
}