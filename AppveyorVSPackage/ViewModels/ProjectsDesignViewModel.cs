using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Model;

namespace memamjome.AppveyorVSPackage.ViewModels
{
    public class ProjectsDesignViewModel : memamjome.AppveyorVSPackage.ViewModels.IProjectsViewModel
    {
        private string _projectsTitle = "Projects";
        private IList<Project> _projects;

        public string ProjectsTitle { get { return _projectsTitle; } }

        public IEnumerable<Project> Projects { get { return _projects; } }

        public ProjectsDesignViewModel()
        {
            _projects = new List<Project>
            {
                new Project { Name = "Project 1", CommitMessage = "Commit 1", LastBuild = DateTime.UtcNow.AddDays(-1), Status = "Failed"},
                new Project { Name = "Project 2", CommitMessage = "Commit 2", LastBuild = DateTime.UtcNow.AddDays(-2), Status = "Succeded"},
                new Project { Name = "Project 3", CommitMessage = "Commit 3", LastBuild = DateTime.UtcNow.AddDays(-3), Status = "Failed"},
            };
        }

        public void Initialise() { }
    }
}
