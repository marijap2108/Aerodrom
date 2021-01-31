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
    public partial class PackageList : Page
    {
        #region Select upiti
        static string paketSelect = @"Select PaketID as ID, NazivPaketa, NazivDestinacije, VremeIDatumPolaska from tblPaket, tblLet where tblPaket.LetID = tblLet.LetID and tblPaket.KorisnikID = @userId";
        static string paketSelectAll = @"Select PaketID as ID, NazivPaketa, NazivDestinacije, VremeIDatumPolaska from tblPaket, tblLet where tblPaket.LetID = tblLet.LetID";
        string delete = @"Delete from tblPaket where PaketID=";
        #endregion

        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        static int currentUserId;
        bool isOwner;

        public PackageList(int userId, bool owner)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            currentUserId = userId;
            isOwner = owner;

            if (isOwner)
            {
                UcitajPodatke(PackageListGrid, paketSelectAll);
                Paket.Visibility = Visibility.Collapsed;
            }
            else
            {
                UcitajPodatke(PackageListGrid, paketSelect);
            }

        }

        public void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            konekcija.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
            if (!isOwner)
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@userId", currentUserId);
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

        private void Paket_Click(object sender, RoutedEventArgs e)
        {
            PackageWindow package = new PackageWindow(currentUserId, Refresh);
            package.Show();

        }

        private void Otkaži_Click(object sender, RoutedEventArgs e)
        {
            Otkazi(PackageListGrid);
            if (isOwner)
            {
                UcitajPodatke(PackageListGrid, paketSelectAll);
            }
            else
            {
                UcitajPodatke(PackageListGrid, paketSelect);
            }
        }

        public void Refresh()
        {
            if (isOwner)
            {
                UcitajPodatke(PackageListGrid, paketSelectAll);
            }
            else
            {
                UcitajPodatke(PackageListGrid, paketSelect);
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
                    komanda.CommandText = delete + "@id";
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
