using DuoBudget.Models.BudgetModels;
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
        /***************Sumary*******************/
        // GET: JsonChart
        SummaryChartOptions SummaryChartOptions = new SummaryChartOptions();
        PieChartCategoryOptions pieChartCategoryOptions = new PieChartCategoryOptions();
        MonthlyAmountsForTheYearOption MonthlyAmountsForTheYearOption = new MonthlyAmountsForTheYearOption();
        public JsonResult GetMonthlySummaryChart()
        {
            SummaryChartModel summaryChartModel = SummaryChartOptions.GetMonthlySummaryChart();
            return Json(summaryChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecifcMonthlySummaryChart(int Month, int Year)
        {
            SummaryChartModel summaryChartModel = SummaryChartOptions.GetMonthlySummaryChart(Month, Year);
            return Json(summaryChartModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYearlySummaryChart()
        {
            SummaryChartModel summaryChartModel = SummaryChartOptions.GetYearlySummaryChart();
            return Json(summaryChartModel, JsonRequestBehavior.AllowGet);
        }

        /*******************Categories***********************/
        public JsonResult GetMonthlyCategoryChart()
        {
            List<PieChartCategoryModel> PieChartCategoryModel = pieChartCategoryOptions.GetMonthlyCategoryChart();
            return Json(PieChartCategoryModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecificMonthlyCategoryChart(int Month, int Year)
        {
            List<PieChartCategoryModel> PieChartCategoryModel = pieChartCategoryOptions.GetMonthlyCategoryChart(Month, Year);
            return Json(PieChartCategoryModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYearlyCategoriesSummaryChart()
        {
            List<PieChartCategoryModel> PieChartCategoryModel = pieChartCategoryOptions.GetYearlyCategoriesSummaryChart();
            return Json(PieChartCategoryModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMonthlyAmountsForTheYearChart()
        {
            List<MonthlySummaryBarChartModel> MonthlySummaryBarChartModel = MonthlyAmountsForTheYearOption.GetMonthlyAmountsForTheYearChart();
            return Json(MonthlySummaryBarChartModel, JsonRequestBehavior.AllowGet);
        }
    }
}