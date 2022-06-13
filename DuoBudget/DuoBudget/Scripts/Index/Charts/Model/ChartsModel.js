
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
}