using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Commands.Navigations;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {


        protected void ApplicationStart(object sender, StartupEventArgs args)
        {
            var loginView = new LoginView();
            var loginViewModel = new MainViewModel();
            loginView.DataContext = loginViewModel;
            loginView.Show();




        }

    }
}
