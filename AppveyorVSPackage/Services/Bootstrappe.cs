using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using memamjome.AppveyorVSPackage.Views;

namespace memamjome.AppveyorVSPackage.Services
{
    public class Bootstrapper
    {
        private INavigationService _navigationService;
        private ContainerControl _containerControl;
        private object _toolWindowContent;
        private ExportProvider _container;

        private static CompositionContainer InitialiseContainer()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AppveyorToolWindow).Assembly));
            var container = new CompositionContainer(catalog);
            return container;
        }

        public Bootstrapper(object content)
        {
            _toolWindowContent = content;

            _container = InitialiseContainer();

            Start();
        }

        public void Start()
        {
            _containerControl = _container.GetExportedValue<ContainerControl>();
            _toolWindowContent = _containerControl;

            _containerControl.SetNavigationContent(_container.GetExportedValue<NavigationControl>());
        }
    }
}
