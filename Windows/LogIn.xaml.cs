using Aerodrom.Pages;
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
    public partial class LogIn : Window
    {
        static bool singIn = true;
        public LogIn()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new SignIn());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (singIn) 
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    _NavigationFrame.Navigate(new SignUp(true, Redirect));
                }
                else
                {
                    _NavigationFrame.Navigate(new SignUp(false, Redirect));
                }
                Button.Content = "Sign In";
                this.Height = 780;
                singIn = false;
            } 
            else 
            {
                _NavigationFrame.Navigate(new SignIn());
                Button.Content = "Sign Up";
                this.Height = 400;
                singIn = true;
            }
        }

        private void Redirect()
        {
            _NavigationFrame.Navigate(new SignIn());
            Button.Content = "Sign Up";
            this.Height = 400;
            singIn = true;
        } 
    }
}
