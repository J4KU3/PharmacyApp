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
        private readonly MainView _window;

        public CloseWindowCommand(MainView window)
        {
            _window = window;
        }
        public override void Execute(object parameter)
        {
            _window.Close();
        }
    }
}
