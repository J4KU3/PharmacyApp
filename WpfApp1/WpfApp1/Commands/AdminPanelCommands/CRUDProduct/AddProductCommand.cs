using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.AdminPanelCommands.CRUDProduct
{
    public class AddProductCommand : BaseCommand
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;

        public AddProductCommand(AdminPanelViewModel adminPanelViewModel)
        {
            _adminPanelViewModel = adminPanelViewModel;
        }

        public override void Execute(object parameter)
        {
            byte[] imageBytes = File.ReadAllBytes(_adminPanelViewModel.ImageLocation);
            using (var resource = new PharmacyAppDataBaseEntities())
            {
                var newProductToAdd = new Product();
                var ProductFromUI = _adminPanelViewModel.NewProduct;
                if (ProductFromUI.product_name != null && ProductFromUI.product_quantity != null && _adminPanelViewModel.SelectedCategory != null && _adminPanelViewModel.ImageLocation != null)
                {

                    newProductToAdd.product_name = ProductFromUI.product_name;
                    newProductToAdd.product_price = ProductFromUI.product_price;
                    newProductToAdd.product_quantity = ProductFromUI.product_quantity;
                    newProductToAdd.category_id = _adminPanelViewModel.SelectedCategory.category_id;
                    newProductToAdd.product_img = imageBytes;




                    resource.Product.Add(newProductToAdd);
                    resource.SaveChanges();

                    ProductFromUI.product_name = null;
                    ProductFromUI.product_price = 0;
                    ProductFromUI.product_quantity = null;
                    ProductFromUI.product_img = null;
                    ProductFromUI.category_id = 0;
                    _adminPanelViewModel.SelectedCategory = null;
                    _adminPanelViewModel.ImageLocation = null;
                    _adminPanelViewModel.LoadProductsCommand.Execute(0);
                    _adminPanelViewModel.navigationForAdminPanel.Execute("2");
                }
                else
                {
                    MessageBox.Show("Error");
                    ProductFromUI.product_name = null;
                    ProductFromUI.product_price = 0;
                    ProductFromUI.product_quantity = null;
                    ProductFromUI.product_img = null;
                    ProductFromUI.category_id = 0;
                    _adminPanelViewModel.SelectedCategory = null;
                    _adminPanelViewModel.ImageLocation = null;
                }

            }
        }
    }
}
