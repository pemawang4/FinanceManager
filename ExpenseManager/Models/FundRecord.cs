using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class FundRecord
    {
        public int Id { get; set; }

        public int FundAmount { get; set; }
        public int MainFundId { get; set; }
        public int SubFundId { get; set; }
        public string SubFund { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
        public string UpdatedAtString
        {
            get
            {
                if (UpdateAt != null)
                {
                    return UpdateAt.Value.ToString("yyyy/MM/dd hh:mm:ss tt");
                }
                else
                    return "";
            }
        }
    }
}
