using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorVSPackage.Model.Messages
{
    public class NavigationMessage
    {
        private string _targetKey;

        public string TargetKey
        {
            get { return _targetKey; }
            private set
            {
                _targetKey = value;
            }
        }

        public NavigationMessage(string targetKey)
        {
            TargetKey = targetKey;
        }

        public override bool Equals(object obj)
        {
            var other = obj as NavigationMessage;

            if (other == null) return false;

            return other.TargetKey== this.TargetKey;
        }

        public override string ToString()
        {
            return TargetKey;
        }
    }
}
