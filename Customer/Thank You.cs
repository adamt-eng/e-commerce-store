using System.Windows.Forms;

namespace E_Commerce_Store.Customer;

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