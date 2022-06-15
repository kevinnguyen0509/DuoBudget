
let baseUrl = document.getElementById('HiddenCurrentUrl').value;

export class FixedExpenseModel {
    constructor() {

    }

    //Gets a list of fixed expenses for this month
    async GetAllFixedExpenseThisMonth() {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/getAllFixedExpenseThisMonth',
                data: {},
                success: function (FixedExpenseModel) {
                    return FixedExpenseModel;
                }
            });
        return saveResult;
    }

    async AddExpense(fixedExpenseModel) {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/SaveFixedExpenseEntry',
                data: { fixedExpenseModel },
                success: function (ResultMessage) {
                    return ResultMessage;
                }
            });
        return saveResult;
    }

    async DeleteFixedExpenseEntry(ID, UserId) {
        const DeleteResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/DeleteFixedExpenseEntry',
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

    async CopyFixedExpenseEntry() {
        const CopyResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/CopyFixedExpenseEntry',
                data: {},
                success: function (ResultMessage) {
                    return ResultMessage;
                }
            });
        return CopyResult;
    }

    CreateModel(UserId, Title, Date, Description, Category, Amount, Split) {
        const Model = {
            UserId: UserId,
            Title: Title,
            Date: Date,
            Description: Description,
            Category: Category,
            Amount: Amount,
            Split: Split
        }
        return Model;
    }
    showLoading() {
        let LoadingContainerFixed = document.getElementById('LoadingContainerFixed');
        LoadingContainerFixed.classList.remove('hide');
    }
    hideLoading() {
        let LoadingContainerFixed = document.getElementById('LoadingContainerFixed');
        setTimeout(() => { LoadingContainerFixed.classList.add('hide'); }, 750);

    }
}