using DuoBudget.DataFatory;
using DuoBudget.Models;
using DuoBudget.Models.BudgetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuoBudget.Controllers
{
    public class JsonController : Controller
    {
        VariableExpenseModel variableExpenseModel = new VariableExpenseModel();
        FixedExpenseModel fixedExpenseModel = new FixedExpenseModel();
        IncomeModel IncomeModel = new IncomeModel();
        SplitExpenseModel SplitExpenseModel = new SplitExpenseModel();
        DeleteBudgetsheetData DeleteBudgetsheetData = new DeleteBudgetsheetData();
        YearlyTotalsModel YearlyTotalsModel = new YearlyTotalsModel();
        /****************************Variable*********************************/

        /// <summary>
        /// This will Save a variable Expense Entry
        /// </summary>
        /// <param name="variableExpenseModel">Takes in a Variable Expense Model</param>
        /// <returns>ResultMessage</returns>
        public JsonResult SaveVariableExpenseEntry(VariableExpenseModel variableExpenseModel)
        {
            return Json(variableExpenseModel.SaveExpense(variableExpenseModel), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllVariableExpenseThisMonth()
        {
            return Json(variableExpenseModel.GetExpenses(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteVaraibleExpenseEntry(int id, int UserID)
        {
            ResultMessage resultMessage = variableExpenseModel.DeleteEntry(id, UserID);
            return Json(resultMessage, JsonRequestBehavior.AllowGet);
        }
        /****************************Fixed Expense*********************************/

        public JsonResult getAllFixedExpenseThisMonth()
        {
            return Json(fixedExpenseModel.GetExpenses(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveFixedExpenseEntry(FixedExpenseModel fixedExpenseModel)
        {
            return Json(fixedExpenseModel.SaveExpense(fixedExpenseModel), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteFixedExpenseEntry(int ID, int UserId)
        {
            return Json(fixedExpenseModel.DeleteEntry(ID, UserId), JsonRequestBehavior.AllowGet);
        }

        /****************************Income Expense*********************************/
        public JsonResult SaveIncomeEntry(IncomeModel incomeModel)
        {
            
            return Json(IncomeModel.SaveExpense(incomeModel), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllIncomeThisMonth()
        {
            return Json(IncomeModel.GetExpenses(), JsonRequestBehavior.AllowGet);
        }        
        public JsonResult DeleteIncomeExpenseEntry(int ID, int UserId)
        {
            ResultMessage resultMessage = IncomeModel.DeleteEntry(ID, UserId);
            return Json(resultMessage, JsonRequestBehavior.AllowGet);
        }

        /****************************Split Expense*********************************/
        public JsonResult GetAllSplitExpenseThisMonth()
        {
            return Json(SplitExpenseModel.GetExpenses(), JsonRequestBehavior.AllowGet);
        }

        /****************************Yearly Totals*********************************/
        public JsonResult GetYearlySummaryTotals()
        {
            return Json(YearlyTotalsModel.GetYearlySummaryTotals(), JsonRequestBehavior.AllowGet);
        }
    }
}