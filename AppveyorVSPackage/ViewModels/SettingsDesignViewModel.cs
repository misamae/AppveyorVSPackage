using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorVSPackage.ViewModels
{
    public class SettingsDesignViewModel : ISettingsViewModel
    {
        public System.Windows.Input.ICommand SaveToken { get; set; }

        public string UserToken
        {
            get { return "xxxxxxxx"; }
            set { }
        }
    }
}
