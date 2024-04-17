using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Commands.Navigations;
using WpfApp1.Commands.MainAppCommands;

namespace WpfApp1.ViewModel
{
    public class MainAppPanelViewModel:BaseViewModel
    {
        //Commands
        public ShowNumberCommand showNumberCommand { get; }
        public ClearCommand clearCommand { get; }
        //Properties
        private string _screenValue;
        public string ScreenValue
        {
            get
            {
                return _screenValue;
            }
            set
            {
                _screenValue = value;
                showNumberCommand.OnCanExecuteChanged();
                clearCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }


        public MainAppPanelViewModel()
        {
            showNumberCommand = new ShowNumberCommand(this);
            clearCommand = new ClearCommand(this);  
        }

       
    }
}
