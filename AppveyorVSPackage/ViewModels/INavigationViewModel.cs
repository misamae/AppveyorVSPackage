using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace memamjome.AppveyorVSPackage.ViewModels
{
    public interface INavigationViewModel
    {
        ICommand NavigateSettingsCommand { get; set; }
        ICommand NavigateProjectsCommand { get; set; }
    }
}
