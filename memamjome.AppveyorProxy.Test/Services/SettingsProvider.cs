using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace memamjome.AppveyorProxy.Test.Services
{
    [TestClass]
    public class SettingsProvider
    {
        private ISettingsProvider GetSettingsProvider()
        {
            return Helpers.ContainerHelper.GetContainer().GetExportedValue<ISettingsProvider>();
        }

        [TestMethod]
        public void Write_Read()
        {
            const string token = "xxxxxyyyy";

            var provider = GetSettingsProvider();

            provider.SetCurrrentUserToken(token);

            var retrievedToken = provider.GetCurrentUserToken();

            Assert.AreEqual(token, retrievedToken);

            Debug.WriteLine(string.Format("Current token: {0}", retrievedToken));
        }
    }
}
