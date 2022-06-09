using DuoBudget.DataFatory.GetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.BudgetModels
{
    public class YearlyTotalsModel : ResultMessage
    {
        GetBudgetSheetData getBudgetSheetData = new GetBudgetSheetData();
        public Decimal YearlyTotal { get; set; }
        public Decimal YearlyIncome { get; set; }
        public Decimal YearlyVariable { get; set; }
        public Decimal YearlyFixed { get; set; }
        public Decimal YearlySplit { get; set; }


        public YearlyTotalsModel GetYearlySummaryTotals()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return getBudgetSheetData.getAllYearlyTotals(OwnerID, currentYear);
        }
    }
}

