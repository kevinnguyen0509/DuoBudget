let baseUrl = document.getElementById('HiddenCurrentUrl');


export class VariableExpenseModel{
    constructor() {

    }

    async AddExpense(variableExpenseModel) {
        const saveResult =
            $.ajax({
                type: 'POST',
                url: baseUrl.value + 'Json/SaveVariableExpenseEntry',
                data: { variableExpenseModel },
                success: function (ResultMessage) {
                    return ResultMessage;
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
}