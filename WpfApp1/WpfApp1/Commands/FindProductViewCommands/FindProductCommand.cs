using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.ViewModel;


namespace WpfApp1.Commands.FindProductViewCommands
{
    public class FindProductCommand : BaseCommand
    {
        private readonly FindProductViewModel _findProductViewModel;
        public FindProductCommand(FindProductViewModel findProductView)
        {
            _findProductViewModel = findProductView;
        }
        public override void Execute(object parameter)
        {
            if (_findProductViewModel.ProductToFind.product_name != "" && _findProductViewModel.ProductToFind.product_name != null)
            {
                using (var resource = new PharmacyAppDataBaseEntities())
                {
                    List<Product> products = resource.Product.ToList();
                   

                    var searchProduct = products.Where(o => o.product_name == _findProductViewModel.ProductToFind.product_name);

                   
                    _findProductViewModel.ListOfProducts = new ObservableCollection<Product>(searchProduct);

                    
                }
            }
            else
            {
                _findProductViewModel.LoadProductsCommand.Execute(0);
            }
        }
    }
}
