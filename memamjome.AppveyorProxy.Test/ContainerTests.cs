using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace memamjome.AppveyorProxy.Test
{
    [TestClass]
    public class ContainerTests
    {
        private static CompositionContainer _container;

        [ClassInitialize]
        public static void ClassInitializer(TestContext context)
        {
            _container = Helpers.ContainerHelper.GetContainer();
        }

        private static T Export<T>()
        {
            return _container.GetExportedValue<T>();
        }

        [TestMethod]
        public void GetSettingsProvider()
        {
            var t = Export<ISettingsProvider>();

            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void NavigationService()
        {
            var t = Export<INavigationService>();

            Assert.IsNotNull(t);
        }
    }
}
