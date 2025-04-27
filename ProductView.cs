using System;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class ProductView : Form
{
    internal ProductView() => InitializeComponent();

    private void ProductView_Load(object sender, EventArgs e)
    {
        //if (admin)
        {
            foreach (var control in Controls.OfType<TextBox>())
            {
                control.ReadOnly = false;
            }

            inCartNumericUpDown.Visible = false;
            cartLabel.Visible = false;
        }
    }
}