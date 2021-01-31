using Aerodrom.Pages;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aerodrom
{
    public partial class MainWindow : Window
    {

        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        User user;

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            _NavigationFrame.Navigate(new PocetnaStrana());
        }

        public void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
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
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspešno učitani podaci!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LLButton_Click(object sender, RoutedEventArgs e)
        {
            Naslov.Content = "Lista letova";
            _NavigationFrame.Navigate(new ListaLetova(user));
        }

        private void IButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da izađete?", "Izađi", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rezultat == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn signUp = new LogIn();
            signUp.Show();
        }

        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(user);
            profile.Show();
        }

        private void OpenPackage(object sender, RoutedEventArgs e)
        {
            Naslov.Content = "Lista paketa";
            _NavigationFrame.Navigate(new PackageList(user.Id, user.isOWner));

        }

        private void OpenZakup(object sender, RoutedEventArgs e)
        {
            Naslov.Content = "Lista zakupa";
            _NavigationFrame.Navigate(new ZakupLista(user.Id, user.isOWner));
        }


        public void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.user = null;
            SignUpButton.Content = "Sign Up";
            Menu.Children.RemoveAt(2);
            Menu.Children.RemoveAt(2);
            Menu.Children.RemoveAt(2);
            SignUpButton.Click += new RoutedEventHandler(SignUpButton_Click);
            SignUpButton.Click -= new RoutedEventHandler(SignOutButton_Click);
            _NavigationFrame.Navigate(new PocetnaStrana());
        }

        public void SetCurrentUser(User user)
        {
            if (Menu.Children.Count > 3)
            {
                return;
            }

            Button paket = new Button
            {
                Content = "Paket",
                Name = "Paket",
                Height = 60,
                Background = null,
                BorderBrush = null,
                Foreground = new SolidColorBrush(Color.FromRgb(199, 199, 199))
            };
            paket.Click += new RoutedEventHandler(OpenPackage);


            Button hangar = new Button
            {
                Content = "Zakup",
                Name = "Zakup",
                Height = 60,
                Background = null,
                BorderBrush = null,
                Foreground = new SolidColorBrush(Color.FromRgb(199, 199, 199))
            };
            hangar.Click += new RoutedEventHandler(OpenZakup);


            Button profil = new Button
            {
                Content = "Profil",
                Name = "Profil",
                Height = 60,
                Background = null,
                BorderBrush = null,
                Foreground = new SolidColorBrush(Color.FromRgb(199, 199, 199))
            };
            profil.Click += new RoutedEventHandler(OpenProfile);

            Menu.Children.Insert(2, paket);
            Menu.Children.Insert(3, hangar);
            Menu.Children.Insert(4, profil);

            this.user = user;
            SignUpButton.Content = "Sign Out";
            SignUpButton.Click -= new RoutedEventHandler(SignUpButton_Click);
            SignUpButton.Click += new RoutedEventHandler(SignOutButton_Click);
        }

        private void PSButton_Click(object sender, RoutedEventArgs e)
        {
            Naslov.Content = "Početna strana";
            _NavigationFrame.Navigate(new PocetnaStrana());
        }

        private void _NavigationFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.7);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            ta.From = new Thickness(300, 300, 300, 300);
            (e.Content as Page).BeginAnimation(MarginProperty, ta);
        }
    }
}
