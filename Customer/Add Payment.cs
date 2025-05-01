using System;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

internal partial class AddPayment : Form
{
    internal AddPayment() => InitializeComponent();

    private void DoneButton_Click(object sender, EventArgs e)
    {
        var cardNumber = cardNumberTextBox.Text.Trim();
        var cardholderName = cardholderNameTextBox.Text.Trim();
        var expiryDate = expiryDatePicker.Value;

        if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(cardholderName))
        {
            MessageBox.Show("Please fill in all fields.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            var query = $"""
                         
                                             INSERT INTO Payment (Customer_ID, Card_Number, CardHolder_Name, Card_Expiry_Date)
                                             VALUES ({Login.User.Value}, '{cardNumber}', '{cardholderName}', '{expiryDate:yyyy-MM-dd}')
                                         
                         """;


            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Payment added successfully!", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add payment. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}