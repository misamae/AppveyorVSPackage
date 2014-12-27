using Microsoft.VisualStudio.TestTools.UnitTesting;
using memamjome.AppveyorProxy.Services;
using System.Threading.Tasks;
using System.Diagnostics;

namespace memamjome.AppveyorProxy.Test.Services
{
    [TestClass]
    public class ProjectsServiceTest
    {
        private string _token = "";

        [TestMethod]
        public void Initialise()
        {
            var service = new ProjectsService();

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public async Task GetProjects()
        {
            var service = new ProjectsService();

            var projects = await service.GetProjects(_token);

            Assert.IsNotNull(projects);

            foreach (var project in projects)
            {
                Debug.WriteLine(project.Name);
            }
        }
    }
}
