using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Parents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.ChartModels
{
    public class MonthlyAmountsForTheYearOption : MonthlySummaryBarChartModel
    {
        GetChartsData getChartsData = new GetChartsData();
        public List<MonthlySummaryBarChartModel> GetMonthlyAmountsForTheYearChart()
        {
            HttpCookie UserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
            int OwnerID = Int32.Parse(UserCookie.Values["ID"]);

            List<MonthlySummaryBarChartModel> MonthlyAmountList = getChartsData.GetMonthlyAmountsForTheYearChart(OwnerID);
            return MonthlyAmountList;
        }
    }
}