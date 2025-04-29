using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class ThankYou : Form
{
    internal ThankYou() => InitializeComponent();

    private void ThankYou_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Restart();
    }
}