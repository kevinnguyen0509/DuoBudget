import { SummaryModel } from '../Model/SummaryModel.js'
let baseUrl = document.getElementById('HiddenCurrentUrl').value;

let SummaryModelOption = new SummaryModel();

export class SplitExpenseModel {
    constructor() {

    }

    //Gets a list of fixed expenses for this month
    async GetAllSplitExpenseThisMonth() {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/GetAllSplitExpenseThisMonth',
                data: {},
                success: function (SplitExpenses) {
                    return SplitExpenses;
                }
            });
        return saveResult;
    }

    ReloadSplitExpenseTable() {
        $('#SplitExpenseTableContainer').load(baseUrl + 'home/SplitTablePartialView', function () {
            SummaryModelOption.ReloadMonthlySummaryLabels();
        });
    }
}