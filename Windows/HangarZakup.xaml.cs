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
    public partial class HangarZakup : Window
    {
        Hangar[] hangars;
        static int currentUserId;
        static int currentObjectId;
        Action Refresh;

        public HangarZakup(int userId, int objectId, Action refresh)
        {
            InitializeComponent();
            Hangar hangar = new Hangar();
            hangars = hangar.GetHangars();
            Refresh = refresh;

            currentUserId = userId;
            currentObjectId = objectId;

            foreach (Hangar data in hangars)
            {
                HangarLista.Items.Add(new ComboBoxItem { Tag = data.Id, Content = data.Naziv + " " + data.Povrsina + "m² " + data.Cena + "EUR" });
            }
        }

        private void Zakupi_Click(object sender, RoutedEventArgs e)
        {
            if (HangarLista.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati hangar!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Pocetak.SelectedDate == null)
            {
                MessageBox.Show("Morate izabrati pocetni datum!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Kraj.SelectedDate == null)
            {
                MessageBox.Show("Morate izabrati krajnji datum!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Rent rent = new Rent();
            rent.SetRent((int)((ComboBoxItem)HangarLista.SelectedItem).Tag, currentUserId, currentObjectId, (DateTime)Pocetak.SelectedDate, (DateTime)Kraj.SelectedDate);
            Refresh();
            Window.GetWindow(this).Close();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pocetak.SelectedDate = null;
            Kraj.SelectedDate = null;
        }
    }
}
