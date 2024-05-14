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
        private readonly MainViewModel _mainViewModel;
       

        public LoginCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            
            if (_mainViewModel.LoginUser.UserName != null && _mainViewModel.LoginUser.UserPassword != null)
            {

                using (var Employees = new PharmacyAppDataBaseEntities())
                {
                    var employeMail = _mainViewModel.LoginUser.UserName;
                    var employePass = _mainViewModel.LoginUser.UserPassword;
                   
                    var found = _mainViewModel.ListOfUsers.FirstOrDefault(x => x.UserName == employeMail && x.UserPassword == employePass);
                   
                    if (found != null)
                    {
                        var admin = found.IsAdmin.GetValueOrDefault();
                        _mainViewModel.IsAdmin = admin;

                        // Ustawienie właściwego widoku po zalogowaniu
                        _mainViewModel.CurrentView = new HomeViewModel();

                        var mainWindow = new MainView();
                        mainWindow.DataContext = _mainViewModel;
                        mainWindow.Show();


                        _mainViewModel.closeWindowCommand.Execute(0);
                    }
                    else
                    {
                        
                        
                        MessageBox.Show("zostały podane błędne dane");
                    }
                   
                }
            }


        }
    }
}
