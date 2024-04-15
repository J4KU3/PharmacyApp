using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands
{
    public class CloseWindowCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public CloseWindowCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
