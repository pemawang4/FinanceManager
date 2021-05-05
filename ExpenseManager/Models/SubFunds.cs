using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class SubFunds
    {
        public int Id { get; set; }

        public string SubFund { get; set; }
        
        public int MainFundId { get; set; }
    }
}
