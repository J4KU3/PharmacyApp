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
        
        public ClearOneCommand clearOneCommand { get; }
        //Properties
        

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
           
            showNumberCommand = new ShowNumberCommand(this);
            clearCommand = new ClearCommand(this);
            clearOneCommand = new ClearOneCommand(this);
            LoadProductsCommand.Execute(0);

        }


    }
}
