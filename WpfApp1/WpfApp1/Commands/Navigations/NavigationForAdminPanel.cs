using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Commands.Navigations
{
    public class NavigationForAdminPanel : BaseCommand
    {
        private readonly AdminPanelViewModel _adminPanelViewModel;

        public NavigationForAdminPanel(AdminPanelViewModel adminPanelViewModel)
        {
            _adminPanelViewModel = adminPanelViewModel;
        }
        public override void Execute(object parameter)
        {
            string page = parameter as string;
            _adminPanelViewModel.PageNumber = int.Parse(page);
        }
    }
}
