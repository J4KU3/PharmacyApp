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
    public class DeleteProduct:BaseCommand
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;
        
        public DeleteProduct(AdminPanelViewModel adminPanelViewModel)
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
                var ProductToDelete = resource.Product.FirstOrDefault(x => x.product_id == _adminPanelViewModel.SelectedProduct.product_id);
                if (ProductToDelete != null)
                {
                        resource.Product.Remove(ProductToDelete);
                        resource.SaveChanges();
                        _adminPanelViewModel.LoadProductsCommand.Execute(0);
                    
                }
                else
                {
                    MessageBox.Show("Chose Product");
                }
            }
           
        }
    }
}
