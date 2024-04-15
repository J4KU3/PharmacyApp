using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.View;
using WpfApp1.Commands.Navigations;
using WpfApp1.Commands;
using System.Windows;

namespace WpfApp1.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        //Views
        private readonly LoginViewModel loginViewModel;
        //Propertis
        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }


        //lists

        //Commands
        public LogoutCommand logoutCommand { get; }
        public CloseWindowCommand closeWindowCommand { get; }
        public NavigationCommand navigationCommand { get; }

        //Construktor 
        public MainViewModel()
        {
            loginViewModel = new LoginViewModel();
            navigationCommand = new NavigationCommand(this);
            closeWindowCommand = new CloseWindowCommand(Application.Current.Windows.OfType<MainView>().FirstOrDefault());
            logoutCommand = new LogoutCommand(loginViewModel,this);
        }


    }
}
