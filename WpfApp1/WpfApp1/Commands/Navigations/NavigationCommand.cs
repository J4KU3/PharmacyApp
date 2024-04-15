using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.Navigations
{
   public class NavigationCommand:BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public NavigationCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            
            // App.Current.Shutdown();

            switch (parameter as string)
            {
                case "1":
                    _mainViewModel.CurrentView = new AdminPanelViewModel();
                    

                    break;
                case "2":

                    _mainViewModel.CurrentView = new MainAppPanelViewModel();
                    
                    break;
                default:
                    break;
            }
        }
    }
}
