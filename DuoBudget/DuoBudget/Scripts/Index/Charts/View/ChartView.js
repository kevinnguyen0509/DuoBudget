
let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let ChartIconNav = document.getElementById('ChartIconNav');

ChartIconNav.addEventListener('click', function () {
    $('#BudgetSheetSection').load(baseUrl + 'home/ChartsPartialView', function () {
        RenderMonthlySummaryChart();
        RenderYearlySummaryChart();
        RenderMonthlyCategoriesChart();
        RenderYearlyCategoriesChart();
    });
    
});

/*************************Summary************************************ */
function RenderMonthlySummaryChart() {
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
                { y: 20, label: "Income" },
                { y: 20, label: "Fixed" },
                { y: 20, label: "Variable" },
                { y: 20, label: "Split" },
                { y: 20, label: "Savings" },
            ]
        }]
    });
    MonthlySumaryChart.render();
}

function RenderYearlySummaryChart() {
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
                { y: 20, label: "Income" },
                { y: 20, label: "Fixed" },
                { y: 20, label: "Variable" },
                { y: 20, label: "Split" },
                { y: 20, label: "Savings" },
            ]
        }]
    });
    YearlySummaryChart.render();
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


function explodePie(e) {
    if (typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
    } else {
        e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
    }
    e.chart.render();
}
