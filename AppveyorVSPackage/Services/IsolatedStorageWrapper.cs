using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace memamjome.AppveyorVSPackage.Services
{
    [Export(typeof(IIsolatedStorageWrapper))]
    internal class IsolatedStorageWrapper : memamjome.AppveyorVSPackage.Services.IIsolatedStorageWrapper
    {
        const string IsolatedStorageKey = "AppveyorVSPackage";
        private static object _readLock = new object();

        public void WriteToIsolatedStorage(string content)
        {
            using (Stream s = new IsolatedStorageFileStream(IsolatedStorageKey, FileMode.Create, IsolatedStorageFile.GetUserStoreForAssembly()))
            {
                // Write some data out to the isolated file. 
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(content);
                }
            }
        }

        public string ReadFromIsolatedStorage()
        {
            lock (_readLock)
            {
                using (var s = new IsolatedStorageFileStream(IsolatedStorageKey, FileMode.Open, IsolatedStorageFile.GetUserStoreForAssembly()))
                {
                    using (var sr = new StreamReader(s))
                    {
                        return sr.ReadToEnd();
                    }
                }
                
            }
        }
    }
}
