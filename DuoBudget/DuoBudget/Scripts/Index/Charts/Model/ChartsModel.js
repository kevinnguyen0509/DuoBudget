
let baseUrl = document.getElementById('HiddenCurrentUrl').value;

export class ChartModel {
    constructor() {

    }
    async GetMonthlySummary() {
        const result =
        await $.ajax({
            type: 'POST',
            url: baseUrl + 'JsonChart/GetMonthlySummaryChart',
            data: {},
            success: function (SummaryChartModel) {
                return SummaryChartModel;
            }
        });
        return result;
    }

    async GetYearlySummaryChart() {
        const result =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'JsonChart/GetYearlySummaryChart',
                data: {},
                success: function (SummaryChartModel) {
                    return SummaryChartModel;
                }
            });
        return result;
    }

    async GetMonthlyCategoryChart() {
        const result =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'JsonChart/GetMonthlyCategoryChart',
                data: {},
                success: function (PieChartCategoryModel) {
                    return PieChartCategoryModel;
                }
            });
        return result;
    }

    async GetYearlyCategoriesSummaryChart() {
        const result =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'JsonChart/GetYearlyCategoriesSummaryChart',
                data: {},
                success: function (PieChartCategoryModel) {
                    return PieChartCategoryModel;
                }
            });
        return result;
    }

    async GetMonthlyAmountsForTheYearChart() {
        const result =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'JsonChart/GetMonthlyAmountsForTheYearChart',
                data: {},
                success: function (MonthlySummaryBarChartModel) {
                    return MonthlySummaryBarChartModel;
                }
            });
        return result;
    }
}