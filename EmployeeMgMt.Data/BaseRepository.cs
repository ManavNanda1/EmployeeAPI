using Dapper;
using EmployeeMgmt.Model.DataConf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgMt.Data
{
    public class BaseRepository
    {
        public readonly IConfiguration configuration;
        public readonly IOptions<DataConfig> _connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string conString = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(conString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string conString = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(conString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
