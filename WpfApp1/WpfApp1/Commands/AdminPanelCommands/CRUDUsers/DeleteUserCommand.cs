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
    public class DeleteUserCommand:BaseCommand
    {
        private readonly AdminPanelViewModel _viewModel;
        public DeleteUserCommand(AdminPanelViewModel adminPanelViewModel)
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
                var UserToDelete = resource.Users.FirstOrDefault(x => x.IDUser == _viewModel.SelectedUser.IDUser);
                if (UserToDelete != null)
                {
                  
                    if (UserToDelete.UserName == "Admin")
                    {
                        MessageBox.Show("Access denied");
                        UserToDelete = null;
                    }
                    else
                    {
                        resource.Users.Remove(UserToDelete);
                        resource.SaveChanges();
                        _viewModel.LoadUsersCommand.Execute(0);
                    }
                }
                else
                {
                    MessageBox.Show("Chose User");
                }



            }



        }
        
    }
}
