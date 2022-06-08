let baseUrl = document.getElementById('HiddenCurrentUrl').value;

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
            
        });
    }
}