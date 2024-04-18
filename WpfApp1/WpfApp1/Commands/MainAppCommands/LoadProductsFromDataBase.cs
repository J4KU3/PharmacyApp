using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.MainAppCommands
{
   public class LoadProductsFromDataBase:BaseCommand
    {

        private readonly MainAppPanelViewModel _loginViewModel;
        public LoadProductsFromDataBase(MainAppPanelViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new PharmacyAppDataBaseEntities())
            {


                List<Product> ProductsList = resource.Product.ToList();
                _loginViewModel.ListOfProducts = new ObservableCollection<Product>(ProductsList);
            }
        }
    }
}
