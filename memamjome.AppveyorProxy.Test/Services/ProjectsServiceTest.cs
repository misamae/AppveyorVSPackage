using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using memamjome.AppveyorProxy.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                Debug.WriteLine(string.Format("    {0}", project.AccountName));
                Debug.WriteLine(string.Format("    {0}", project.IsPrivate));
                Debug.WriteLine(string.Format("    {0}", project.RepositoryBranch));
                Debug.WriteLine(string.Format("    {0}", project.RepositoryName));
                Debug.WriteLine(string.Format("    {0}", project.RepositoryType));
                Debug.WriteLine(string.Format("    {0}", project.Created));
                Debug.WriteLine(string.Format("    Builds: {0}", project.Builds.Any()));

                foreach (var build in project.Builds)
                {
                    Debug.WriteLine(string.Format("        Builds: {0}", build.BuildNumber));
                    Debug.WriteLine(string.Format("        Builds: {0}", build.Status));
                    Debug.WriteLine(string.Format("        Builds: {0}", build.Message));
                    Debug.WriteLine(string.Format("        Builds: {0}", build.AuthorName));
                    Debug.WriteLine(string.Format("        Builds: {0}", build.Created));
                    Debug.WriteLine(string.Format("        Builds: {0}", build.Updated));
                    Debug.WriteLine(string.Format("        Builds: {0}", build.Version));
                }
            }
        }
    }
}
