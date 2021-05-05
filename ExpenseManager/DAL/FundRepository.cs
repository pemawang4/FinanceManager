using Dapper;
using ExpenseManager.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.DAL
{
    public class FundRepository : IFunds
    {
        private readonly IConfiguration _configuration;

        public FundRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void DeleteMainFundById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                var data = conn.Query<Funds>("sp_DeleteMainFundById", param, commandType: System.Data.CommandType.StoredProcedure);
               
            }
        }

        public List<Funds> FundList()
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                var data = conn.Query<Funds>("sp_FundList", commandType: System.Data.CommandType.StoredProcedure).ToList();
                return data;
            }

        }

        public Funds GetMainFundById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon"))) {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                var data = conn.Query<Funds>("sp_GetMainFundById", param, commandType: System.Data.CommandType.StoredProcedure);
                return data.FirstOrDefault();
            }
        }

        public void InsertFund(Funds fund)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon"))) 
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@FundName", fund.FundName);

                conn.Execute("sp_InsertFund", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateMainFund(Funds fund)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", fund.Id);
                param.Add("@FundName", fund.FundName);
                conn.Execute("sp_sp_UpdateMainFund", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
