import { SummaryModel } from '../BudgetSheet/SummaryModel.js'
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

    /*
        This Method will Reload the split table as well as calculate the monthly summary. 
        The reason why it also reloads the Monthly summary is because it needs to wait for the split
        expenses to be done grabbing the new data from the database..once all the data is gathered 
        it will be able to grab the updated info and do the calculations
     */
    ReloadSplitExpenseTable() {
        $('#SplitExpenseTableContainer').load(baseUrl + 'home/SplitTablePartialView', function () {
            SummaryModelOption.ReloadMonthlySummaryLabels();
        });
    }
}