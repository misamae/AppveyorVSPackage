using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorVSPackage.Model.Messages
{
    public class TokenChangedMessage
    {
        public AppveyorToken Token { get; private set;}

        public TokenChangedMessage(AppveyorToken token)
        {
            Token = token;
        }
    }
}
