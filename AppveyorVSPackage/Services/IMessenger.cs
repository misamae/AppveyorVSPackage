using System;
namespace memamjome.AppveyorVSPackage.Services
{
    public interface IMessenger
    {
        void Send<T>(T message);
        void Subscribe<T>(object recipient, Action<T> action);
    }
}
