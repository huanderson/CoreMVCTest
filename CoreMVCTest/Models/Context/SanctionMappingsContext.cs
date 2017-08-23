using Microsoft.EntityFrameworkCore;

namespace CoreMVCTest.Models.Context
{
    public class SanctionMappingsContext : DbContext
    {
        public SanctionMappingsContext(DbContextOptions<SanctionMappingsContext> listOptions)
            : base(listOptions)
        {
        }
    }
}
