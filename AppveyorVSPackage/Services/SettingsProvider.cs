using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace memamjome.AppveyorVSPackage.Services
{
    [SecuritySafeCritical]
    //[IsolatedStorageFilePermission(SecurityAction.PermitOnly, UsageAllowed= IsolatedStorageContainment.AssemblyIsolationByUser)]
    public class Settings
    {
        public string Token { get; set; }
    }

    //[IsolatedStorageFilePermission(SecurityAction.PermitOnly, UsageAllowed = IsolatedStorageContainment.AssemblyIsolationByUser)]
    [Export(typeof(ISettingsProvider))]
    internal class SettingsProvider : memamjome.AppveyorVSPackage.Services.ISettingsProvider
    {
        private IIsolatedStorageWrapper _isolatedStorageWarpper;

        [ImportingConstructor]
        public SettingsProvider(IIsolatedStorageWrapper isolatedStorageWarpper)
        {
            _isolatedStorageWarpper = isolatedStorageWarpper;
        }

        public void SetCurrrentUserToken(string token)
        {
            var currentSettings = GetSettings();

            currentSettings.Token = token;

            WriteSettings(currentSettings);
        }

        public string GetCurrentUserToken()
        {
            return GetSettings().Token;
        }

        private Settings GetSettings()
        {
            return ReadSettings();
        }

        private void WriteSettings(Settings settings)
        {
            var content = JsonConvert.SerializeObject(settings);
            _isolatedStorageWarpper.WriteToIsolatedStorage(content);
        }

        private Settings ReadSettings()
        {
            try
            {
                var content = _isolatedStorageWarpper.ReadFromIsolatedStorage();

                if (string.IsNullOrWhiteSpace(content))
                {
                    return new Settings();
                }

                return JsonConvert.DeserializeObject<Settings>(content);
            }
            catch (FileNotFoundException)
            {
                return new Settings();
            }
        }
    }
}
