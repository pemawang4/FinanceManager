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
    public class SubFundsRepository : ISubFunds
    {
        IConfiguration _configuration;

        public SubFundsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void DeleteSubFundById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                conn.Execute("sp_DeleteSubFundById", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public SubFunds GetSubFund(int id)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                return conn.Query<SubFunds>("sp_GetSubFund", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<SubFunds> GetSubFundById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@MainFundId", id);
                return conn.Query<SubFunds>("sp_GetSubFundById", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public void SaveSubFunds(SubFunds SubFund)
        {
            using(SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon"))){
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@SubFUnd", SubFund.SubFund);
                param.Add("@MainFundId", SubFund.MainFundId);
                conn.Execute("sp_SaveSubFunds", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<SubFunds> SubFundList()
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                var data = conn.Query<SubFunds>("sp_SubFundList", commandType: System.Data.CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public void UpdateSubFund(SubFunds fund)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DbCon")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", fund.Id);
                param.Add("@SubFund", fund.SubFund);
                conn.Execute("sp_UpdateSubFund", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
