﻿using DuoBudget.Models.BudgetModels;
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

        /*******************Categories***********************/
        public JsonResult GetMonthlyCategoryChart()
        {
            List<PieChartCategoryModel> PieChartCategoryModel = pieChartCategoryOptions.GetMonthlyCategoryChart();
            return Json(PieChartCategoryModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYearlyCategoriesSummaryChart()
        {
            List<PieChartCategoryModel> PieChartCategoryModel = pieChartCategoryOptions.GetYearlyCategoriesSummaryChart();
            return Json(PieChartCategoryModel, JsonRequestBehavior.AllowGet);
        }
    }
}