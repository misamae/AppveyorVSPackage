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
using memamjome.AppveyorVSPackage.Model;
using Newtonsoft.Json;

namespace memamjome.AppveyorVSPackage.Services.Impl
{
    [Export(typeof(ISettingsProvider))]
    internal class SettingsProvider : memamjome.AppveyorVSPackage.Services.ISettingsProvider
    {
        private IIsolatedStorageWrapper _isolatedStorageWarpper;

        [ImportingConstructor]
        public SettingsProvider(IIsolatedStorageWrapper isolatedStorageWarpper)
        {
            _isolatedStorageWarpper = isolatedStorageWarpper;
        }

        public void SetCurrrentUserToken(AppveyorToken token)
        {
            WriteToken(token);
        }

        public AppveyorToken GetCurrentUserToken()
        {
            return ReadToken();
        }

        public void ResetToken()
        {
            WriteToken(AppveyorToken.EmptyToken());
        }

        private void WriteToken(AppveyorToken token)
        {
            var content = JsonConvert.SerializeObject(token);
            _isolatedStorageWarpper.WriteToIsolatedStorage(content);
        }

        private AppveyorToken ReadToken()
        {
            try
            {
                var content = _isolatedStorageWarpper.ReadFromIsolatedStorage();

                if (string.IsNullOrWhiteSpace(content))
                {
                    return AppveyorToken.EmptyToken();
                }

                return JsonConvert.DeserializeObject<AppveyorToken>(content);
            }
            catch (FileNotFoundException)
            {
                return AppveyorToken.EmptyToken();
            }
        }
    }
}
