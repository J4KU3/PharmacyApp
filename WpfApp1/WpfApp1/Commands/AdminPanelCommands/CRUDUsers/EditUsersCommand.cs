using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;
using WpfApp1.Data;
using System.Windows;

namespace WpfApp1.Commands.AdminPanelCommands.CRUDUsers
{
   public class EditUsersCommand:BaseCommand
    {
        private readonly AdminPanelViewModel _viewModel;
        public EditUsersCommand(AdminPanelViewModel adminPanelViewModel)
        {
            _viewModel = adminPanelViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUser != null;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new PharmacyAppDataBaseEntities())
            {
                var UserToEdit = resource.Users.FirstOrDefault(x=>x.IDUser == _viewModel.SelectedUser.IDUser);
                if (UserToEdit.UserName == "Admin")
                {
                    MessageBox.Show("Access Denied");
                    _viewModel.SelectedUser = null;
                    _viewModel.LoadUsersCommand.Execute(0);
                }
                else
                {
                    var EditedUser = _viewModel.SelectedUser;
                    UserToEdit.FName = EditedUser.FName;
                    UserToEdit.LName = EditedUser.LName;
                    UserToEdit.PhoneNumer = EditedUser.PhoneNumer;
                    UserToEdit.UserName = EditedUser.UserName;
                    UserToEdit.UserPassword = EditedUser.UserPassword;
                    UserToEdit.IsAdmin = EditedUser.IsAdmin;
                    resource.SaveChanges();
                    _viewModel.LoadUsersCommand.Execute(0);
                }
                

            }
        }
    }
}
