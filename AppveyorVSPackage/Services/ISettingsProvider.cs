using System;
using memamjome.AppveyorVSPackage.Model;
namespace memamjome.AppveyorVSPackage.Services
{
    public interface ISettingsProvider
    {
        AppveyorToken GetCurrentUserToken();
        void SetCurrrentUserToken(AppveyorToken token);
        void ResetToken();
    }
}
