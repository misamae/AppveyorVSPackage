using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memamjome.AppveyorVSPackage.Services;

namespace memamjome.AppveyorProxy.Test.Helpers
{
    public static class ContainerHelper
    {
        public static CompositionContainer GetContainer()
        {
            var aggregateCatalog = new AggregateCatalog();

            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ISettingsProvider).Assembly));

            return new CompositionContainer(aggregateCatalog);
        }
    }
}
