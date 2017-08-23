using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTest.ViewModels
{
    public class vmSanctionMappings
    {
        public int SanctionCode { get; set; }
        public string SanctionName { get; set; }
        public string ListCode { get; set; }
    }

    public class vmDowJonesSubList
    {
        public string ListCode { get; set; }
        public string Description { get; set; }
    }
}
