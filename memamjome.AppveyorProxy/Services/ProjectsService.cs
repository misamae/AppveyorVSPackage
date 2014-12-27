using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorProxy.Model;

namespace memamjome.AppveyorProxy.Services
{
    public class ProjectsService : memamjome.AppveyorProxy.Services.IProjectsService
    {
        public async Task<IEnumerable<Project>> GetProjects(string token)
        {
            return await GetInternal<Project>(token);
        }

        private async Task<IEnumerable<T>> GetInternal<T>(string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await client.GetAsync("https://ci.appveyor.com/api/projects"))
                {
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsAsync<T[]>();
                }
            }
        }
    }
}
