using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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

    private async void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            progressBarPanel.Show();

            var targetWidth = progressBarPanel.MaximumSize.Width;
            var step = Math.Max(1, targetWidth / 40);

            while (progressBarPanel.Width < targetWidth)
            {
                await Task.Delay(10);
                progressBarPanel.Width = Math.Min(progressBarPanel.Width + step, targetWidth);
            }

            progressBarPanel.Hide();
            progressBarPanel.Width = 6;
            progressBarPanel.Height = 75;

            var loginType = loginTypeComboBox.SelectedItem.ToString();

            try
            {
                var email = emailTextBox.Text.Trim();

                // Uncomment this when done testing project
                /*if (!Validation.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                var password = PasswordHasher.Hash(passwordTextBox.Text.Trim());

                var prefix = loginType switch { "Seller" => "Seller_", "Admin" => "Admin_", _ => string.Empty };
                var result = (DataTable)Program.DatabaseHandler.ExecuteQuery($"SELECT * FROM [{loginType}] WHERE {prefix}Email = '{email}' AND Pass_Hashed = '{password}'");

                User = new KeyValuePair<string, int>(loginType, int.Parse(result.Rows[0][0].ToString()));
            }
            catch
            {
                MessageBox.Show("Incorrect credentials, please check your info and try again.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm = loginType switch
            {
                "Customer" => new CustomerPage(),
                "Admin" => new AdminPage(),
                "Seller" => new SellerPage(),
                _ => MainForm
            };

            Hide();
            MainForm.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error has occurred. Error: {ex.Message}.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RegisterLabel_Click(object sender, EventArgs e) => new Register().ShowDialog();

    private void Login_Load(object sender, EventArgs e) => loginTypeComboBox.SelectedIndex = 0;
}