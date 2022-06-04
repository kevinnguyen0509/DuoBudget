using DuoBudget.DataFatory;
using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.BudgetModels
{
    public class VariableExpenseModel : BudgetTable, IBudgetForm<VariableExpenseModel>
    {
        GetBudgetSheetData GetData = new GetBudgetSheetData();
        SaveBudgetData SaveBudgetData = new SaveBudgetData();
        
        public List<VariableExpenseModel> GetExpenses()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllVariableExpense(curentMonth, currentYear, OwnerID);
        }

        public ResultMessage SaveExpense(VariableExpenseModel ExpenseModel)
        {
            return SaveBudgetData.SaveVariableExpenseEntry(ExpenseModel);
        }
    }
}