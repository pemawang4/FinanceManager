using ExpenseManager.DAL;
using ExpenseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Controllers
{
    public class FundController : Controller
    {
        private readonly IFunds _Fund;
        private readonly ISubFunds _SubFunds;

        public FundController(IFunds Fund, ISubFunds SubFunds)
        {
            _Fund = Fund;
            _SubFunds = SubFunds;
        }

        public IActionResult Index()
        {
            return View(_Fund.FundList());
        }

        public IActionResult CreateFund()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveFund(Funds Fund)
        {
            _Fund.InsertFund(Fund);
            return RedirectToAction("Index");
        }


        public IActionResult CreateSubFund()
        {
            return View(_Fund.FundList());
        }


        public void SaveSubFund(SubFunds subFunds)
        {
            _SubFunds.SaveSubFunds(subFunds);
        }

        public IActionResult GetSubFundById(int id) {
            var data = _SubFunds.GetSubFundById(id);
            return Json(data);
        }

        public IActionResult ViewMainFund()
        {
            var data = _Fund.FundList();
            return View(data);
        }

        public IActionResult ViewSubFund()
        {
            var data = _SubFunds.SubFundList();
            return View(data);
        }

        public IActionResult EditMainFund(int id)
        {
            var data =_Fund.GetMainFundById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateMainFund(Funds fund)
        {
            _Fund.UpdateMainFund(fund);
            return RedirectToAction("ViewMainFund");
        }

        public IActionResult DeleteMainFund(int id) {
            _Fund.DeleteMainFundById(id);
            return RedirectToAction("ViewMainFund");
        }

        public IActionResult EditSubFund(int id)
        {
            var data = _SubFunds.GetSubFund(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateSubFund(SubFunds fund)
        {
            _SubFunds.UpdateSubFund(fund);
            return RedirectToAction("ViewSubFund");
        }

        public IActionResult DeleteSubFund(int id)
        {
            _SubFunds.DeleteSubFundById(id);
            return RedirectToAction("ViewSubFund");
        }


    }
}
