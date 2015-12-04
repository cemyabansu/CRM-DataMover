using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMover
{
    public class Config
    {
        public bool IsOnlyUpdate { get; set; }
        public bool MapBaseUnit { get; set; }
        public bool MapCurrency { get; set; }
        public List<GuidMapping> GuidMappings { get; set; }
    }
}
