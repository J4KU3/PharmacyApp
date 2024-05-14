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
using WpfApp1.Data;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        //Views
        
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
        public ExitCommand exitCommand { get; }
        public NavigationCommand navigationCommand { get; }

        #region From LoginViewmodel just for tests
        public LoginCommand loginCommand { get; }
        public LoadUsers loadUsersFromData { get; }

        //listy
        private ObservableCollection<Users> _listOfUsers = new ObservableCollection<Users>();

        public ObservableCollection<Users> ListOfUsers
        {
            get
            {
                return _listOfUsers;
            }
            set
            {
                _listOfUsers = value;
                loadUsersFromData.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
      


        //zmienne 


        private Users _user;
        public Users LoginUser
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //Construktor 
        public MainViewModel()
        {
            CurrentView = new HomeViewModel();
           
            navigationCommand = new NavigationCommand(this);
            exitCommand = new ExitCommand(this);
            
            logoutCommand = new LogoutCommand(this);


            //from loginViewModel
            loginCommand = new LoginCommand(this);
            loadUsersFromData = new LoadUsers(this);
            loadUsersFromData.Execute(0);
            _user = new Users();
            
            closeWindowCommand = new CloseWindowCommand(Application.Current.Windows.OfType<LoginView>().FirstOrDefault());
            
        }


    }
}
