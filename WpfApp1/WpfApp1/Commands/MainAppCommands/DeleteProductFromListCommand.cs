using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.MainAppCommands
{
    public class DeleteProductFromListCommand:BaseCommand
    {
        private readonly MainAppPanelViewModel _mainAppPanelViewModel;
        public DeleteProductFromListCommand(MainAppPanelViewModel mainAppPanelViewModel)
        {
            _mainAppPanelViewModel = mainAppPanelViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _mainAppPanelViewModel.SelectedProduct!=null;
        }

        public override void Execute(object parameter)
        {
            var ItemToDelete = _mainAppPanelViewModel.SelectedProduct;
            _mainAppPanelViewModel.ListOfAddProduct.Remove(ItemToDelete);
            _mainAppPanelViewModel.PriceSum -= Convert.ToDecimal(string.Format("{0:0.00}", ItemToDelete.product_price)); 

        }
    }
}
