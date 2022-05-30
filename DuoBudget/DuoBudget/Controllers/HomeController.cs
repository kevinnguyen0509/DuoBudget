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
        User LoggedInuser = new User();
        IBudgetForm<VariableExpenseModel> VariableExpenseOptions = new VariableExpenseModel();
        BudgetTable budgetTable = new BudgetTable();

        public static string LoginPath = "/Views/Home/Login/Login.cshtml";
        string IndexRoute = "~/Views/Home/Index/Index.cshtml";
        public ActionResult Index()
        {
            HttpCookie CurrentUserCookie = Request.Cookies["DuoBudgetCurrentUserCookie"];
            if (CurrentUserCookie == null)
            {
                return RedirectToAction("Login");
            }
            else
            {                        
                //Get User cookie and their expenses         
                LoggedInuser = LoggedInuser.GetLoggedInUserCookie();
                List<VariableExpenseModel> VariableExpenseList = VariableExpenseOptions.GetExpenses(LoggedInuser.ID);
                
                //IndexViewModel
                IndexViewModel indexViewModel = new IndexViewModel
                {
                    User = LoggedInuser,
                    VariableExpenseList = VariableExpenseList,
                    Categories = budgetTable.getAllCategories()
                };

                return View(IndexRoute, indexViewModel);
            }
            
        }

        public ActionResult Login()
        {
            return View(LoginPath);
        }
    }
}