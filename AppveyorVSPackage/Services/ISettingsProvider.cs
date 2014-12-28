using System;
namespace memamjome.AppveyorVSPackage.Services
{
    public interface ISettingsProvider
    {
        string GetCurrentUserToken();
        void SetCurrrentUserToken(string token);
    }
}
