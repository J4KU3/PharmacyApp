using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.MainAppCommands
{
    public class ClearCommand : BaseCommand
    {
        private readonly MainAppPanelViewModel _mainAppPanelViewModel;

        public ClearCommand(MainAppPanelViewModel mainAppPanelViewModel)
        {
            _mainAppPanelViewModel = mainAppPanelViewModel;
        }
        public override void Execute(object parameter)
        {
            _mainAppPanelViewModel.ScreenValue = null;
        }
    }
}
