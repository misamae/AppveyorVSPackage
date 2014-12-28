using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Model;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorVSPackage.ViewModels
{
    [Export(typeof(IProjectsViewModel))]
    internal class ProjectsViewModel : memamjome.AppveyorVSPackage.ViewModels.IProjectsViewModel
    {
        private string _projectsTitle = "Projects";
        private ObservableCollection<Project> _projects;

        public string ProjectsTitle { get { return _projectsTitle; } }

        public IEnumerable<Project> Projects { get { return _projects; } }

        private memamjome.AppveyorProxy.Services.IProjectsService _projectsService;
        private memamjome.AppveyorVSPackage.Services.ISettingsProvider _settingsProvider;

        [ImportingConstructor]
        public ProjectsViewModel(ISettingsProvider settingsProvider)
        {
            _projectsService = new memamjome.AppveyorProxy.Services.ProjectsService();
            _settingsProvider = settingsProvider;

            _projects = new ObservableCollection<Project>();

            Initialise();
        }

        public async Task Initialise()
        {
            try
            {
                var token = _settingsProvider.GetCurrentUserToken();
                if (string.IsNullOrWhiteSpace(token)) { return; }
                var projects = await _projectsService.GetProjects(token);

                _projects.Clear();

                foreach (var project in projects)
                {
                    _projects.Add(new AppveyorVSPackage.Model.Project
                    {
                        Name = project.Name,
                    });
                }
            }
            catch (Exception) //Possible exceptions, network, authorisation,
            {
                throw;
            }
        }
    }
}
