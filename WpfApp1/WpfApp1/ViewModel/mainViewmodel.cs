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
        private bool _isAdmin;
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }
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
            CurrentView = new HomeViewModel();
           
            navigationCommand = new NavigationCommand(this);
            closeWindowCommand = new CloseWindowCommand(this);
            logoutCommand = new LogoutCommand(this);
        }


    }
}
