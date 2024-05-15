using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;
using WpfApp1.Data;
using System.Windows;

namespace WpfApp1.Commands.AdminPanelCommands.CRUDProduct
{
  public class EditProduct:BaseCommand
  {
        private readonly AdminPanelViewModel _adminPanelViewModel;

        public EditProduct(AdminPanelViewModel adminPanelViewModel)
        {
            _adminPanelViewModel = adminPanelViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _adminPanelViewModel.SelectedProduct != null;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new PharmacyAppDataBaseEntities())
            {
                var ProductToEdit = resource.Product.FirstOrDefault(x => x.product_id == _adminPanelViewModel.SelectedProduct.product_id);
               
                    var Editedproduct = _adminPanelViewModel.SelectedProduct;
                    ProductToEdit.product_name = Editedproduct.product_name;
                    ProductToEdit.product_price = Editedproduct.product_price;
                    ProductToEdit.product_quantity = Editedproduct.product_quantity;
                  
                    resource.SaveChanges();
                    _adminPanelViewModel.LoadProductsCommand.Execute(0);
                    _adminPanelViewModel.SelectedProduct = null;


            }
        }
    }
}
