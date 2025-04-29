using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class MyProfile : Form
{
    internal MyProfile() => InitializeComponent();

    private void MyProfile_Load(object sender, EventArgs e)
    {
        var result = Program.DatabaseHandler.ExecuteQuery(
            $"SELECT * FROM [{Login.User.Key}] WHERE {Login.User.Key}_ID = {Login.User.Value}"
        );

        if (result is DataTable { Rows.Count: > 0 } table)
        {
            var row = table.Rows[0];

            firstNameTextBox.Text = row["First_Name"].ToString();
            lastNameTextBox.Text = row["Last_Name"].ToString();
            emailTextBox.Text = row["Email"].ToString();
            passwordTextBox.Text = row["Pass_Hashed"].ToString();
            phoneNumberTextBox.Text = row["Phone_Number"].ToString();
            dobDateTimePicker.Value = row["Date_Of_Birth"] == DBNull.Value
                ? DateTime.Today
                : Convert.ToDateTime(row["Date_Of_Birth"]);

        }
        else
        {
            MessageBox.Show("Failed to load profile data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        result = Program.DatabaseHandler.ExecuteQuery(
            $"SELECT * FROM Customer_Address WHERE Customer_ID = {Login.User.Value}"
        );

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

        result = Program.DatabaseHandler.ExecuteQuery(
            $"SELECT * FROM Payment WHERE Customer_ID = {Login.User.Value}"
        );

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

    private void backButton_Click(object sender, EventArgs e)
    {
        Hide();
        Login.MainForm.Show();
    }

    private void showPreviousOrdersButton_Click(object sender, EventArgs e)
    {
        Hide();
        new PreviousOrders().ShowDialog();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var firstName = firstNameTextBox.Text.Trim().Replace("'", "''");
        var lastName = lastNameTextBox.Text.Trim().Replace("'", "''");
        var email = emailTextBox.Text.Trim().Replace("'", "''");
        var password = passwordTextBox.Text.Trim().Replace("'", "''");
        var phoneNumber = phoneNumberTextBox.Text.Trim().Replace("'", "''");
        var dateOfBirth = dobDateTimePicker.Value.ToString("yyyy-MM-dd");

        var phoneNumberValue = string.IsNullOrWhiteSpace(phoneNumber) ? "NULL" : $"'{phoneNumber}'";

        var query = $"""
                     
                             UPDATE [{Login.User.Key}]
                             SET 
                                 First_Name = '{firstName}',
                                 Last_Name = '{lastName}',
                                 Email = '{email}',
                                 Pass_Hashed = '{password}',
                                 Phone_Number = {phoneNumberValue},
                                 Date_Of_Birth = '{dateOfBirth}'
                             WHERE {Login.User.Key}_ID = {Login.User.Value}
                         
                     """;

        Program.DatabaseHandler.ExecuteQuery(query);
    }

    private void addressListBox_DoubleClick(object sender, EventArgs e)
    {
        new AddAddress().Show();
        Close();
    }

    private void paymentMethodsListBox_DoubleClick(object sender, EventArgs e)
    {
        new AddPayment().Show();
        Close();
    }

    private void deleteInAddressButton_Click(object sender, EventArgs e)
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

                MessageBox.Show("Address deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the address: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Please select an address to delete.");
        }
    }


    private void deleteInPaymentButton_Click(object sender, EventArgs e)
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

                MessageBox.Show("Payment method deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the payment method: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Please select a payment method to delete.");
        }
    }

}