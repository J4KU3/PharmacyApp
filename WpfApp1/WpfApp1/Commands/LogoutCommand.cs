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

        public LogoutCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;   
        }
        
        
        public override void Execute(object parameter)
        {
          
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            
        }
    }
}
