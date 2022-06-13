using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Parents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.ChartModels
{
    public class SummaryChartOptions : SummaryChartModel
    {
        GetChartsData getChartData = new GetChartsData();
        public SummaryChartModel GetMonthlySummaryChart()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int curentMonth = Int32.Parse(DateTime.Now.ToString("MM"));
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return getChartData.GetMonthlySummaryChart(OwnerID, curentMonth, currentYear);
        }

        public SummaryChartModel GetYearlySummaryChart()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            return getChartData.GetYearlySummaryChart(OwnerID, currentYear);
        }
    }
}