using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class FundRecordRepository : IFundRecord
    {
        private readonly IConfiguration configuration;
        private string ConString = string.Empty;
        public FundRecordRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConString = configuration.GetConnectionString("DbCon");
        }

        public void DeleteFundRecord(int id)
        {
            using (var conn = new SqlConnection(ConString)) {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                conn.Execute("sp_DeleteFundRecord", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<FundRecord> GetFundRecordById(FundRecord fund)
        {
            using (var conn = new SqlConnection(ConString))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@MainFundId", fund.MainFundId);
                param.Add("@SubFundId", fund.SubFundId);
                var data = conn.Query<FundRecord>("sp_FundRecordList", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public FundRecord GetParticularFundRecordById(int id)
        {
            using(var conn = new SqlConnection(ConString)){
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                var data = conn.Query<FundRecord>("sp_ParticularFundRecordById", param, commandType: System.Data.CommandType.StoredProcedure);
                return data.FirstOrDefault();
            }
        }

        public void InsertFundRecord(FundRecord fundRecord)
        {
            using (var conn = new SqlConnection(ConString))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@MainFundId", fundRecord.MainFundId);
                param.Add("@SubFundId", fundRecord.SubFundId);
                param.Add("@FundAmount", fundRecord.FundAmount);
                var createdAt = DateTime.Now;
                var updatedAt = DateTime.Now;
                param.Add("@CreatedAt", createdAt);
                param.Add("@UpdatedAt", updatedAt);
                
                conn.Execute("sp_InsertFundRecord", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public FundRecord UpdateFundRecord(FundRecord fundRecord)
        {
            using (var conn = new SqlConnection(ConString)) {
                DynamicParameters param = new DynamicParameters();
                DynamicParameters param1 = new DynamicParameters();
                param1.Add("@Id", fundRecord.Id);
                param.Add("@Id", fundRecord.Id);
                param.Add("@FundAmount", fundRecord.FundAmount);
                conn.Execute("sp_UpdateFundRecord", param, commandType: System.Data.CommandType.StoredProcedure);
                var data = conn.Query<FundRecord>("sp_ParticularFundRecordById", param1, commandType: System.Data.CommandType.StoredProcedure);
                return data.FirstOrDefault();
            }
        }
    }
}
