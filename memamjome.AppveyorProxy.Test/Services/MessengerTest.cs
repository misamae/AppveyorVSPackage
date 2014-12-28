using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using memamjome.AppveyorVSPackage.Services;
using System.Diagnostics;
using memamjome.AppveyorVSPackage.Model.Messages;

namespace memamjome.AppveyorProxy.Test.Services
{
    [TestClass]
    public class MessengerTest
    {
        private IMessenger GetMessenger()
        {
            return Helpers.ContainerHelper.GetContainer().GetExportedValue<IMessenger>();
        }

        
        [TestMethod]
        public void Send_Receive()
        {
            var messenger = GetMessenger();
            bool _send_recieve_test = false;
            messenger.Subscribe<string>(this, (test) =>
            {
                Debug.WriteLine(test);
                _send_recieve_test = true;
            });

            messenger.Send<string>("123456");

            Assert.IsTrue(_send_recieve_test);
        }

        [TestMethod]
        public void Send_NavigationMessage_Receive()
        {
            var messenger = GetMessenger();
            bool _send_recieve_test = false;
            messenger.Subscribe<NavigationMessage>(this, (message) =>
            {
                Debug.WriteLine(message.TargetKey);
                _send_recieve_test = true;
            });

            messenger.Send<NavigationMessage>(new NavigationMessage("Settings"));

            Assert.IsTrue(_send_recieve_test);
        }
    }
}
