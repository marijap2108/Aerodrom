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
    public partial class DodajLet : Window
    {
        int currentUserId;
        Action Refresh;

        public DodajLet(int userId, Action refresh)
        {
            InitializeComponent();
            currentUserId = userId;
            Refresh = refresh;
            Airplane airplane = new Airplane();
            foreach(Airplane data in airplane.GetAirplanes())
            {
                ListaAviona.Items.Add(data.Id);
            }
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (Polazak.Text.Length < 1)
            {
                MessageBox.Show("Morate dodati mesto polaska!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Destinacija.Text.Length < 1)
            {
                MessageBox.Show("Morate dodati destinaciju!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Pocetak.SelectedDate == null)
            {
                MessageBox.Show("Morate izabrati datum polaska!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Kraj.SelectedDate == null)
            {
                MessageBox.Show("Morate izabrati datum dolaska!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ListaAviona.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati avion!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            Flight flight = new Flight();
            flight.SetFlight(Polazak.Text, Destinacija.Text, (DateTime)Pocetak.SelectedDate, (DateTime)Kraj.SelectedDate, (int)ListaAviona.SelectedItem, currentUserId);
            Refresh();
            Window.GetWindow(this).Close();
        }
    }
}
