
let baseUrl = document.getElementById('HiddenCurrentUrl').value;

export class YearlyTotalModel {
    constructor() {

    }
    async GetYearlyTotals() {
        const Result =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/GetYearlySummaryTotals',
                success: function (YearlyTotalModelResult) {
                    return YearlyTotalModelResult;
                }
            });
        return Result;
    }

    ReloadYearlySummaryTotal() {
        this.GetYearlyTotals().then(function (YearlyTotals) {
            let currentYear = new Date().getFullYear();
            let YearlyTotal = YearlyTotals.YearlyTotal;
            let YearlyIncome = YearlyTotals.YearlyIncome;
            let YearlyVariable = YearlyTotals.YearlyVariable * 1;
            let YearlyFixed = YearlyTotals.YearlyFixed * 1;
            let YearlySplit = YearlyTotals.YearlySplit;

            document.getElementById('YearlyTotal').innerHTML = YearlyTotal;
            document.getElementById('YearlySummaryCurrentYear').innerHTML = currentYear;
            document.getElementById('YearlySummaryIncome').innerHTML = YearlyIncome;
            document.getElementById('YearlySummaryTotalExpenses').innerHTML = (YearlyVariable + YearlyFixed);
            document.getElementById('YearlySummarySplit').innerHTML = YearlySplit;
        });
    }
}