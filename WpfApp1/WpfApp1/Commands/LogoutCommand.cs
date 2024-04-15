using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands
{
    public class LogoutCommand : BaseCommand
    {
        private readonly MainViewModel _mainviewModel;
        private readonly LoginViewModel _loginViewModel;

        public LogoutCommand(LoginViewModel loginViewModel, MainViewModel mainViewModel)
        {
            _loginViewModel = loginViewModel;
            _mainviewModel = mainViewModel;
        }
        
        
        public override void Execute(object parameter)
        {
            var mainView = new MainView();
            var loginView = new LoginView();
            _mainviewModel.closeWindowCommand.Execute(1);

            _loginViewModel.IsViewVisible = true;




        }
    }
}
