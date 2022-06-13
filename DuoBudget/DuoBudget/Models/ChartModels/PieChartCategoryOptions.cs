using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.BudgetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.ChartModels
{
    public class PieChartCategoryOptions : PieChartCategoryModel
    {
        GetChartsData getChartsData = new GetChartsData();
        public List<PieChartCategoryModel> GetMonthlyCategoryChart()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return getChartsData.GetMonthlyCategoriesSummaryChart(OwnerID, curentMonth, currentYear);
        }

        public List<PieChartCategoryModel> GetYearlyCategoriesSummaryChart()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return getChartsData.GetYearlyCategoriesSummaryChart(OwnerID, currentYear);
        }
    }
}