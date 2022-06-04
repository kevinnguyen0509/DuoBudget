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
        public List<SplitExpenseModel> GetExpenses()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int currentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllSplitExpenseThisMonth(currentMonth, currentYear, OwnerID);
        }

        public ResultMessage SaveExpense(SplitExpenseModel expenseModel)
        {
            throw new NotImplementedException();
        }
    }
}