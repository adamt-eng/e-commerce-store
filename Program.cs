using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new SellerPage());
    }
}