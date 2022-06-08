import { VariableExpenseModel } from '../Model/VariableExpenseModel.js'
import { FixedExpenseModel } from '../Model/FixedExpenseModel.js'
import { IncomeModel } from '../Model/IncomeModel.js'
import { SplitExpenseModel } from '../Model/SplitExpenseModel.js'

let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let SuccessMessage = 'Success';
//Classes
let VariableExpenseOptions = new VariableExpenseModel();
let FixedExpenseOptions = new FixedExpenseModel();
let IncomeModelOptions = new IncomeModel();
let SplitExpenseOptions = new SplitExpenseModel();
/*
 * This will listener for the enter key to be pressed 
 */
document.addEventListener('keyup', function (e) {
    if (e.keyCode == 13) {

        //Variable expense and date
        let Title = document.getElementById('expenseitle');//This is the Variable expense title
        let expenseDateCheck = document.getElementById('expenseDate');

        //FixedTitle and date
        let FixedTitle = document.getElementById('fixedTitle');
        let fixedDateCheck = document.getElementById('fixedDate')

        //incomeTitle and date
        let incomeTitle = document.getElementById('incomeTitle');
        let incomeDateCheck = document.getElementById('incomeDate');

        if ((Title.value != null && Title.value != '') && (expenseDateCheck.value != '')) {//This is to save the variable expense
            VariableExpenseOptions.showLoading();
            saveVariableEntry(Title);
        }

        else if ((FixedTitle.value != null && FixedTitle.value != '') && (fixedDateCheck.value != '')) {
            FixedExpenseOptions.showLoading();
            saveFixedEntry(FixedTitle);
        }

        else if ((incomeTitle.value != '' && incomeTitle.value != null) && (incomeDateCheck.value != '')) {

            IncomeModelOptions.showLoading();
            saveIncomeEntry(incomeTitle);
        
        }
        else {
            VariableExpenseOptions.hideLoading();
            alert("Make sure the 'Title' AND 'Date' fields are filled inside the current budget table you are adding to.")
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
                    $('#expenseitle').focus();
                    SplitExpenseOptions.ReloadSplitExpenseTable();
                });

                //Loads The Variable Model Table again
                $('#VariableModelBody').load(baseUrl + 'home/VariableTablePartialView', function () {

                });
            });
        }
        else {
            VariableExpenseOptions.hideLoading();
            alert(ResultMessage.ReturnMessage);
        }

    });
}

   
function saveFixedEntry(FixedTitle) {
    let UserId = document.getElementById('UserLoggedIn');
    let fixedDate = document.getElementById('fixedDate');
    let fixedDescription = document.getElementById('fixedDescription');
    let fixedCategories = document.getElementById('fixedCategories');
    let fixedAmount = document.getElementById('fixedAmount');
    let fixedExpenseClickCbo = document.getElementById('fixedExpenseClickCbo');

    let fixedExpenseModel = FixedExpenseOptions.CreateModel(UserId.value, FixedTitle.value, fixedDate.value, fixedDescription.value,
        fixedCategories.value, fixedAmount.value, fixedExpenseClickCbo.checked);

    FixedExpenseOptions.AddExpense(fixedExpenseModel).then(function (ResultMessage) {
        if (ResultMessage.ReturnStatus.toUpperCase() == SuccessMessage.toUpperCase()) {
            $('#FixedExpenseIndexBudgetContainer').load(baseUrl + 'home/FixedTablePartialView', function () {
                FixedExpenseOptions.hideLoading();          
                $('#fixedTitle').focus();
                SplitExpenseOptions.ReloadSplitExpenseTable();
            });

            $('#FixedModelBody').load(baseUrl + 'home/FixedTablePartialView', function () {

            });
        }

        else {
            FixedExpenseOptions.hideLoading();
            alert(ResultMessage.ReturnMessage);
        }
    });
}

function saveIncomeEntry(incomeTitle) {
    let userId = document.getElementById('UserLoggedIn');
    let incomeDate = document.getElementById('incomeDate');
    let incomeDescription = document.getElementById('incomeDescription');
    let incomeAmount = document.getElementById('incomeAmount');

    let incomeModelEntry = IncomeModelOptions.CreateModel(userId.value, incomeTitle.value, incomeDate.value,
        incomeDescription.value, incomeAmount.value);

    IncomeModelOptions.AddExpense(incomeModelEntry).then(function (ResultMessage) {
        if (ResultMessage.ReturnStatus.toUpperCase() == SuccessMessage.toUpperCase()) {
            $('#IncomeTableContainer').load(baseUrl + 'home/IncomeTablePartialView', function () {
                IncomeModelOptions.hideLoading();
                $('#incomeTitle').focus();
            });
        }
    })
}