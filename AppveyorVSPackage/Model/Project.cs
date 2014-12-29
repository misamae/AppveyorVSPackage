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
        public Build LastBuild { get; set; }
    }

    public class Build
    {
        public string Status { get; set; }
        public string Branch { get; set; }
        public string Message { get; set; }
        public string CommitId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUserName { get; set; }
        public DateTime Committed { get; set; }
        //public IEnumerable<string> Messages { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
