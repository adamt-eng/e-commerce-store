using System;
using System.Data;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

internal partial class MyProfile : Form
{
    internal MyProfile() => InitializeComponent();

    private void MyProfile_Load(object sender, EventArgs e)
    {
        var result = Program.DatabaseHandler.ExecuteQuery($"SELECT * FROM Customer WHERE Customer_ID = {Login.User.Value}");

        if (result is DataTable { Rows.Count: > 0 } table)
        {
            var row = table.Rows[0];

            firstNameTextBox.Text = row["First_Name"].ToString();
            lastNameTextBox.Text = row["Last_Name"].ToString();
            phoneNumberTextBox.Text = row["Phone_Number"].ToString();
            dobDateTimePicker.Value = row["Date_Of_Birth"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(row["Date_Of_Birth"]);
        }
        else
        {
            MessageBox.Show("Failed to load profile data.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        result = Program.DatabaseHandler.ExecuteQuery($"SELECT * FROM Customer_Address WHERE Customer_ID = {Login.User.Value}");

        if (result is DataTable { Rows.Count: > 0 } table2)
        {
            addressListBox.Items.Clear();
            foreach (DataRow row in table2.Rows)
            {
                var label = row["Label"].ToString();
                var city = row["City"].ToString();
                var description = row["Address_Description"].ToString();
                addressListBox.Items.Add($"{label}: {city} - {description}");
            }
        }
        else
        {
            addressListBox.Items.Add("No addresses available.");
        }

        result = Program.DatabaseHandler.ExecuteQuery($"SELECT * FROM Payment WHERE Customer_ID = {Login.User.Value}");

        if (result is DataTable { Rows.Count: > 0 } table3)
        {
            paymentMethodsListBox.Items.Clear();
            foreach (DataRow row in table3.Rows)
            {
                var cardno = row["Card_Number"].ToString();
                var cardname = row["CardHolder_Name"].ToString();
                var cardexp = row["Card_Expiry_Date"].ToString();
                paymentMethodsListBox.Items.Add($"{cardname}: {cardno} - {cardexp}");
            }
        }
        else
        {
            paymentMethodsListBox.Items.Add("No Payment Methods available.");
        }
    }

    private void enableEditingCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        saveButton.Enabled = !saveButton.Enabled;

        foreach (var control in Controls)
        {
            switch (control)
            {
                case TextBox textBox: textBox.ReadOnly = !textBox.ReadOnly; break;
                case DateTimePicker dateTimePicker: dateTimePicker.Enabled = !dateTimePicker.Enabled; break;
            }
        }
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var firstName = firstNameTextBox.Text.Trim();
        var lastName = lastNameTextBox.Text.Trim();
        var phoneNumber = phoneNumberTextBox.Text.Trim();
        var dateOfBirth = dobDateTimePicker.Value.ToString("yyyy-MM-dd");

        var query = $"""
                     
                             UPDATE Customer
                             SET 
                                 First_Name = '{firstName}',
                                 Last_Name = '{lastName}',
                                 Phone_Number = '{phoneNumber}',
                                 Date_Of_Birth = '{dateOfBirth}'
                             WHERE Customer_ID = {Login.User.Value}
                         
                     """;

        Program.DatabaseHandler.ExecuteQuery(query);
    }

    private void showPreviousOrdersButton_Click(object sender, EventArgs e) => new MyOrders().ShowDialog();

    private void addPaymentLabel_Click(object sender, EventArgs e) => new AddPayment().Show();
    private void deletePaymentLabel_Click(object sender, EventArgs e)
    {
        if (paymentMethodsListBox.SelectedIndex != -1)
        {
            var selectedItem = paymentMethodsListBox.SelectedItem.ToString();

            try
            {
                var cardNumber = selectedItem.Split(":")[1].Split("-")[0].Trim();

                var query = $"DELETE FROM Payment WHERE Customer_ID = {Login.User.Value} AND Card_Number = '{cardNumber}'";

                Program.DatabaseHandler.ExecuteQuery(query);

                paymentMethodsListBox.Items.RemoveAt(paymentMethodsListBox.SelectedIndex);

                MessageBox.Show("Payment method deleted successfully.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the payment method: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Please select an payment method to delete.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void addAddressLabel_Click(object sender, EventArgs e) => new AddAddress().Show();
    private void deleteAddressLabel_Click(object sender, EventArgs e)
    {
        if (addressListBox.SelectedIndex != -1)
        {
            var selectedItem = addressListBox.SelectedItem.ToString();

            try
            {
                var labelPart = selectedItem.Split(":")[0].Trim();

                var query = $"DELETE FROM Customer_Address WHERE Customer_ID = {Login.User.Value} AND Label = '{labelPart}'";

                Program.DatabaseHandler.ExecuteQuery(query);

                addressListBox.Items.RemoveAt(addressListBox.SelectedIndex);

                MessageBox.Show("Address deleted successfully.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the address: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Please select an address to delete.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void changePasswordButton_Click(object sender, EventArgs e) => new ChangePassword().Show();
}