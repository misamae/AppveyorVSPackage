using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Model;

namespace memamjome.AppveyorVSPackage.ViewModels
{
    public class ProjectsViewModel : memamjome.AppveyorVSPackage.ViewModels.IProjectsViewModel
    {
        private string _projectsTitle = "Projects";
        private ObservableCollection<Project> _projects;

        public string ProjectsTitle { get { return _projectsTitle; } }

        public IEnumerable<Project> Projects { get { return _projects; } }

        public memamjome.AppveyorProxy.Services.IProjectsService ProjectsService { get; set; }

        public ProjectsViewModel()
        {
            ProjectsService = new memamjome.AppveyorProxy.Services.ProjectsService();

            _projects = new ObservableCollection<Project>();

            Initialise();
        }

        public async void Initialise()
        {
            try
            {
                var projects = await ProjectsService.GetProjects("");

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
