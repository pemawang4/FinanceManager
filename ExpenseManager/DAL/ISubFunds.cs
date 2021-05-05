using ExpenseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.DAL
{
    public interface ISubFunds
    {
        List<SubFunds> SubFundList();

        void SaveSubFunds(SubFunds SubFund);

        List<SubFunds> GetSubFundById(int id);

        void UpdateSubFund(SubFunds fund);

        SubFunds GetSubFund(int id);

        void DeleteSubFundById(int id);
    }
}
