using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memamjome.AppveyorProxy.Model
{
    public class Build
    {
        public int BuildId { get; set; }
        //public IEnumerable<Job> Jobs { get; set; }
        public int BuildNumber { get; set; }
        public string Version { get; set; }
        public string Message { get; set; }
        public string Branch { get; set; }
        public string CommitId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUserName { get; set; }
        public string CommitterName { get; set; }
        public string CommitterUserName { get; set; }
        public DateTime Committed { get; set; }
        //public IEnumerable<string> Messages { get; set; }
        public string Status { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    /*
  "builds":[
         {
            "buildId":23864,
            "jobs":[

            ],
            "buildNumber":3,
            "version":"1.0.3",
            "message":"replaced with command [skip ci]",
            "branch":"master",
            "commitId":"c2892a70d60c96c1b65a7c665ab806b7731fea8a",
            "authorName":"Feodor Fitsner",
            "authorUsername":"FeodorFitsner",
            "committerName":"Feodor Fitsner",
            "committerUsername":"FeodorFitsner",
            "committed":"2014-08-15T22:05:54+00:00",
            "messages":[

            ],
            "status":"success",
            "started":"2014-08-15T22:36:38.1757886+00:00",
            "finished":"2014-08-15T22:37:00.6171479+00:00",
            "created":"2014-08-15T22:33:15.9833328+00:00",
            "updated":"2014-08-15T22:37:00.6171479+00:00"
         }
      ],
     */
}
