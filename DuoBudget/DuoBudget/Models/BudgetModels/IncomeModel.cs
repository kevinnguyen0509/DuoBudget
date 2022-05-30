using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.BudgetModels
{
    public class IncomeModel : BudgetTable, IBudgetForm<IncomeModel>
    {
        GetBudgetSheetData GetData = new GetBudgetSheetData();

        //This will get all the Incomes
        public List<IncomeModel> GetExpenses(int OwnerID)
        {
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllIncomeListThisMonth(curentMonth, currentYear, OwnerID);
        }
    }
}