using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;
using WpfApp1.Data;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace WpfApp1.Commands.AdminPanelCommands.CRUDProduct
{
    public class FindPictureCommand : BaseCommand
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;
        public FindPictureCommand(AdminPanelViewModel adminPanelViewModel)
        {
            _adminPanelViewModel = adminPanelViewModel;
        }
        public override void Execute(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                _adminPanelViewModel.ImageLocation = openFile.FileName;

            }
    
        }
    }
}
