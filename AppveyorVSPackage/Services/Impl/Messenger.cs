using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorVSPackage.Services.Impl
{
    [Export(typeof(memamjome.AppveyorVSPackage.Services.IMessenger))]
    internal class Messenger : memamjome.AppveyorVSPackage.Services.IMessenger
    {
        private GalaSoft.MvvmLight.Messaging.IMessenger _messenger;

        public Messenger()
        {
            _messenger = GalaSoft.MvvmLight.Messaging.Messenger.Default;
        }

        public void Subscribe<T>(object recipient, Action<T> action)
        {
            _messenger.Register<T>(recipient, action);
        }

        public void Send<T>(T message)
        {
            _messenger.Send(message);
        }
    }
}
