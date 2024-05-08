using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Commands.Navigations;
using WpfApp1.Commands.MainAppCommands;
using System.Collections.ObjectModel;
using WpfApp1.Data;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    public class MainAppPanelViewModel : BaseViewModel
    {
        
        
        //Commands
        public ShowNumberCommand showNumberCommand { get; }
        public ClearCommand clearCommand { get; }
        public AddToListCommand addToListCommand { get; }
        public ClearOneCommand clearOneCommand { get; }
        public DeleteProductFromListCommand deleteProductFromListCommand { get; }
        //Properties

        private string _screenValue;
        public string ScreenValue
        {
            get
            {
                return _screenValue;
            }
            set
            {
                _screenValue = value;
                showNumberCommand.OnCanExecuteChanged();
                clearCommand.OnCanExecuteChanged();
                clearOneCommand.OnCanExecuteChanged();
                addToListCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        private decimal _priceSUM;
        public decimal PriceSum
        {
            get
            {
                return _priceSUM;
            }
            set
            {
                _priceSUM = value;
                OnPropertyChanged();
            }
        }
        private int _productquantity;
        public int ProductQuantity
        {
            get
            {
                return _productquantity;
            }
            set
            {
                _productquantity = value;
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
                OnPropertyChanged();
            }
        }

        //lists
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
        private ObservableCollection<Product> _listOfAddProduct = new ObservableCollection<Product>();
        public ObservableCollection<Product> ListOfAddProduct
        {
            get
            {
                return _listOfAddProduct;
            }
            set
            {
                _listOfAddProduct = value;
                addToListCommand.OnCanExecuteChanged();
                OnPropertyChanged();

            }
        }

        public ICommand LoadProductsCommand => new RelayCommand(LoadProducts);

        private void LoadProducts()
        {
            using (var context = new PharmacyAppDataBaseEntities())
            {
                ListOfProducts = new ObservableCollection<Product>(context.Product.ToList());
            }
        }
        public MainAppPanelViewModel()
        {
            _selectedProduct = new Product();
            showNumberCommand = new ShowNumberCommand(this);
            clearCommand = new ClearCommand(this);
            clearOneCommand = new ClearOneCommand(this);
            LoadProductsCommand.Execute(0);
            addToListCommand = new AddToListCommand(this);
            deleteProductFromListCommand = new DeleteProductFromListCommand(this);
        }


    }
}
