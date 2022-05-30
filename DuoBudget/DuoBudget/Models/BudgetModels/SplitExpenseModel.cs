using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.BudgetModels
{
    public class SplitExpenseModel : BudgetTable, IBudgetForm<SplitExpenseModel>
    {
        GetBudgetSheetData GetData = new GetBudgetSheetData();
        public List<SplitExpenseModel> GetExpenses(int OwnerID)
        {
            int currentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllSplitExpenseThisMonth(currentMonth, currentYear, OwnerID);
        }
    }
}