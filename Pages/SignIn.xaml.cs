using Aerodrom.Windows;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SingIn_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl)) {
                handleSignIn(true);
            } else
            {
                handleSignIn(false);
            }
        }

        private void handleSignIn(bool isUser)
        {
            string email = Email.Text;
            string password = Password.Password;

            if (email == null || email == "")
            {
                EmailError.Content = "Morate popuniti email polje!";
                return;
            }

            if (password == null || password == "")
            {
                PasswordError.Content = "Morate popuniti password polje!";
                return;
            }

            User user = new User();
            string code = user.GetUser(email, password, isUser);
            switch (code)
            {
                case "Password_Error":
                    Password.Password = "";
                    PasswordError.Content = "Pogresan password!";
                    return;
                case "Email_Error":
                    Email.Text = "";
                    EmailError.Content = "Email ne postoji u bazi podataka!";
                    return;
                default:
                    Window.GetWindow(this).Close();
                    return;
            }
        }

        private void Email_KeyDown(object sender, KeyEventArgs e)
        {
            EmailError.Content = "";
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            PasswordError.Content = "";
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    handleSignIn(true);
                }
                else
                {
                    handleSignIn(false);
                }
            }
        }
    }
}
