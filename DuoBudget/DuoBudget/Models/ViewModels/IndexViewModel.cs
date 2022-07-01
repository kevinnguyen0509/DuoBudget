using DuoBudget.Models.BudgetModels;
using DuoBudget.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.ViewModels
{
    public class IndexViewModel
    {
        public User User { get; set; }
        public List<VariableExpenseModel> VariableExpenseList { get; set; }
        public List<DropDownOptions> Categories { get; set; }
        public List<FixedExpenseModel> FixedExpenses { get; set; }
        public List<SplitExpenseModel> SplitExpenses { get; set; }
        public List<SplitExpenseModel> PartnerSplitExpenses { get; set; }
        public List<IncomeModel> IncomeThisMonth { get; set; }
    }
}