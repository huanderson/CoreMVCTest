using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTest.Models
{
    public class DowJonesSubLists
    {
        public string ListCode { get; set; }
        public string Description { get; set; }
    }

    public class SubListSanctionMappings
    {
        public int SanctionCode { get; set; }
        public string SanctionName { get; set; }
        public string ListCode { get; set; }
    }
}
