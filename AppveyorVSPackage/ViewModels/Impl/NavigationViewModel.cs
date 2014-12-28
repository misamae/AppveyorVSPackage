using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using memamjome.AppveyorVSPackage.Model.Messages;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorVSPackage.ViewModels.Impl
{
    [Export(typeof(INavigationViewModel))]
    class NavigationViewModel : INavigationViewModel
    {
        public System.Windows.Input.ICommand NavigateSettingsCommand { get; set; }

        public System.Windows.Input.ICommand NavigateProjectsCommand { get; set; }

        private IMessenger _messenger;

        [ImportingConstructor]
        public NavigationViewModel(IMessenger messenger)
        {
            NavigateSettingsCommand = new RelayCommand(NavigateSettings);
            NavigateProjectsCommand = new RelayCommand(NavigateProjects);

            _messenger = messenger;
        }

        private void NavigateSettings()
        {
            SendNavigationMessage(Constants.SettingsControlKey);
        }

        private void NavigateProjects()
        {
            SendNavigationMessage(Constants.ProjectsControlKey);
        }

        private void SendNavigationMessage(string key)
        {
            _messenger.Send<NavigationMessage>(new NavigationMessage(key));
        }
    }
}
