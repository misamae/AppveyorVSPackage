using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace memamjome.AppveyorVSPackage.Services
{
    [Export(typeof(INavigationService))]
    internal class NavigationService : memamjome.AppveyorVSPackage.Services.INavigationService
    {
        private ContentControl _contentControl;

        public void SetContainerViewPanel(ContentControl contentControl)
        {
            _contentControl = contentControl;
        }

        public void NavigationTo(string key)
        {
            if(_contentControl == null)
            {
                throw new InvalidOperationException("Navigation container is not set. Use SetContainerViewPanel to the container panel");
            }
        }
    }
}
