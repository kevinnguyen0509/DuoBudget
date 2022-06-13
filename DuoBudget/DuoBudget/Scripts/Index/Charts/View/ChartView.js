import { SummaryModel } from '../../BudgetSheet/Model/BudgetSheet/SummaryModel.js';
import { ChartModel } from '../Model/ChartsModel.js'

let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let ChartIconNav = document.getElementById('ChartIconNav');

//Classes
let ChartModelOptions = new ChartModel();

ChartIconNav.addEventListener('click', function () {
    $('#BudgetSheetSection').load(baseUrl + 'home/ChartsPartialView', function () {
        RenderMonthlySummaryChart();

        RenderYearlySummaryChart();

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
                toolTipContent: "<b>{label}</b> - {y}% - (${dollarAmount})",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label} - {y}% - (${dollarAmount})",
                dataPoints: [
                    { y: SummaryChartModel.FixedSplitTotalPercentage, label: "Fixed Expenses Split", dollarAmount: SummaryChartModel.FixedExpenseSplitTotal},
                    { y: SummaryChartModel.VariableSplitSumTotalPercentage, label: "Variable Expenses Split", dollarAmount: SummaryChartModel.VariableSplitSumTotal},
                    { y: SummaryChartModel.VariablePercentage, label: "Variable", dollarAmount: SummaryChartModel.VariableTotal},
                    { y: SummaryChartModel.FixedPercentage, label: "Fixed", dollarAmount: SummaryChartModel.FixedTotal},
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
                toolTipContent: "<b>{label}</b> - {y}% - (${dollarAmount})",
                showInLegend: "true",
                legendText: "{label}",
                indexLabelFontSize: 16,
                indexLabel: "{label} - {y}% - (${dollarAmount})",
                dataPoints: [
                    { y: SummaryChartModel.FixedSplitTotalPercentage, label: "Fixed Expenses Split", dollarAmount: SummaryChartModel.FixedExpenseSplitTotal },
                    { y: SummaryChartModel.VariableSplitSumTotalPercentage, label: "Variable Expenses Split", dollarAmount: SummaryChartModel.VariableSplitSumTotal },
                    { y: SummaryChartModel.VariablePercentage, label: "Variable", dollarAmount: SummaryChartModel.VariableTotal },
                    { y: SummaryChartModel.FixedPercentage, label: "Fixed", dollarAmount: SummaryChartModel.FixedTotal },
                ]
            }]
        });
        YearlySummaryChart.render();
    });
}


/*************************Categories************************************ */
function RenderMonthlyCategoriesChart() {
    ChartModelOptions.GetMonthlyCategoryChart().then(function (PieChartCategoryModel) {
         //console.log(PieChartCategoryModel);

        let CategoryArray = [];
        for (let i = 0; i < PieChartCategoryModel.length; i++) {
            CategoryArray.push({ y: PieChartCategoryModel[i].PercentAmount, name: PieChartCategoryModel[i].Category, dollaramount: PieChartCategoryModel[i].DollarAmount})
        }

        //console.log(CategoryArray)
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
                toolTipContent: "<b>{name}</b> - {y}% - (${dollaramount})",
                indexLabel: "{name} - {y}% - (${dollaramount})",
                dataPoints: CategoryArray
            }]
        });
        MonthlyCategoriesChart.render();

    })

}

function RenderYearlyCategoriesChart() {

    ChartModelOptions.GetYearlyCategoriesSummaryChart().then(function (PieChartCategoryModel) {
        //console.log(PieChartCategoryModel);

        let CategoryArray = [];
        for (let i = 0; i < PieChartCategoryModel.length; i++) {
            CategoryArray.push({ y: PieChartCategoryModel[i].PercentAmount, name: PieChartCategoryModel[i].Category, dollaramount: PieChartCategoryModel[i].DollarAmount })
        }

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
                toolTipContent: "<b>{name}</b> - {y}% - (${dollaramount})",
                indexLabel: "{name} - {y}% - (${dollaramount})",
                dataPoints: CategoryArray
            }]
        });
        YearlyCategoriesChart.render();
    });


}


function RenderYearlyExpensesChart() {

    ChartModelOptions.GetMonthlyAmountsForTheYearChart().then(function (MonthlySummaryBarChartModel) {
        //console.log(MonthlySummaryBarChartModel)
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
                    { y: MonthlySummaryBarChartModel[0].Total, label: "January" },
                    { y: MonthlySummaryBarChartModel[1].Total, label: "February" },
                    { y: MonthlySummaryBarChartModel[2].Total, label: "March" },
                    { y: MonthlySummaryBarChartModel[3].Total, label: "April" },
                    { y: MonthlySummaryBarChartModel[4].Total, label: "May" },
                    { y: MonthlySummaryBarChartModel[5].Total, label: "June" },
                    { y: MonthlySummaryBarChartModel[6].Total, label: "July" },
                    { y: MonthlySummaryBarChartModel[7].Total, label: "August" },
                    { y: MonthlySummaryBarChartModel[8].Total, label: "September" },
                    { y: MonthlySummaryBarChartModel[9].Total, label: "October" },
                    { y: MonthlySummaryBarChartModel[10].Total, label: "November" },
                    { y: MonthlySummaryBarChartModel[11].Total, label: "December" }
                ]
            }]
        });
        YearlyExpensesChart.render();
    });

}


function explodePie(e) {
    if (typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
    } else {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
    }
    e.chart.render();
}
