using Aerodrom.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aerodrom.Pages
{
    public partial class ListaLetova : Page
    {
        #region Select upiti
        static string letSelect = @"Select KartaID as ID, NazivPolaska, NazivDestinacije, VremeIDatumPolaska, VremeIDatumDolaska from tblLet, tblKarta where KorisnikID = @UserId and tblKarta.LetID = tblLet.LetID";
        static string letSelectAll = @"Select LetID as ID, NazivPolaska, NazivDestinacije, VremeIDatumPolaska, VremeIDatumDolaska from tblLet";
        static string letSelectAvailable = @"Select LetID as ID, NazivPolaska, NazivDestinacije, VremeIDatumPolaska, VremeIDatumDolaska from tblLet, tblAvion where tblAvion.AvionID = tblLet.AvionID and VremeIDatumPolaska > GETDATE() and BrojMesta > (Select Count(*) from tblKarta where tblKarta.LetID = tblLet.LetID)";
        static string deleteKarta = @"Delete from tblKarta where KartaID =";
        static string deleteLet = @"Delete from tblLet where LetID =";
        static string updateLet = @"Update tblLet set NazivPolaska = @nazivPolaska, NazivDestinacije = @nazivDestinacije, VremeIDatumPolaska = @polazak, VremeIDatumDolaska = @dolazak where LetID = @id";
        #endregion

        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        User currentUser;
        bool sviLetovi = true;

        public ListaLetova(User user)
        {
            currentUser = user;
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            if (user == null)
            {
                dataGrid.IsReadOnly = true;
                UcitajPodatke(dataGrid, letSelectAll);
            }
            else
            {
                Meni.Width = new GridLength(120);

                if (user.isOWner)
                {
                    ToggleButton.Visibility = Visibility.Collapsed;
                    ActionButton.Content = "Dodaj let";
                    UcitajPodatke(dataGrid, letSelectAll);
                }
                else
                {
                    DeleteFlight.Visibility = Visibility.Collapsed;
                    EditFlight.Visibility = Visibility.Collapsed;
                    dataGrid.IsReadOnly = true;
                    UcitajPodatke(dataGrid, letSelectAvailable);
                }
            }
        }

        public void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            konekcija.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
            if (currentUser != null && !currentUser.isOWner)
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@userId", currentUser.Id);
            }
            DataTable dt = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(dt);
            if (grid != null)
            {
                grid.ItemsSource = dt.DefaultView;
            }
            dt.Dispose();
            dataAdapter.Dispose();
            konekcija.Close();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sviLetovi)
            {
                ToggleButton.Content = "Svi letovi";
                ActionButton.Content = "Otkaži kartu";
                UcitajPodatke(dataGrid, letSelect);
            }
            else
            {
                ToggleButton.Content = "Moji letovi";
                ActionButton.Content = "Kupi kartu";
                UcitajPodatke(dataGrid, letSelectAvailable);
            }
            sviLetovi = !sviLetovi;
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser.isOWner)
            {
                DodajLet dodajLet = new DodajLet(currentUser.Id, Refresh);
                dodajLet.Show();
                return;
            }
            if (sviLetovi)
            {
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    Ticket ticket = new Ticket();
                    try
                    {
                        DataRowView red = (DataRowView)dataGrid.SelectedItems[0];
                        ticket.SetTicket(Int32.Parse(red["ID"].ToString()), currentUser.Id);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Niste selektovali red", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (currentUser.isOWner)
                    {
                        UcitajPodatke(dataGrid, letSelectAll);
                    }
                    else
                    {
                        UcitajPodatke(dataGrid, letSelectAvailable);
                    }
                }
            }
            else
            {
                Otkazi(dataGrid);
                UcitajPodatke(dataGrid, letSelect);
            }
        }

        private void Otkazi(DataGrid grid)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    if (currentUser.isOWner)
                    {
                        komanda.CommandText = deleteLet + "@id";
                    }
                    else
                    {
                        komanda.CommandText = deleteKarta + "@id";
                    }
                    komanda.ExecuteNonQuery();
                    komanda.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obaveštenje!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void Refresh()
        {
            UcitajPodatke(dataGrid, letSelectAll);
        }

        private void DeleteFlight_Click(object sender, RoutedEventArgs e)
        {
            Otkazi(dataGrid);
            UcitajPodatke(dataGrid, letSelectAll);
        }

        private void EditFlight_Click(object sender, RoutedEventArgs e)
        {
            Izmeni(dataGrid);
            UcitajPodatke(dataGrid, letSelectAll);
        }

        private void Izmeni(DataGrid grid)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand
                    {
                        Connection = konekcija
                    };

                    komanda.CommandText = updateLet;

                    SqlParameter id = new SqlParameter("@id", red["ID"]);
                    SqlParameter nazivPolaska = new SqlParameter("@nazivPolaska", red["NazivPolaska"]);
                    SqlParameter nazivDestinacije = new SqlParameter("@nazivDestinacije", red["NazivDestinacije"]);
                    SqlParameter polazak = new SqlParameter("@polazak", red["VremeIDatumPolaska"]);
                    SqlParameter dolazak = new SqlParameter("@dolazak", red["VremeIDatumDolaska"]);

                    komanda.Parameters.Add(id);
                    komanda.Parameters.Add(nazivPolaska);
                    komanda.Parameters.Add(nazivDestinacije);
                    komanda.Parameters.Add(polazak);
                    komanda.Parameters.Add(dolazak);

                    komanda.ExecuteNonQuery();
                    komanda.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obaveštenje!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
