using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.View;
using WpfApp1.ViewModel;
using WpfApp1.Data;

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

            
                switch (parameter as string)
                {
                    case "1":
                    if (_mainViewModel.IsAdmin!=false)
                    {
                        _mainViewModel.CurrentView = new AdminPanelViewModel();
                    }
                    else
                    {
                        _mainViewModel.CurrentView = new HomeViewModel();
                    }

                        break;
                    case "2":
                        _mainViewModel.CurrentView = new MainAppPanelViewModel();

                        break;
                     case "3":
                    _mainViewModel.CurrentView = new HomeViewModel();

                         break;
                    case "4":
                    _mainViewModel.CurrentView = new FindProductViewModel();

                    break;
                default:
                        break;
                }
            
            
        }
    
    }
}
