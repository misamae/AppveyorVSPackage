using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using memamjome.AppveyorProxy.Model;
namespace memamjome.AppveyorProxy.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<Project>> GetProjects(string token);
    }
}
