using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aerodrom.Pages
{
    public partial class SendPackage : Page
    {
        private static PackageSize[] packageSizes;
        private static PackageSize PackageSize;
        private static int currentUserId;
        private Action Refresh;

        public SendPackage(int userId, Action refresh)
        {
            InitializeComponent();
            Flight flight = new Flight();
            Flight[] flights = flight.GetFlight();
            PackageSize packageSize = new PackageSize();
            packageSizes = packageSize.GetPackageSize();
            Array.Sort(packageSizes, delegate (PackageSize ps1, PackageSize ps2) { return ps1.VrednostVelicine.CompareTo(ps2.VrednostVelicine); });
            currentUserId = userId;
            Refresh = refresh;

            foreach (Flight data in flights)
            {
                Let.Items.Add(new ComboBoxItem { Tag= data.Id, Content= data.Dolazak + " " + data.VremePolaska});
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Package package = new Package();

            if (Zapremina.Value < 1)
            {
                MessageBox.Show("Morate uneti zapreminu!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Tezina.Value < 1)
            {
                MessageBox.Show("Morate uneti tezinu!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Let.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati let!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int letId = Int32.Parse(((ComboBoxItem)Let.SelectedItem).Tag.ToString());
            package.SetPackage(Naziv.Text.Length > 0 ? Naziv.Text : "Paket", currentUserId, PackageSize.Id, letId);

            Refresh();
            Window.GetWindow(this).Close();
        }

        private void CheckboxChanged(object sender, RoutedEventArgs e)
        {
            HandleChange();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void HandleChange()
        {
            int zapremina = (int)Zapremina.Value;
            int tezina = (int)Tezina.Value;

            bool lomljivo = (bool)Lomljivost.IsChecked;

            PackageSize = SetSize(zapremina, tezina, lomljivo);
            VrstaPaketa.Content = PackageSize.Naziv;

        }

        private PackageSize SetSize(int zapremina, int tezina, bool lomljivost)
        {
            foreach (PackageSize size in packageSizes)
            {
                if (lomljivost != size.Lomljivost)
                    continue;
                if (tezina > size.Tezina)
                    continue;
                if (zapremina > size.Zapremina)
                    continue;

                return size;
            }
            return packageSizes[packageSizes.Length - 1];
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int zapremina = (int)Zapremina.Value;
            int tezina = (int)Tezina.Value;

            ZapreminaBroj.Content = zapremina;
            TezinaBroj.Content = tezina;

            HandleChange();
        }
    }
}
