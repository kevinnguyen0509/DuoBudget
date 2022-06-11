using DuoBudget.Models;
using DuoBudget.Models.BudgetModels;
using DuoBudget.Models.Interfaces;
using DuoBudget.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuoBudget.Controllers
{
    public class HomeController : Controller
    {
        //Variables to communicate with Database
        User LoggedInuser = new User();    
        BudgetTable budgetTable = new BudgetTable();
        IBudgetForm<VariableExpenseModel> VariableExpenseOptions = new VariableExpenseModel();
        IBudgetForm<FixedExpenseModel> FixedExpenseOptions = new FixedExpenseModel();
        IBudgetForm<SplitExpenseModel> SplitExpenseOptions = new SplitExpenseModel();
        IBudgetForm<IncomeModel> IncomeModelOptions = new IncomeModel();

        //Static paths
        public static string LoginPath = "/Views/Home/Login/Login.cshtml";
        public static string IndexRoute = "~/Views/Home/Index/Index.cshtml";
        public static string VariableExpenseTablePath = "~/Views/Home/Index/_VariableExpenseTable.cshtml";
        public static string FixedExpenseTablePath = "~/Views/Home/Index/_FixedExpenseTable.cshtml";
        public static string IncomeTablePath = "~/Views/Home/Index/_IncomeTable.cshtml";
        public static string SplitTablePath = "~/Views/Home/Index/_SplitExpenseTable.cshtml";
        public static string ChartsParentPath = "~/Views/Home/Charts/Parent/Charts.cshtml";

        public ActionResult Index()
        {
            //Add test
            //Checks to see if the user is logged in.
            HttpCookie CurrentUserCookie = Request.Cookies["DuoBudgetCurrentUserCookie"];
            
            
            if (CurrentUserCookie == null)
                return RedirectToAction("Login");
                                   
            IndexViewModel indexViewModel = new IndexViewModel
            {
                User = LoggedInuser.GetLoggedInUserCookie(),
                VariableExpenseList = VariableExpenseOptions.GetExpenses(),
                Categories = budgetTable.getAllCategories(),
                FixedExpenses = FixedExpenseOptions.GetExpenses(),
                SplitExpenses = SplitExpenseOptions.GetExpenses(),
                IncomeThisMonth = IncomeModelOptions.GetExpenses()
            };

            return View(IndexRoute, indexViewModel);

            
        }

        /************************Varaible Expense**********************/
        public ActionResult VariableTablePartialView()
        {

            IndexViewModel indexViewModel = new IndexViewModel
            {
                User = LoggedInuser.GetLoggedInUserCookie(),
                VariableExpenseList = VariableExpenseOptions.GetExpenses(),
                Categories = budgetTable.getAllCategories(),
                FixedExpenses = FixedExpenseOptions.GetExpenses(),
                SplitExpenses = SplitExpenseOptions.GetExpenses(),
                IncomeThisMonth = IncomeModelOptions.GetExpenses()
            };

            return PartialView(VariableExpenseTablePath, indexViewModel);

        }

        /************************Fixed Expense**********************/
        public ActionResult FixedTablePartialView()
        {

            IndexViewModel indexViewModel = new IndexViewModel
            {
                User = LoggedInuser.GetLoggedInUserCookie(),
                VariableExpenseList = VariableExpenseOptions.GetExpenses(),
                Categories = budgetTable.getAllCategories(),
                FixedExpenses = FixedExpenseOptions.GetExpenses(),
                SplitExpenses = SplitExpenseOptions.GetExpenses(),
                IncomeThisMonth = IncomeModelOptions.GetExpenses()
            };

            return PartialView(FixedExpenseTablePath, indexViewModel);

        }

        /************************Income Expense**********************/
        public ActionResult IncomeTablePartialView()
        {

            IndexViewModel indexViewModel = new IndexViewModel
            {
                User = LoggedInuser.GetLoggedInUserCookie(),
                VariableExpenseList = VariableExpenseOptions.GetExpenses(),
                Categories = budgetTable.getAllCategories(),
                FixedExpenses = FixedExpenseOptions.GetExpenses(),
                SplitExpenses = SplitExpenseOptions.GetExpenses(),
                IncomeThisMonth = IncomeModelOptions.GetExpenses()
            };

            return PartialView(IncomeTablePath, indexViewModel);

        }

        /************************Split Expense**********************/
        public ActionResult SplitTablePartialView()
        {

            IndexViewModel indexViewModel = new IndexViewModel
            {
                User = LoggedInuser.GetLoggedInUserCookie(),
                VariableExpenseList = VariableExpenseOptions.GetExpenses(),
                Categories = budgetTable.getAllCategories(),
                FixedExpenses = FixedExpenseOptions.GetExpenses(),
                SplitExpenses = SplitExpenseOptions.GetExpenses(),
                IncomeThisMonth = IncomeModelOptions.GetExpenses()
            };

            return PartialView(SplitTablePath, indexViewModel);

        }

        /************************ChartParent**********************/
        public ActionResult ChartsPartialView()
        {

            return PartialView(ChartsParentPath);

        }


        /************************Login**********************/
        public ActionResult Login()
        {
            return View(LoginPath);
        }
    }
}