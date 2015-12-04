using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMover
{
    public class JobStep
    {
        public string Name { get; set; }
        public int QueueNumber { get; set; }
        public string FetchXml { get; set; }
        public Config Configs { get; set; }
    }
}
