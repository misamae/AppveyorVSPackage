﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using memamjome.AppveyorVSPackage.Model;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorVSPackage.ViewModels.Impl
{
    [Export(typeof(ISettingsViewModel))]
    internal class SettingsViewModel : GalaSoft.MvvmLight.ViewModelBase, ISettingsViewModel, INavigatableViewModel
    {
        public System.Windows.Input.ICommand SaveToken { get; set; }

        public string UserToken 
        {
            get { return _userToken; }
            set
            {
                _userToken = value;
                RaisePropertyChanged("UserToken");
            }
        }

        private ISettingsProvider _settingsProvider;
        private string _userToken;

        [ImportingConstructor]
        public SettingsViewModel(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
            SaveToken = new RelayCommand(Save);
        }

        private void Initialise()
        {
            var token = _settingsProvider.GetCurrentUserToken();

            UserToken = token.Token;
        }

        private void Save()
        {
            var token = new AppveyorToken(UserToken);

            _settingsProvider.SetCurrrentUserToken(token);
        }

        public void NavigateTo()
        {
            Initialise();
        }
    }
}
