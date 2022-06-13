using DuoBudget.Models.ChartModels;
using DuoBudget.Models.Parents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuoBudget.Controllers
{
    public class JsonChartController : Controller
    {
        // GET: JsonChart
        SummaryChartOptions SummaryChartOptions = new SummaryChartOptions();
        public JsonResult GetMonthlySummaryChart()
        {
            SummaryChartModel summaryChartModel = SummaryChartOptions.GetMonthlySummaryChart();
            return Json(summaryChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYearlySummaryChart()
        {
            SummaryChartModel summaryChartModel = SummaryChartOptions.GetYearlySummaryChart();
            return Json(summaryChartModel, JsonRequestBehavior.AllowGet);
        }
    }
}