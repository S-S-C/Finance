
using Finance.Models;
using Finance.Models.HelperClass;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Finance.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AuthorizeHouseholdRequired]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DashboardView()
        {
            var userid = User.Identity.GetUserId();

            //Select the sum of balances and reconciled balances
            var balances = db.PersonalAccounts.Select(a =>a.Balance).Sum();
            var reconciledbalances = db.PersonalAccounts.Select(a => a.ReconciledBalance).Sum();

            //Gather Credit Transactions
            var hhId = User.Identity.GetHouseholdId();
            var trns = db.PersonalAccounts.Where(a => a.HouseholdId == hhId).SelectMany(a => a.Transactions).Where(t => t.Type == true).Include("Account").ToList();
            var acctscrTrans = trns == null ? 0 : trns.Select(t => t.Amount).Sum();
            var trans= db.PersonalAccounts.Where(a => a.HouseholdId == hhId).SelectMany(a => a.Transactions).Where(t => t.Type == false).Include("Account").ToList();
            var acctsdrTrans = trans == null ? 0 : trans.Select(t => t.Amount).Sum();
            //var acctscrTrans = db.Transactions.Where(t => t.Type == true).Select(t =>(int?) t.Amount).Sum();
            //var acctsdrTrans = db.Transactions.Where(t => t.Type == false).Select(t =>(int?) t.Amount).Sum();


            var transactions = db.Transactions.Where(u => u.EnteredById == userid ).OrderByDescending(t => t.Date)
                .Take(15).ToList();
            var personalaccounts = db.PersonalAccounts;

            DashboardViewModel dvm = new DashboardViewModel()
            {
                Transactions = transactions,
                Balances = balances,
                ReconciledBalances = reconciledbalances,
                //Budgets = budgets,
                CrTransactions = acctscrTrans,
                DrTransactions = acctsdrTrans,
                PersonalAccounts = personalaccounts
            };
            
            return View(dvm);
        }

    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}