using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class Funds
    {
        public int Id { get; set; }
        [Required]
        public string FundName { get; set; }
        
    }
}
