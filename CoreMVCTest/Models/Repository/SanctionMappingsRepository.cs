using CoreMVCTest.Models.Context;
using CoreMVCTest.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTest.Models.Repository
{
    public class SanctionMappingsRepository : ISanctionMappingsRepository
    {
        private readonly SanctionMappingsContext _context;

        public SanctionMappingsRepository(SanctionMappingsContext context)
        {
            _context = context;
        }

        public IEnumerable<DowJonesSubLists> GetSubLists()
        {
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "DOW_GetPEPSanctionBreakoutLists";
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                var retObject = new List<DowJonesSubLists>();
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var subList = new DowJonesSubLists()
                        {
                            ListCode = (dataReader["ListCode"] == DBNull.Value) ? "" : (string)dataReader["ListCode"],
                            Description = (dataReader["Name"] == DBNull.Value) ? "" : (string)dataReader["Name"],
                        };

                        retObject.Add(subList);
                    }
                }

                return retObject;
            }
        }

        public IEnumerable<SubListSanctionMappings> SubListSanctionMappings(string listCode)
        {
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "DOW_GetPEPSubListSanctions";
                cmd.CommandType = CommandType.StoredProcedure;
                var param = new SqlParameter { ParameterName = "@listcode", DbType = DbType.String, Value = listCode };
                cmd.Parameters.Add(param);

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                var retObject = new List<SubListSanctionMappings>();
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var subList = new SubListSanctionMappings()
                        {
                            SanctionCode = (dataReader["code"] == DBNull.Value) ? 0 : (int)dataReader["code"],
                            SanctionName = (dataReader["Name"] == DBNull.Value) ? "" : (string)dataReader["Name"],
                        };

                        retObject.Add(subList);
                    }
                }

                return retObject;
            }
        }

        public void DeleteSanctionFromSubList(string listCode, int sanctionID)
        {
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "WDLE_DeleteSanctionFromSubList";
                cmd.CommandType = CommandType.StoredProcedure;
                var param = new SqlParameter { ParameterName = "@listCode", DbType = DbType.String, Value = listCode };
                cmd.Parameters.Add(param);

                param = new SqlParameter { ParameterName = "@sanctionID", DbType = DbType.Int32, Value = sanctionID };
                cmd.Parameters.Add(param);

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
