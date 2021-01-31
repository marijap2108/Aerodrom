using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using System.Windows.Shapes;

namespace Aerodrom.Windows
{
    public partial class Profile : Window
    {
        string id;
        string currentEmail;
        bool isOwner;

        public Profile(User user)
        {
            InitializeComponent();
            Ime.Text = user.Ime;
            Prezime.Text = user.Prezime;
            Jmbg.Text = user.Jmbg;
            Email.Text = user.Email;
            Kontakt.Text = user.Kontakt;
            currentEmail = user.Email; 
            id = user.Id.ToString();
            isOwner = user.isOWner;
        }

        private void Sačuvaj_Click(object sender, RoutedEventArgs e)
        {
            string ime = Ime.Text;
            string prezime = Prezime.Text;
            string JMBG = Jmbg.Text;
            string email = Email.Text;
            string kontakt = Kontakt.Text;
            string password = Password.Password;
            string confirmPassword = ConfirmPassword.Password;

            if (email.Length > 0)
            {
                try
                {
                    MailAddress m = new MailAddress(email);
                }
                catch (FormatException)
                {
                    EmailError.Content = "Nesispravan email!";
                    return;
                }
                if (email.Equals(currentEmail))
                {
                    email = "";
                }
            }

            if (password.Length > 0) 
            {
                if (password.Length < 8)
                {
                    PasswordError.Content = "Password mora imati minimalno 8 karaktera!";
                    return;
                }

                if (password != confirmPassword)
                {
                    ConfirmPasswordError.Content = "Confirm password mora biti isti kao password!";
                    return;
                }
            }

            if (ime == null || ime == "")
            {
                ImeError.Content = "Morate popuniti polje sa imenom!";
                return;
            }

            if (prezime == null || prezime == "")
            {
                PrezimeError.Content = "Morate popuniti polje sa prezimenom!";
                return;
            }

            if (JMBG == null || JMBG.Length != 13)
            {
                JmbgError.Content = "Neispravano JMBG polje!";
                return;
            }


            User user = new User();
            if (user.UpdateUser(ime, prezime, JMBG, kontakt, email, password, id, isOwner))
            {
                user.GetUserByID(Int32.Parse(id), isOwner);
                Window.GetWindow(this).Close();
                return;
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Ime_KeyDown(object sender, KeyEventArgs e)
        {
            ImeError.Content = "";
        }

        private void Prezime_KeyDown(object sender, KeyEventArgs e)
        {
            PrezimeError.Content = "";
        }

        private void JMBG_KeyDown(object sender, KeyEventArgs e)
        {
            JmbgError.Content = "";
        }

        private void Kontakt_KeyDown(object sender, KeyEventArgs e)
        {
            KontaktError.Content = "";
        }

        private void Email_KeyDown(object sender, KeyEventArgs e)
        {
            EmailError.Content = "";
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            PasswordError.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
