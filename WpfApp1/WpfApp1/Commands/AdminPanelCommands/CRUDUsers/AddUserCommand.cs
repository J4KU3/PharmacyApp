using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.AdminPanelCommands.CRUDProduct
{
   public class AddUserCommand:BaseCommand
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;
        public AddUserCommand(AdminPanelViewModel adminPanelViewModel)
        {
            _adminPanelViewModel = adminPanelViewModel;
        }
       
        public override void Execute(object parameter)
        {
            using (var resource = new PharmacyAppDataBaseEntities())
            {
                var newUserToAdd = new Users();
                var UserFromUI = _adminPanelViewModel.NewUser;
                if (UserFromUI.UserName != null && UserFromUI.FName != null && UserFromUI.LName != null && UserFromUI.UserPassword != null && UserFromUI.PhoneNumer != null)
                {

                    newUserToAdd.UserName = UserFromUI.UserName;
                    newUserToAdd.FName = UserFromUI.FName;
                    newUserToAdd.LName = UserFromUI.LName;
                    newUserToAdd.PhoneNumer = UserFromUI.PhoneNumer;
                    newUserToAdd.UserPassword = UserFromUI.UserPassword;
                    newUserToAdd.IsAdmin = false;
                    resource.Users.Add(newUserToAdd);
                    resource.SaveChanges();
                    UserFromUI.UserName = null;
                    UserFromUI.FName = null;
                    UserFromUI.LName = null;
                    UserFromUI.PhoneNumer = null;
                    UserFromUI.UserPassword = null;
                    _adminPanelViewModel.LoadUsersCommand.Execute(0);
                    _adminPanelViewModel.navigationForAdminPanel.Execute("1");
                }
                else
                {
                    MessageBox.Show("Error");
                    UserFromUI.UserName = null;
                    UserFromUI.FName = null;
                    UserFromUI.LName = null;
                    UserFromUI.PhoneNumer = null;
                    UserFromUI.UserPassword = null;
                }




            }
        }
    }
}
