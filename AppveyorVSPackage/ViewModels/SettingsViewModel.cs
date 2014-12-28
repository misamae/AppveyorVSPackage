using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorVSPackage.ViewModels
{
    public class SettingsViewModel : ISettingsViewModel
    {
        public System.Windows.Input.ICommand SaveToken { get; set; }

        public string UserToken { get; set; }

        private ISettingsProvider _settingsProvider = new SettingsProvider();

        public SettingsViewModel()
        {
            SaveToken = new RelayCommand(Save);
        }

        private void Save()
        {
            _settingsProvider.SetCurrrentUserToken(UserToken);
        }
    }
}
