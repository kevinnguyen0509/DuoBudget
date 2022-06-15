let baseUrl = document.getElementById('HiddenCurrentUrl').value;

export class IncomeModel {
    constructor() {

    }

    async AddExpense(IncomeModel) {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/SaveIncomeEntry',
                data: { IncomeModel },
                success: function (ResultMessage) {
                    return ResultMessage;
                }
            });
        return saveResult;
    }

    async GetAllIncomeThisMonth() {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/GetAllIncomeThisMonth',
                data: {},
                success: function (IncomeModel) {
                    return IncomeModel;
                }
            });
        return saveResult;
    }

    async DeleteIncomeExpenseEntry(ID, UserId) {
        const DeleteResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/DeleteIncomeExpenseEntry',
                data: {
                    ID,
                    UserId
                },
                success: function (ResultMessage) {
                    return ResultMessage;
                }
            });
        return DeleteResult;
    }

    CreateModel(UserId, Title, Date, Description, Amount) {
        const Model = {
            UserId: UserId,
            Title: Title,
            Date: Date,
            Description: Description,
            Amount: Amount,

        }
        return Model;
    }

    showLoading() {
        let LoadingContainerIncome = document.getElementById('LoadingContainerIncome');
        LoadingContainerIncome.classList.remove('hide');
    }

    hideLoading() {
        let LoadingContainerIncome = document.getElementById('LoadingContainerIncome');
        setTimeout(() => { LoadingContainerIncome.classList.add('hide'); }, 750);
    }
}