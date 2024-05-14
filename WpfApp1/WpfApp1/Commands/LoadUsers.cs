using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands
{
    public class LoadUsers : BaseCommand
    {
        private readonly MainViewModel _loginViewModel;
        public LoadUsers(MainViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new PharmacyAppDataBaseEntities())
            {
                

                List<Users> employeesList = resource.Users.ToList();
                _loginViewModel.ListOfUsers = new ObservableCollection<Users>(employeesList);
            }
        }
    }
}
