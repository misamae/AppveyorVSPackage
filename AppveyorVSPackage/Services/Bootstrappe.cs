using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Windows.Controls;
using memamjome.AppveyorVSPackage.Model.Messages;
using memamjome.AppveyorVSPackage.Views;

namespace memamjome.AppveyorVSPackage.Services
{
    public class Bootstrapper
    {
        private INavigationService _navigationService;
        private ISettingsProvider _settingsProvider;
        private IMessenger _messenger;

        private ContainerControl _containerControl;
        private NavigationControl _navigationControl;
        private ProjectsControl _projectsControl;
        private SettingsControl _settingsControl;
        private ExportProvider _container;

        private static CompositionContainer InitialiseContainer()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AppveyorToolWindow).Assembly));
            var container = new CompositionContainer(catalog);
            return container;
        }

        public Bootstrapper()
        {
            _container = InitialiseContainer();
            InitialiseServices();
            IntialiseNavigationMessageListener();
            InitialiseControls();
            Start();
        }

        private void InitialiseServices()
        {
            _settingsProvider = _container.GetExportedValue<ISettingsProvider>();
            _navigationService = _container.GetExportedValue<INavigationService>();
            _messenger = _container.GetExportedValue<IMessenger>();
        }

        private void InitialiseControls()
        {
            _containerControl = _container.GetExportedValue<ContainerControl>();
            _navigationControl = _container.GetExportedValue<NavigationControl>();
            _projectsControl = _container.GetExportedValue<ProjectsControl>();
            _settingsControl = _container.GetExportedValue<SettingsControl>();
        }

        public UserControl Start()
        {
            _containerControl.NavigationContent.Content = _navigationControl;
            _navigationService.SetNavigationTarget(_containerControl.MainContent);

            if (Debugger.IsAttached)
            {
                //_settingsProvider.ResetToken();
            }

            var token = _settingsProvider.GetCurrentUserToken();

            if(token.IsTokenValid())
            {
                NavigateToProjects();
            }
            else
            {
                NavigateToSettings();
            }

            return _containerControl;
        }

        private void NavigateToSettings()
        {
            _navigationService.NavigationTo(_settingsControl);
        }

        private void NavigateToProjects()
        {
            _navigationService.NavigationTo(_projectsControl);
        }

        private void IntialiseNavigationMessageListener()
        {
            _messenger.Subscribe<NavigationMessage>(this, (message) =>
            {
                if (message.TargetKey == Constants.ProjectsControlKey)
                    NavigateToProjects();

                if (message.TargetKey == Constants.SettingsControlKey)
                    NavigateToSettings();
            });
        }

        //public void Navigate(NavigationMessage message)
        //{
        //    if (message.TargetKey == Constants.ProjectsControlKey)
        //        NavigateToProjects();

        //    if (message.TargetKey == Constants.SettingsControlKey)
        //        NavigateToSettings();
        //}
    }
}
