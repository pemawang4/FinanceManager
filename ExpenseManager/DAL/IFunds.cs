using ExpenseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.DAL
{
    public interface IFunds
    {
        List<Funds> FundList();

        void InsertFund(Funds fund);

        Funds GetMainFundById(int id);

        void UpdateMainFund(Funds fund);

        void DeleteMainFundById(int id);
    }
}
