using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.MainAppCommands
{
    public class ClearOneCommand : BaseCommand
    {
        private readonly MainAppPanelViewModel _mainAppPanelViewModel;
        public ClearOneCommand(MainAppPanelViewModel mainAppPanelViewModel)
        {
            _mainAppPanelViewModel = mainAppPanelViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _mainAppPanelViewModel.ScreenValue != null && _mainAppPanelViewModel.ScreenValue.Length != 0;
        }
        public override void Execute(object parameter)
        {
            
            
            var lastElement = _mainAppPanelViewModel.ScreenValue.Length-1;

            _mainAppPanelViewModel.ScreenValue =_mainAppPanelViewModel.ScreenValue.Remove(lastElement);
     
        }
    }
}
