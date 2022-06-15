using DuoBudget.DataFatory;
using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.BudgetModels
{
    public class FixedExpenseModel : BudgetTable, IBudgetForm<FixedExpenseModel>
    {
        GetBudgetSheetData GetData = new GetBudgetSheetData();
        SaveBudgetData SaveBudgetData = new SaveBudgetData();
        DeleteBudgetsheetData DeleteBudgetsheetData = new DeleteBudgetsheetData();
        public ResultMessage DeleteEntry(int ID, int UserId)
        {
            return DeleteBudgetsheetData.DeleteFixedExpenseEntry(ID, UserId);
        }

        public List<FixedExpenseModel> GetExpenses()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllFixedThisMonth(curentMonth, currentYear, OwnerID);
        }

        public List<FixedExpenseModel> GetExpenses(int Month, int Year)
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Month;
            int currentYear = Year;
            return GetData.getAllFixedThisMonth(curentMonth, currentYear, OwnerID);
        }

        public ResultMessage SaveExpense(FixedExpenseModel ExpenseModel)
        {
            return SaveBudgetData.SaveFixedExpenseEntry(ExpenseModel); ;
        }

        public ResultMessage CopyFixedExpenseOverFromLastMonth()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            int curentMonth = 0;


            if (Int32.Parse(DateTime.Now.ToString("MM")) == 1)
            {//If Its january then the last month will be 12 or December
                curentMonth = 12;
            }
            else
            {
                curentMonth = Int32.Parse(DateTime.Now.ToString("MM")) - 1;
            }
                 
            List<FixedExpenseModel> FixedExpenseList = GetData.getAllFixedThisMonth(curentMonth, currentYear, OwnerID);
            for (int i = 0; i < FixedExpenseList.Count; i++)
            {
                FixedExpenseList[i].Date = FixedExpenseList[i].Date.AddMonths(1);
                SaveExpense(FixedExpenseList[i]);
            }

            ResultMessage resultMessage = new ResultMessage();
            resultMessage.ReturnMessage = "";
            resultMessage.ReturnStatus = "Success";

            return resultMessage;

        }


    }
}