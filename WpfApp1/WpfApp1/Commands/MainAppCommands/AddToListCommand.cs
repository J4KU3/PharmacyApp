using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.MainAppCommands
{
   public class AddToListCommand:BaseCommand
    {
        private readonly MainAppPanelViewModel _mainAppPanelViewModel;

        public AddToListCommand(MainAppPanelViewModel mainAppPanelViewModel)
        {
            _mainAppPanelViewModel = mainAppPanelViewModel;
        }

        public override void Execute(object parameter)
        {
            int product = int.Parse(_mainAppPanelViewModel.ScreenValue);

           
            using (var resource = new PharmacyAppDataBaseEntities())
            {
             
                var foud = _mainAppPanelViewModel.ListOfProducts.FirstOrDefault(x=>x.product_id == product);
                if (foud == null)
                {
                    MessageBox.Show("Nie znaleziono takiego produktu");
                }
                else
                {
                    _mainAppPanelViewModel.ListOfAddProduct.Add(foud);
                    _mainAppPanelViewModel.PriceSum += foud.product_price;
                }
                
                _mainAppPanelViewModel.clearCommand.Execute(0);
            }
        }
    }
}
