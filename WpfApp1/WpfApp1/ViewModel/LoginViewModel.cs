using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Commands;
using WpfApp1.Data;
using WpfApp1.View;

namespace WpfApp1.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        //Views
        
        //komendy
        public LoginCommand loginCommand { get;  }
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
        private bool _isViewVisible;
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                loginCommand.OnCanExecuteChanged();
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







        public LoginViewModel()
        {
            
            loginCommand = new LoginCommand(this);
            loadUsersFromData = new LoadUsers(this);
            loadUsersFromData.Execute(0);
            _user = new Users();
            
        }
    }
}
