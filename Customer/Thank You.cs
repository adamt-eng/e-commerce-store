using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace E_Commerce_Store;

internal partial class ThankYou : Form
{
    private readonly Cart _cart;

    internal ThankYou(Cart cart)
    {
        _cart = cart;
        InitializeComponent();
    }

    private void ThankYou_FormClosing(object sender, FormClosingEventArgs e) => _cart.PurchaseDone = true;
}