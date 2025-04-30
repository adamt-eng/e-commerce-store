using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using E_Commerce_Store.Admin;
using E_Commerce_Store.Customer;
using E_Commerce_Store.Seller;

namespace E_Commerce_Store.Common;

internal partial class Login : Form
{
    internal static Form MainForm;
    internal static KeyValuePair<string, int> User;
    internal Login() => InitializeComponent();

    private void loginButton_Click(object sender, EventArgs e)
    {
        progressBarPanel.Show();
        progressBarTimer.Start();
    }

    private void progressBarTimer_Tick(object sender, EventArgs e)
    {
        if (progressBarPanel.Width == progressBarPanel.MaximumSize.Width) return;

        progressBarPanel.Width += progressBarPanel.MaximumSize.Width / 30;

        if (progressBarPanel.Width != progressBarPanel.MaximumSize.Width) return;

        progressBarTimer.Stop();

        var id = Authenticate(emailTextBox.Text.Trim(), passwordTextBox.Text.Trim());
        var loginType = loginTypeComboBox.SelectedItem.ToString();
        switch (loginType)
        {
            case "Customer": MainForm = new CustomerPage(); break;
            case "Admin": MainForm = new AdminPage(); break;
            case "Seller": MainForm = new SellerPage(); break;
            default: 
                MessageBox.Show("Incorrect credentials, please check your info and try again.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBarPanel.Hide();
                progressBarPanel.Size = new Size(6, 75);
                return;
        }

        try
        {
            User = new KeyValuePair<string, int>(loginType, int.Parse(id));
        }
        catch
        {
            MessageBox.Show("Incorrect credentials, please check your info and try again.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            progressBarPanel.Hide();
            progressBarPanel.Size = new Size(6, 75);
            return;
        }

        Hide();
        MainForm.ShowDialog();
    }

    private string Authenticate(string email, string password)
    {
        var loginType = loginTypeComboBox.SelectedItem.ToString();
        var result = Program.DatabaseHandler.ExecuteQuery($"SELECT * FROM [{loginType}] WHERE {loginType switch
        {
            "Seller" => "Seller_",
            "Admin" => "Admin_",
            _ => string.Empty
        }}Email = '{email}' AND Pass_Hashed = '{password}'");
        return result is DataTable { Rows.Count: > 0 } table ? table.Rows[0][0].ToString() : null;
    }

    private void registerLabel_Click(object sender, EventArgs e) => new Register().ShowDialog();

    private void Login_Load(object sender, EventArgs e) => loginTypeComboBox.SelectedIndex = 0;
}