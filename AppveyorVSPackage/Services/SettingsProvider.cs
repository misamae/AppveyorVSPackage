using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace memamjome.AppveyorVSPackage.Services
{
    [IsolatedStorageFilePermission(SecurityAction.PermitOnly, UsageAllowed = IsolatedStorageContainment.AssemblyIsolationByUser)]
    public class SettingsProvider : memamjome.AppveyorVSPackage.Services.ISettingsProvider
    {
        const string IsolatedStorageKey = "AppveyorVSPackage";

        internal struct Settings
        {
            internal string Token { get; set; }
        }

        public async Task SetCurrrentUserToken(string token)
        {
            var currentSettings = await GetSettings();

            currentSettings.Token = token;

            await WriteToIsolatedStorageAsync(currentSettings);
        }

        public async Task<string> GetCurrentUserToken()
        {
            return (await GetSettings()).Token;
        }

        private async Task<Settings> GetSettings()
        {
            return await ReadFromIsolatedStorageAsync();
        }

        private async Task WriteToIsolatedStorageAsync(Settings settings)
        {
            using (Stream s = new IsolatedStorageFileStream(IsolatedStorageKey, FileMode.Create, IsolatedStorageFile.GetUserStoreForAssembly()))
            {
                // Write some data out to the isolated file. 
                using (StreamWriter sw = new StreamWriter(s))
                {
                    var content = JsonConvert.SerializeObject(settings);
                    sw.WriteAsync(content);
                }
            }
        }

        private async Task<Settings> ReadFromIsolatedStorageAsync()
        {
            using (var s = new IsolatedStorageFileStream(IsolatedStorageKey, FileMode.Open, IsolatedStorageFile.GetUserStoreForAssembly()))
            {
                using (var sr = new StreamReader(s))
                {
                    var content = await sr.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<Settings>(content);
                }
            }
        }
    }
}
