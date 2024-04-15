using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel _loginViewModel;
       
        
        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
           
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            
            if (_loginViewModel.LoginUser.UserName != null && _loginViewModel.LoginUser.UserPassword != null)
            {

                using (var Employees = new PharmacyAppDataBaseEntities())
                {
                    var employeMail = _loginViewModel.LoginUser.UserName;
                    var employePass = _loginViewModel.LoginUser.UserPassword;
                    var found = _loginViewModel.ListOfUsers.FirstOrDefault(x => x.UserName == employeMail && x.UserPassword == employePass);
                    if (found != null)
                    {
                        _loginViewModel.IsViewVisible = false;
                    }
                    else
                    {
                        
                        _loginViewModel.IsViewVisible = true;
                        MessageBox.Show("zostały podane błędne dane");
                    }
                   
                }
            }


        }
    }
}
