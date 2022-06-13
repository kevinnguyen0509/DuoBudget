import { SummaryModel } from '../../BudgetSheet/Model/BudgetSheet/SummaryModel.js';
import { ChartModel } from '../Model/ChartsModel.js'

let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let ChartIconNav = document.getElementById('ChartIconNav');

//Classes
let ChartModelOptions = new ChartModel();

ChartIconNav.addEventListener('click', function () {
    $('#BudgetSheetSection').load(baseUrl + 'home/ChartsPartialView', function () {
        RenderMonthlySummaryChart();
        RenderMonthlyAmountSummaryChart();
        RenderYearlySummaryChart();
        RenderYearlyAmountSummaryChart();
        RenderMonthlyCategoriesChart();
        RenderYearlyCategoriesChart();
        RenderYearlyExpensesChart();
    });
    
});

/*************************Summary************************************ */
function RenderMonthlySummaryChart() {

    ChartModelOptions.GetMonthlySummary().then(function (SummaryChartModel) {
        //console.log(SummaryChartModel);

        var MonthlySumaryChart = new CanvasJS.Chart("MonthlySummaryContainer", {
            theme: "dark2", // "light1", "light2", "dark1", "dark2"
            exportEnabled: true,
            animationEnabled: true,
            title: {
                text: "Monthly Summary"
            },
            data: [{
                type: "pie",
                startAngle: 100,
                toolTipContent: "<b>{label}</b>: {y}%",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label} - {y}%",
                dataPoints: [
                    { y: SummaryChartModel.FixedSplitTotalPercentage, label: "Fixed Expenses Split" },
                    { y: SummaryChartModel.VariableSplitSumTotalPercentage, label: "Variable Expenses Split" },
                    { y: SummaryChartModel.VariablePercentage, label: "Variable" },
                    { y: SummaryChartModel.FixedPercentage, label: "Fixed" },
                ]
            }]
        });
        MonthlySumaryChart.render();
    })
}

function RenderMonthlyAmountSummaryChart() {

    ChartModelOptions.GetMonthlySummary().then(function (SummaryChartModel) {
        //console.log(SummaryChartModel);

        var MonthlySumaryChart = new CanvasJS.Chart("MonthlyAmountSummaryContainer", {
            theme: "dark2", // "light1", "light2", "dark1", "dark2"
            exportEnabled: true,
            animationEnabled: true,
            title: {
                text: "Monthly Summary In '$'"
            },
            data: [{
                type: "pie",
                startAngle: 100,
                toolTipContent: "<b>{label}</b>: ${y}",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label} - ${y}",
                dataPoints: [
                    { y: SummaryChartModel.FixedExpenseSplitTotal, label: "Fixed Expenses Split" },
                    { y: SummaryChartModel.VariableSplitSumTotal, label: "Variable Expenses Split" },
                    { y: SummaryChartModel.VariableTotal, label: "Variable" },
                    { y: SummaryChartModel.FixedTotal, label: "Fixed" },
                ]
            }]
        });
        MonthlySumaryChart.render();
    })
}


function RenderYearlySummaryChart() {

    ChartModelOptions.GetYearlySummaryChart().then(function (SummaryChartModel) {
        //console.log(SummaryChartModel);
        var YearlySummaryChart = new CanvasJS.Chart("YearlySummaryContainer", {
            theme: "dark2", // "light1", "light2", "dark1", "dark2"
            exportEnabled: true,
            animationEnabled: true,
            title: {
                text: "Yearly Summary"
            },
            data: [{
                type: "pie",
                startAngle: 100,
                toolTipContent: "<b>{label}</b>: {y}%",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label} - {y}%",
                dataPoints: [
                    { y: SummaryChartModel.FixedSplitTotalPercentage, label: "Fixed Expenses Split" },
                    { y: SummaryChartModel.VariableSplitSumTotalPercentage, label: "Variable Expenses Split" },
                    { y: SummaryChartModel.VariablePercentage, label: "Variable" },
                    { y: SummaryChartModel.FixedPercentage, label: "Fixed" },
                ]
            }]
        });
        YearlySummaryChart.render();
    });
}

