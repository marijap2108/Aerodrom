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
    public partial class ZakupLista : Page
    {
        #region Select upiti
        static string pistaSelect = @"Select ZakupID as ID, NazivPiste, PocetakZakupa, KrajZakupa from tblZakup join tblPista on tblZakup.ObjekatID = tblPista.PistaID where tblZakup.TipObjektaID = @objectId and tblZakup.KorisnikID = @userId";
        static string pistaSelectAll = @"Select ZakupID as ID, NazivPiste, PocetakZakupa, KrajZakupa from tblZakup join tblPista on tblZakup.ObjekatID = tblPista.PistaID where tblZakup.TipObjektaID = @objectId";
        static string hangarSelect = @"Select ZakupID as ID, NazivHangara, PocetakZakupa, KrajZakupa from tblZakup join tblHangar on tblZakup.ObjekatID = tblHangar.HangarID where tblZakup.TipObjektaID = @objectId and tblZakup.KorisnikID = @userId";
        static string hangarSelectAll = @"Select ZakupID as ID, NazivHangara, PocetakZakupa, KrajZakupa from tblZakup join tblHangar on tblZakup.ObjekatID = tblHangar.HangarID where tblZakup.TipObjektaID = @objectId";
        string delete = @"Delete from tblZakup where zakupID=";
        #endregion

        ObjectType[] objectTypes;
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        static int currentUserId;
        static int objectId;
        string currentObject;
        bool isOwner;

        public ZakupLista(int userId, bool owner)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            currentUserId = userId;
            ObjectType objectType = new ObjectType();
            objectTypes = objectType.GetObjectType();
            isOwner = owner;
            
            foreach (ObjectType data in objectTypes)
            {
                TipObjekta.Items.Add(data.Naziv);
            }
        }

        public void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            konekcija.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@objectId", objectId);
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

        private void Zakup(object sender, RoutedEventArgs e)
        {
            if (currentObject.Equals("Hangar"))
            {
                HangarZakup hangar = new HangarZakup(currentUserId, objectId, Refresh);
                hangar.Show();
            }
            else
            {
                PistaZakup pista = new PistaZakup(currentUserId, objectId, Refresh);
                pista.Show();
            }
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            Otkazi(ZakupDataGrid);
            Refresh();
        }

        public void Refresh()
        {
            if (currentObject.Equals("Hangar"))
            {
                if (isOwner)
                {
                    UcitajPodatke(ZakupDataGrid, hangarSelectAll);
                }
                else
                {
                    UcitajPodatke(ZakupDataGrid, hangarSelect);
                }
            }
            else
            {
                if (isOwner)
                {
                    UcitajPodatke(ZakupDataGrid, pistaSelectAll);
                }
                else
                {
                    UcitajPodatke(ZakupDataGrid, pistaSelect);
                }
            }
        }

        private void TipObjekta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaOpcija.Children.Count < 3)
            {
                if (!isOwner)
                {
                    Button zakup = new Button();
                    zakup.Name = "Zakupi";
                    zakup.Content = "Zakupi";
                    zakup.Click += new RoutedEventHandler(Zakup);
                    zakup.Height = 60;
                    zakup.Background = null;
                    zakup.BorderBrush = null;
                    zakup.Foreground = new SolidColorBrush(Color.FromRgb(199, 199, 199));

                    ListaOpcija.Children.Add(zakup);
                }

                Button otkup = new Button();
                otkup.Name = "Otkazi";
                otkup.Content = "Otkazi";
                otkup.Click += new RoutedEventHandler(Otkazi);
                otkup.Height = 60;
                otkup.Background = null;
                otkup.BorderBrush = null;
                otkup.Foreground = new SolidColorBrush(Color.FromRgb(199, 199, 199));

                ListaOpcija.Children.Add(otkup);
            }
            foreach (ObjectType data in objectTypes)
            {
                if (data.Naziv == TipObjekta.SelectedItem.ToString())
                {
                    objectId = data.Id;
                    if (data.Naziv.Equals("Hangar"))
                    {
                        currentObject = "Hangar";

                        if (isOwner)
                        {
                            UcitajPodatke(ZakupDataGrid, hangarSelectAll);
                        }
                        else
                        {
                            UcitajPodatke(ZakupDataGrid, hangarSelect);
                        }
                    } 
                    else
                    {
                        currentObject = "Pista";

                        if (isOwner)
                        {
                            UcitajPodatke(ZakupDataGrid, pistaSelectAll);
                        }
                        else
                        {
                            UcitajPodatke(ZakupDataGrid, pistaSelect);
                        }
                    }
                    return;
                }
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
