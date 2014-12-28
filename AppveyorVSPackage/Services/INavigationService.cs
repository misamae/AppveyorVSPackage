using System;
using System.Windows.Controls;
namespace memamjome.AppveyorVSPackage.Services
{
    public interface INavigationService
    {
        void NavigationTo(UserControl key);
        void SetNavigationTarget(System.Windows.Controls.ContentControl control);
    }
}
