using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Commands.FindProductViewCommands;

namespace WpfApp1.ViewModel
{
    public class FindProductViewModel:BaseViewModel
    {
        //Properties
        private Product _productToFind;
        public Product ProductToFind
        {
            get
            {
                return _productToFind;
            }
            set
            {
                _productToFind = value;
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

        //Commands
        private void LoadProducts()
        {
            using (var context = new PharmacyAppDataBaseEntities())
            {
                List<Product> productList = context.Product.ToList();
                ListOfProducts = new ObservableCollection<Product>(productList);



            }
        }
        public RelayCommand LoadProductsCommand { get; private set; }
        public FindProductCommand findProductCommand { get; }


        public FindProductViewModel()
        {
            _productToFind = new Product();
            LoadProductsCommand = new RelayCommand(LoadProducts);
            LoadProducts();
            findProductCommand = new FindProductCommand(this);

        }
    }
}
