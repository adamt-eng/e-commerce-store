using System;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Checkout : Form
{
    internal Checkout() => InitializeComponent();

    private void MyProfile_Load(object sender, EventArgs e)
    {
        // Load user data with SQL
    }

    private void enableEditingCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        PlaceOrderButton.Enabled = !PlaceOrderButton.Enabled;

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

    private void nameLabel_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void PlaceOrderButton_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}