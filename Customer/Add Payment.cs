using System;
using System.Data;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

internal partial class AddPayment : Form
{
    private readonly MyProfile _myProfile;

    internal AddPayment(MyProfile myProfile)
    {
        InitializeComponent();
        _myProfile = myProfile;
    }

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
            var checkQuery = $"SELECT 1 FROM Payment WHERE Customer_ID = {Login.User.Value} AND Card_Number = '{cardNumber}'";

            if (Program.DatabaseHandler.ExecuteQuery(checkQuery) is DataTable { Rows.Count: > 0 })
            {
                MessageBox.Show("You have already added this card.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var insertQuery = $"""
                                   INSERT INTO Payment (Customer_ID, Card_Number, CardHolder_Name, Card_Expiry_Date)
                                   VALUES ({Login.User.Value}, '{cardNumber}', '{cardholderName}', '{expiryDate:yyyy-MM-dd}')
                               """;

            Program.DatabaseHandler.ExecuteQuery(insertQuery);

            MessageBox.Show("Payment added successfully!", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _myProfile.MyProfile_Load(null, null);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add payment. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}