function RenderYearlyAmountSummaryChart() {

    ChartModelOptions.GetYearlySummaryChart().then(function (SummaryChartModel) {
        //console.log(SummaryChartModel);
        var YearlySummaryChart = new CanvasJS.Chart("YearlyAmountSummaryContainer", {
            theme: "dark2", // "light1", "light2", "dark1", "dark2"
            exportEnabled: true,
            animationEnabled: true,
            title: {
                text: "Yearly Summary In '$'"
            },
            data: [{
                type: "pie",
                startAngle: 100,
                toolTipContent: "<b>{label}</b>: ${y}",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label} - ${y}",
                dataPoints: [
                    { y: SummaryChartModel.FixedExpenseSplitTotal, label: "Fixed Expenses Split" },
                    { y: SummaryChartModel.VariableSplitSumTotal, label: "Variable Expenses Split" },
                    { y: SummaryChartModel.VariableTotal, label: "Variable" },
                    { y: SummaryChartModel.FixedTotal, label: "Fixed" },
                ]
            }]
        });
        YearlySummaryChart.render();
    });
}

/*************************Categories************************************ */
function RenderMonthlyCategoriesChart() {
    var MonthlyCategoriesChart = new CanvasJS.Chart("MonthlyCategoriesChartContainer", {
        theme: "dark2",
        exportFileName: "Doughnut Chart",
        exportEnabled: true,
        animationEnabled: true,
        title: {
            text: "Monthly Category Expense"
        },
        legend: {
            cursor: "pointer",
            itemclick: explodePie
        },
        data: [{
            type: "doughnut",
            innerRadius: 50,
            showInLegend: true,
            toolTipContent: "<b>{name}</b>: ${y} (#percent%)",
            indexLabel: "{name} - #percent%",
            dataPoints: [
                { y: 450, name: "Food" },
                { y: 120, name: "Insurance" },
                { y: 300, name: "Travelling" },
                { y: 800, name: "Housing" },
                { y: 150, name: "Education" },
                { y: 150, name: "Shopping" },
                { y: 250, name: "Others" }
            ]
        }]
    });
    MonthlyCategoriesChart.render();
}

function RenderYearlyCategoriesChart() {
    var YearlyCategoriesChart = new CanvasJS.Chart("YearlyCategoriesChartContainer", {
        theme: "dark2",
        exportFileName: "Doughnut Chart",
        exportEnabled: true,
        animationEnabled: true,
        title: {
            text: "Yearly Category Expense"
        },
        legend: {
            cursor: "pointer",
            itemclick: explodePie
        },
        data: [{
            type: "doughnut",
            innerRadius: 50,
            showInLegend: true,
            toolTipContent: "<b>{name}</b>: ${y} (#percent%)",
            indexLabel: "{name} - #percent%",
            dataPoints: [
                { y: 450, name: "Food" },
                { y: 120, name: "Insurance" },
                { y: 300, name: "Travelling" },
                { y: 800, name: "Housing" },
                { y: 150, name: "Education" },
                { y: 150, name: "Shopping" },
                { y: 250, name: "Others" }
            ]
        }]
    });
    YearlyCategoriesChart.render();
}


function RenderYearlyExpensesChart() {
    var YearlyExpensesChart = new CanvasJS.Chart("YearlyExpensesChartContainer", {
        animationEnabled: true,
        theme: "dark2", // "light1", "light2", "dark1", "dark2"
        title: {
            text: "Yearly Expense By Month"
        },
        axisY: {
            title: "Dollar Amount"
        },
        data: [{
            type: "column",
            showInLegend: true,
            legendMarkerColor: "grey",
            legendText: "Months",
            dataPoints: [
                { y: 300878, label: "Venezuela" },
                { y: 266455, label: "Saudi" },
                { y: 266455, label: "Saudi" },
                { y: 169709, label: "Canada" },
                { y: 158400, label: "Iran" },
                { y: 142503, label: "Iraq" },
                { y: 142503, label: "Iraq" },
                { y: 101500, label: "Kuwait" },
                { y: 101500, label: "Kuwait" },
                { y: 97800, label: "UAE" },
                { y: 97800, label: "UAE" },
                { y: 80000, label: "Russia" }
            ]
        }]
    });
    YearlyExpensesChart.render();

}


function explodePie(e) {
    if (typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
    } else {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
    }
    e.chart.render();
}
