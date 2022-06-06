import { VariableExpenseModel } from '../Model/VariableExpenseModel.js';

let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let SuccessMessage = 'Success';
//Classes
let VariableExpenseOptions = new VariableExpenseModel();

/*
 * This will listener for the enter key to be pressed 
 */
document.addEventListener('keyup', function (e) {
    if (e.keyCode == 13) {

        let Title = document.getElementById('expenseitle');//This is the Variable expense title

        if (Title.value != null || Title.value == '') {//This is to save the variable expense
            VariableExpenseOptions.showLoading();
            saveVariableEntry(Title);
        }
    }
})

function saveVariableEntry(Title) {

    let UserId = document.getElementById('UserLoggedIn');
    let expenseDate = document.getElementById('expenseDate');
    let expenseDescription = document.getElementById('expenseDescription');
    let expenseCategories = document.getElementById('expenseCategories');
    let expenseAmount = document.getElementById('expenseAmount');
    let expenseSplitCheckBox = document.getElementById('expenseSplitCheckBox');


    let VariableModel = VariableExpenseOptions.CreateModel(UserId.value, Title.value, expenseDate.value,
        expenseDescription.value, expenseCategories.value, expenseAmount.value, expenseSplitCheckBox.checked);

    VariableExpenseOptions.AddExpense(VariableModel).then(function (ResultMessage) {//Adds new item to variable table

        if (ResultMessage.ReturnStatus.toUpperCase() == SuccessMessage.toUpperCase()) {
            VariableExpenseOptions.GetAllExpenseThisMonth().then(function (VariableExpenseList) {//Gets new Exepense

                //Loads main budgetsheet table again
                $('#VariableExpenseIndexBudgetContainer').load(baseUrl + 'home/VariableTablePartialView', function () {
                    VariableExpenseOptions.hideLoading();
                });

                //Loads The Variable Model Table again
                $('#VariableModelBody').load(baseUrl + 'home/VariableTablePartialView', function () {

                });
            });
        }
        else {
            alert(ResultMessage.ReturnMessage);
        }

    });
}

   
