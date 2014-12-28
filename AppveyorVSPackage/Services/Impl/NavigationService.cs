using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace memamjome.AppveyorVSPackage.Services.Impl
{
    [Export(typeof(INavigationService))]
    internal class NavigationService : memamjome.AppveyorVSPackage.Services.INavigationService
    {
        private ContentControl _contentControl;

        public void SetNavigationTarget(ContentControl contentControl)
        {
            _contentControl = contentControl;
        }

        public void NavigationTo(UserControl control)
        {
            if(_contentControl == null)
            {
                throw new InvalidOperationException("Navigation container is not set. Use SetNavigationTarget to the container panel");
            }

            _contentControl.Content = control;

            UpdateViewModel(control);
        }

        private void UpdateViewModel(UserControl control)
        {
            var dataContext = control.DataContext;

            if(dataContext != null && dataContext is INavigatableViewModel)
            {
                (dataContext as INavigatableViewModel).NavigateTo();
            }
        }
    }
}
