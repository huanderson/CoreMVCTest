using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTest.Models.Repository.Interface
{
    public interface ISanctionMappingsRepository
    {

        IEnumerable<DowJonesSubLists> GetSubLists();
        IEnumerable<SubListSanctionMappings> SubListSanctionMappings(string listCode);
        void DeleteSanctionFromSubList(string istCode, int sanctionID);
    }
}
