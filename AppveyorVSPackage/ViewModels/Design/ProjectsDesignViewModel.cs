using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Model;

namespace memamjome.AppveyorVSPackage.ViewModels.Design
{
    public class ProjectsDesignViewModel : memamjome.AppveyorVSPackage.ViewModels.IProjectsViewModel
    {
        private string _projectsTitle = "Projects";
        private IList<Project> _projects;

        public string AccountName { get { return _projectsTitle; } }

        public IEnumerable<Project> Projects { get { return _projects; } }

        public ProjectsDesignViewModel()
        {
            _projects = new List<Project>
            {
                new Project { Name = "Project 1", LastBuild = new Build { Message = "Fixed broken build", AuthorName = "Meisam Emamjome", CommitId = "12345667778", Status = "success"}},
                new Project { Name = "Project 2", LastBuild = new Build { Message = "Merged pull request", AuthorName = "Meisam Emamjome", CommitId = "12345667778", Status = "fail"}},
                new Project { Name = "Project 3", LastBuild = new Build { Message = "Naughty refs", AuthorName = "Meisam Emamjome", CommitId = "12345667778", Status = "success"}},
            };
        }

        public void Initialise() { }
    }
}
