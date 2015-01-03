using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Model;
using memamjome.AppveyorVSPackage.Model.Messages;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorVSPackage.ViewModels.Impl
{
    [Export(typeof(IProjectsViewModel))]
    internal class ProjectsViewModel : memamjome.AppveyorVSPackage.ViewModels.IProjectsViewModel, INavigatableViewModel
    {
        private string _projectsTitle = "Projects";
        private ObservableCollection<Project> _projects;

        public string AccountName { get { return _projectsTitle; } }

        public IEnumerable<Project> Projects { get { return _projects; } }

        private memamjome.AppveyorProxy.Services.IProjectsService _projectsService;
        private memamjome.AppveyorVSPackage.Services.ISettingsProvider _settingsProvider;
        private memamjome.AppveyorVSPackage.Services.IMessenger _messenger;

        public System.Windows.Input.ICommand RefreshCommand
        {
            get;
            private set;
        }

        [ImportingConstructor]
        public ProjectsViewModel(ISettingsProvider settingsProvider, IMessenger messenger)
        {
            _projectsService = new memamjome.AppveyorProxy.Services.ProjectsService();
            _settingsProvider = settingsProvider;
            _messenger = messenger;

            _projects = new ObservableCollection<Project>();

            RefreshCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Refresh);
        }

        private void Refresh()
        {
            var token = _settingsProvider.GetCurrentUserToken();

            _projects.Clear();
            GetProjects(token);
        }

        private void Refresh(TokenChangedMessage messege)
        {
            GetProjects(messege.Token);
        }

        private async Task GetProjects(AppveyorToken token)
        {
            try
            {
                var projects = await _projectsService.GetProjects(token.Token);

                _projects.Clear();

                foreach (var project in projects)
                {
                    var p = new AppveyorVSPackage.Model.Project { Name = project.Name,};

                    if(project.Builds.Any())
                    {
                        var lastBuild= project.Builds.First();
                        var b = new AppveyorVSPackage.Model.Build
                        {
                            AuthorName = lastBuild.AuthorName,
                            AuthorUserName = lastBuild.AuthorUserName,
                            Branch = lastBuild.Branch,
                            CommitId = lastBuild.CommitId,
                            Committed = lastBuild.Committed,
                            Created = lastBuild.Created,
                            Finished = lastBuild.Finished,
                            Message = lastBuild.Message,
                            Started = lastBuild.Started,
                            Status = lastBuild.Status,
                            Updated = lastBuild.Updated
                        };

                        p.LastBuild = b;
                    }

                    _projects.Add(p);
                }
            }
            catch (Exception) //Possible exceptions, network, authorisation,
            {
                throw;
            }
        }

        public void NavigateTo()
        {
            //TODO:
            var token = _settingsProvider.GetCurrentUserToken();
            GetProjects(token);
        }
    }
}
