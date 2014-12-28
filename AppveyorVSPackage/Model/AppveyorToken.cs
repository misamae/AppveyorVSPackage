using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorVSPackage.Model
{
    public class AppveyorToken
    {
        private string _token;

        public string Token
        {
            get {return _token;}
            private set
            {
                ValidateToken(value);
                _token = value;
            }
        }

        private void ValidateToken(string value)
        {
            //TODO:
        }

        public AppveyorToken(string token)
        {
            Token = token;
        }

        public bool IsTokenValid()
        {
            //Not a good validation
            return !string.IsNullOrWhiteSpace(_token);
        }

        public static AppveyorToken EmptyToken()
        {
            return new AppveyorToken(string.Empty);
        }

        public override bool Equals(object obj)
        {
            var other = obj as AppveyorToken;

            if (other == null) return false;

            return other.Token == this.Token;
        }

        public override string ToString()
        {
            return Token;
        }
    }
}
