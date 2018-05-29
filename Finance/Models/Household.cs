using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public class Household
    {
        public Household()
        {
            Categories = new HashSet<Category>();
            Members = new HashSet<ApplicationUser>();
            Budgets = new HashSet<Budget>();
            Accounts = new HashSet<PersonalAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
        public virtual ICollection<PersonalAccount> Accounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }

    }
}