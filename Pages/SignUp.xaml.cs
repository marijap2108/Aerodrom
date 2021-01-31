using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aerodrom.Pages
{
    public partial class SignUp : Page
    {
        private bool isOwner;
        private Action Redirect;

        public SignUp(bool isOwnerSignUp, Action redirect)
        {
            InitializeComponent();
            isOwner = isOwnerSignUp;
            Redirect = redirect;

            if (isOwnerSignUp)
            {
                SignUpLabel.Content = "Sign Up zaposlenog";
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string ime = Ime.Text;
            string prezime = Prezime.Text;
            string JMBG = Jmbg.Text;
            string email = Email.Text;
            string kontakt = Kontakt.Text;
            string password = Password.Password;

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
                JMBGError.Content = "Neispravano JMBG polje!";
                return;
            }

            if (email == null || email == "")
            {
                EmailError.Content = "Morate popuniti email polje!";
                return;
            }

            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch (FormatException)
            {
                EmailError.Content = "Nesispravan email!";
                return;
            }


            if (password == null || password.Length < 8)
            {
                PasswordError.Content = "Password mora imati minimalno 8 karaktera!";
                return;
            }

            User user = new User();
            if (user.SetUser(ime, prezime, JMBG, kontakt, email, password, isOwner))
            {
                Redirect();
                return;
            }

            EmailError.Content = "Email postoji u bazi podataka!";
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
            JMBGError.Content = "";
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
    }
}
