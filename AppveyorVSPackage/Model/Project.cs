using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorVSPackage.Model
{
    public class Project
    {
        public string Name { get; set; }

        public string CommitMessage { get; set; }

        public string Status { get; set; }

        public DateTime LastBuild { get; set; }
    }
}
