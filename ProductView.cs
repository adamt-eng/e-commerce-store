using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class ProductView : Form
{
    internal ProductView() => InitializeComponent();

    private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
    {
        // Implement logic that refreshes the dataview control with products that match the input text
    }

    private void HomePage_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        Hide();
        new MyProfile().ShowDialog();
    }
}