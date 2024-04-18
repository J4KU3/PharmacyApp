using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Commands.Navigations;
using WpfApp1.Commands.MainAppCommands;
using System.Collections.ObjectModel;
using WpfApp1.Data;

namespace WpfApp1.ViewModel
{
    public class MainAppPanelViewModel : BaseViewModel
    {
        //Commands
        public ShowNumberCommand showNumberCommand { get; }
        public ClearCommand clearCommand { get; }
        public LoadProductsFromDataBase loadProductsFromDataBase {get;}
        public ClearOneCommand clearOneCommand { get; }
        //Properties
        private string _screenValue;

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
                 loadProductsFromDataBase.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
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


        public MainAppPanelViewModel()
        {
            showNumberCommand = new ShowNumberCommand(this);
            clearCommand = new ClearCommand(this);
            clearOneCommand = new ClearOneCommand(this);
            loadProductsFromDataBase = new LoadProductsFromDataBase(this);
        }

       
    }
}
