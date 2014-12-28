using System;
namespace memamjome.AppveyorVSPackage.Services
{
    interface IIsolatedStorageWrapper
    {
        string ReadFromIsolatedStorage();
        void WriteToIsolatedStorage(string content);
    }
}
