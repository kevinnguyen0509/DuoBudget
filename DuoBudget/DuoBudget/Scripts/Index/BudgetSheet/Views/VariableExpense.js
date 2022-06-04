import { VariableExpenseModel } from '../Model/VariableExpenseModel.js';


document.addEventListener('keyup', function (e) {
    if (e.keyCode == 13) {
        let UserId = document.getElementById('UserLoggedIn');
        let Title = document.getElementById('expenseitle');
        let expenseDate = document.getElementById('expenseDate');
        let expenseDescription = document.getElementById('expenseDescription');
        let expenseCategories = document.getElementById('expenseCategories');
        let expenseAmount = document.getElementById('expenseAmount');
        let expenseSplitCheckBox = document.getElementById('expenseSplitCheckBox');

        let VariableExpenseOptions = new VariableExpenseModel()
        let VariableModel = VariableExpenseOptions.CreateModel(UserId.value, Title.value, expenseDate.value,
            expenseDescription.value, expenseCategories.value, expenseAmount.value, expenseSplitCheckBox.value);

        if (Title.value != null || Title.value == ''){
            VariableExpenseOptions.AddExpense(VariableModel).then(function (ResultMessage) {
                VariableExpenseOptions.GetAllExpenseThisMonth().then(function (VariableExpenseList) {
                    console.log(VariableExpenseList);
                });
            });
        }



    }

})
   
