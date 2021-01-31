using Aerodrom.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aerodrom.Windows
{
    public partial class PackageWindow : Window
    {
        public string page = "Send";
        Package[] packages; 

        public PackageWindow(int userId, Action refresh)
        {
            Console.WriteLine(userId);
            InitializeComponent();

            Package package = new Package();
            packages = package.GetPackage();

            _NavigationFrame.Navigate(new SendPackage(userId, refresh));
        }

        public void SetPage(string newPage)
        {
            page = newPage;
        }
    }
}
