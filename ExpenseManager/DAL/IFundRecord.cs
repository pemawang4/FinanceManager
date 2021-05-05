using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public interface IFundRecord
    {
        List<FundRecord> GetFundRecordById(FundRecord fund);

        void InsertFundRecord(FundRecord fundRecord);

        FundRecord GetParticularFundRecordById(int id);

        FundRecord UpdateFundRecord(FundRecord fundRecord);

        void DeleteFundRecord(int id);
    }
}
