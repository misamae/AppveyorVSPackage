using System;
using System.Collections.Generic;
using memamjome.AppveyorVSPackage.Model;
using Microsoft.VisualStudio.Shell;
namespace memamjome.AppveyorVSPackage.ViewModels
{
    public interface IProjectsViewModel
    {
        string ProjectsTitle { get; }

        IEnumerable<Project> Projects { get; }
    }
}
