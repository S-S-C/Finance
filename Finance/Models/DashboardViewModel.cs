using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Finance.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Budget> Budgets { get; set; }
        public IEnumerable<PersonalAccount> PersonalAccounts { get; set; }
        public decimal Balances { get; set; }
        public decimal ReconciledBalances { get; set; }
        public decimal CrTransactions { get; set; }
        public decimal DrTransactions { get; set; }
    }
}