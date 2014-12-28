using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorVSPackage.ViewModels.Design
{
    public class NavigationDesignViewModel : INavigationViewModel
    {
        public System.Windows.Input.ICommand NavigateSettingsCommand { get; set; }

        public System.Windows.Input.ICommand NavigateProjectsCommand { get; set; }
    }
}
