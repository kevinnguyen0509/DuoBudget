using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DuoBudget.Models.BudgetModels
{
    public class TotalsModel 
    {
        public decimal VariableExpenseTotal { get; set; }
        public decimal FixedExpenseTotal { get; set; }
        public decimal IncomeTotal { get; set; }
        public decimal SplitTotal { get; set; }

    }
}