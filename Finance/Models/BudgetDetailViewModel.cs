using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public class BudgetDetailViewModel
    {
        public Budget Budget { get; set; }
        public List<Category> Categories { get; set; }
    }
}