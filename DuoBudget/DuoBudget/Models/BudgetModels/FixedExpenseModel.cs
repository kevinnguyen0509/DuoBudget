﻿using DuoBudget.DataFatory;
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
        public List<FixedExpenseModel> GetExpenses()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return GetData.getAllFixedThisMonth(curentMonth, currentYear, OwnerID);
        }

        public ResultMessage SaveExpense(FixedExpenseModel ExpenseModel)
        {
            return SaveBudgetData.SaveFixedExpenseEntry(ExpenseModel); ;
        }
    }
}