using ExpenseManager.DAL;
using ExpenseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Controllers
{
    public class FundRecordController : Controller
    {
        private readonly IFundRecord _funds;

        private readonly IFunds mainFund;
        private readonly ISubFunds subFund;

        public FundRecordController(IFundRecord funds, IFunds mainFund, ISubFunds subFund)
        {
            _funds = funds;
            this.mainFund = mainFund;
            this.subFund = subFund;
        }

        public IActionResult GetFundRecordById(FundRecord fund)
        {
            List<FundRecord> data = _funds.GetFundRecordById(fund);
            return Json(data);
        }
        public IActionResult Index(FundRecord fund)
        {
            List<Funds> mainFundList = mainFund.FundList();
            ViewBag.mainFundList = mainFundList;
            return View();
        }

        //[HttpGet]
        //public IActionResult ViewFundRecord(FundRecord fund)
        //{
            
        //}

        [HttpPost]
        public IActionResult CreateFundRecord(FundRecord fundRecord)
        {
            _funds.InsertFundRecord(fundRecord);
            return Json(new { result = "redirect", url = Url.Action("Index", "Fund") });
        }

        public IActionResult GetSubFundById(int id)
        {
            List<SubFunds> subFundList = subFund.GetSubFundById(id);
            return Json(subFundList);
        }

        public IActionResult GetParticularFundRecordById(int id)
        {
            var data = _funds.GetParticularFundRecordById(id);
            return Json(data);
        }

        [HttpPost]
        public IActionResult UpdateFundRecord(FundRecord fundRecord)
        {
            var data = _funds.UpdateFundRecord(fundRecord);
            return Json(data);
        }

        public IActionResult DeleteFundRecord(int id)
        {
            _funds.DeleteFundRecord(id);
            return Json("success");
        }
    }
}
