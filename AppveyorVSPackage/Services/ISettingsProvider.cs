using System;
namespace memamjome.AppveyorVSPackage.Services
{
    interface ISettingsProvider
    {
        System.Threading.Tasks.Task<string> GetCurrentUserToken();
        System.Threading.Tasks.Task SetCurrrentUserToken(string token);
    }
}
