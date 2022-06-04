let baseUrl = document.getElementById('HiddenCurrentUrl').value;


export class VariableExpenseModel{
    constructor() {

    }

    async AddExpense(variableExpenseModel) {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/SaveVariableExpenseEntry',
                data: { variableExpenseModel },
                success: function (ResultMessage) {
                    return ResultMessage;
                }
            });
        return saveResult;
    }

    async GetAllExpenseThisMonth() {
        const saveResult =
            await $.ajax({
                type: 'POST',
                url: baseUrl + 'Json/getAllVariableExpenseThisMonth',
                data: { },
                success: function (VariableExpenseModel) {
                    return VariableExpenseModel;
                }
            });
        return saveResult;
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
        let LoadingContainerVariable = document.getElementById('LoadingContainerVariable');
        LoadingContainerVariable.classList.remove('hide');
    }
    hideLoading() {
        let LoadingContainerVariable = document.getElementById('LoadingContainerVariable');
        setTimeout(() => { LoadingContainerVariable.classList.add('hide'); }, 750);
       
    }
}