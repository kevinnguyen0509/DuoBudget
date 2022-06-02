using DuoBudget.DataFatory;
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
        // GET: Json
       
        /// <summary>
        /// This will Save a variable Expense Entry
        /// </summary>
        /// <param name="variableExpenseModel">Takes in a Variable Expense Model</param>
        /// <returns>ResultMessage</returns>
        public JsonResult SaveVariableExpenseEntry(VariableExpenseModel variableExpenseModel)
        {

            return Json(variableExpenseModel.SaveExpense(variableExpenseModel), JsonRequestBehavior.AllowGet);
        }
    }
}