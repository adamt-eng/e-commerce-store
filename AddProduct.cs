using System;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AddProduct : Form
{
    internal AddProduct() => InitializeComponent();

    private void ProductAdd_Load(object sender, EventArgs e)
    {

        {
            foreach (var control in Controls.OfType<TextBox>())
            {
                control.ReadOnly = false;
            }

        }
    }

    private void emailTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void titleLabel_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void loginButton_Click(object sender, EventArgs e)
    {

    }
}