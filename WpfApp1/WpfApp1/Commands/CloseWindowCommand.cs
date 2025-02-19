﻿using System;
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
        private readonly LoginView _mainLoginView;
        public CloseWindowCommand(LoginView mainLoginView)
        {
            _mainLoginView = mainLoginView;
        }
        public override void Execute(object parameter)
        {
            _mainLoginView.Close();
        }
    }
}
