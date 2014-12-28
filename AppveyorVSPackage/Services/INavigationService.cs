using System;
namespace memamjome.AppveyorVSPackage.Services
{
    public interface INavigationService
    {
        void NavigationTo(string key);
        void SetContainerViewPanel(System.Windows.Controls.ContentControl contentControl);
    }
}
