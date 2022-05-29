using DuoBudget.Models.BudgetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel(User user, List<VariableExpenseModel> VariableExpenseTable)
        {
            this.User = user;
            this.VariableExpenseList = VariableExpenseTable;
        }
        public User User { get; set; }
        public List<VariableExpenseModel> VariableExpenseList { get; set; }
    }
}