﻿using DuoBudget.DataFatory;
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
        SaveBudgetData SaveBudget = new SaveBudgetData();
        DeleteBudgetsheetData DeleteBudgetsheetData = new DeleteBudgetsheetData();

        public ResultMessage DeleteEntry(int ID, int UserId)
        {
            return DeleteBudgetsheetData.DeleteIncomeExpenseEntry(ID, UserId);
        }

        //This will get all the Incomes
        public List<IncomeModel> GetExpenses()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllIncomeListThisMonth(curentMonth, currentYear, OwnerID);
        }

        public List<IncomeModel> GetExpenses(int Month, int Year)
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Month;
            int currentYear = Year;
            return GetData.getAllIncomeListThisMonth(curentMonth, currentYear, OwnerID);
        }

        public ResultMessage SaveExpense(IncomeModel expenseModel)
        {
            ResultMessage returnMessage = SaveBudget.SaveIncomeEntry(expenseModel);
            return returnMessage;
        }
    }
}