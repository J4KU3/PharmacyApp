using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Commands.MainAppCommands;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using WpfApp1.Commands.Navigations;
using WpfApp1.Commands.AdminPanelCommands.CRUDUsers;
using WpfApp1.Commands.AdminPanelCommands.CRUDProduct;

namespace WpfApp1.ViewModel
{
    public class AdminPanelViewModel:BaseViewModel
    {
        //Properties
        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;
                navigationForAdminPanel.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        private Users _selectedUser;
        public Users SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                deleteUserCommand.OnCanExecuteChanged();
                editUsersCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                deleteProduct.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        //Lists
        private ObservableCollection<Product> _listOfProducts = new ObservableCollection<Product>();

        public ObservableCollection<Product> ListOfProducts
        {
            get
            {
                return _listOfProducts;
            }
            set
            {
                _listOfProducts = value;
                OnPropertyChanged(nameof(ListOfProducts));
            }
        }

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
                OnPropertyChanged(nameof(ListOfUsers));
            }
        }
        //Commands
        public NavigationForAdminPanel navigationForAdminPanel { get; }
        public DeleteUserCommand deleteUserCommand { get; }
        public EditUsersCommand editUsersCommand { get; }

        public DeleteProduct deleteProduct { get; }
        private void LoadProducts()
        {
            using (var context = new PharmacyAppDataBaseEntities())
            {
                List<Product> productList = context.Product.ToList();
                ListOfProducts = new ObservableCollection<Product>(productList);
               
            }
        }
        public RelayCommand LoadProductsCommand { get; private set; }
        private void LoadUsers()
        {
            using (var context = new PharmacyAppDataBaseEntities())
            {
                List<Users> UserList = context.Users.ToList();
                ListOfUsers = new ObservableCollection<Users>(UserList);

            }
        }
        public RelayCommand LoadUsersCommand { get; private set; }

        public AdminPanelViewModel()
        {
            
            LoadProductsCommand = new RelayCommand(LoadProducts);
            LoadUsersCommand = new RelayCommand(LoadUsers);
            LoadProducts();
            LoadUsers();
            navigationForAdminPanel = new NavigationForAdminPanel(this);
            deleteUserCommand = new DeleteUserCommand(this);
            editUsersCommand = new EditUsersCommand(this);
            deleteProduct = new DeleteProduct(this);
            
        }
    }
}
