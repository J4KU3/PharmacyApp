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

namespace WpfApp1.ViewModel
{
    public class AdminPanelViewModel:BaseViewModel
    {
       
        

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
        private void LoadProducts()
        {
            using (var context = new PharmacyAppDataBaseEntities())
            {
                List<Product> productList = context.Product.ToList();
                ListOfProducts = new ObservableCollection<Product>(productList);
               
            }
        }
        public RelayCommand LoadProductsCommand { get; private set; }
        public AdminPanelViewModel()
        {
            LoadProductsCommand = new RelayCommand(LoadProducts);
            LoadProducts();
           
            
        }
    }
}
