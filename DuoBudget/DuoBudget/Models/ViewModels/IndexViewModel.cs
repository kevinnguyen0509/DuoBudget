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
    }
}