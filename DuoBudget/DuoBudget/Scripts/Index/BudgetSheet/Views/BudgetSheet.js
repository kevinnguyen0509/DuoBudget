import { VariableExpenseModel } from '../Model/VariableExpenseModel.js'
import { FixedExpenseModel } from '../Model/FixedExpenseModel.js'
import { IncomeModel } from '../Model/IncomeModel.js'
import { SplitExpenseModel } from '../Model/SplitExpenseModel.js'
import { SummaryModel } from '../Model/SummaryModel.js'
import { YearlyTotalModel } from '../Model/YearlyTotalModel.js'

let baseUrl = document.getElementById('HiddenCurrentUrl').value;
let SuccessMessage = 'Success';

let UserLoggedInID = document.getElementById('UserLoggedIn').value * 1
//Classes
let VariableExpenseOptions = new VariableExpenseModel();
let FixedExpenseOptions = new FixedExpenseModel();
let IncomeModelOptions = new IncomeModel();
let SplitExpenseOptions = new SplitExpenseModel();
let SummaryModelOptions = new SummaryModel();
let YearlyTotalOptions = new YearlyTotalModel();
/*
 * This will listener for the enter key to be pressed 
 */

$(document).ready(function () {

    const month = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    const d = new Date();
    let name = month[d.getMonth()];
    document.getElementById('CurrentMonth').innerHTML = name;

    //This also loads the Sumary Monthly totals
    SplitExpenseOptions.ReloadSplitExpenseTable();
    YearlyTotalOptions.ReloadYearlySummaryTotal();
    //Adding delete listener
    AddDeleteVariableListeners();
    AddDeleteFixedListeners();
    AddDeleteIncomeListener();
});

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




function AddDeleteIncomeListener() {
    let IncomeExpenseDelete = document.querySelectorAll('.IncomeExpenseDelete');
    for (let i = 0; i < IncomeExpenseDelete.length; i++) {
        IncomeExpenseDelete[i].addEventListener('click', function () {
            IncomeModelOptions.showLoading();
            let RowToDeleteID = IncomeExpenseDelete[i].getAttribute('Incomedeleteid') * 1;
            IncomeModelOptions.DeleteIncomeExpenseEntry(RowToDeleteID, UserLoggedInID).then(function (ResultMessage) {
                $('#IncomeTableContainer').load(baseUrl + 'home/IncomeTablePartialView', function () {
                    IncomeModelOptions.hideLoading();
                    $('#incomeTitle').focus();
                    SplitExpenseOptions.ReloadSplitExpenseTable();
                    AddDeleteIncomeListener();
                    YearlyTotalOptions.ReloadYearlySummaryTotal();
                });
            });
        });
    }
}

function AddDeleteFixedListeners() {
    let FixedExpenseDelete = document.querySelectorAll('.FixedExpenseDelete');
    for (let i = 0; i < FixedExpenseDelete.length; i++) {
        FixedExpenseDelete[i].addEventListener('click', function () {
            FixedExpenseOptions.showLoading();
            let FixedEntryID = FixedExpenseDelete[i].getAttribute('variabledeleteid') * 1;
            FixedExpenseOptions.DeleteFixedExpenseEntry(FixedEntryID, UserLoggedInID).then(function (ResultMessage) {
                $('#FixedExpenseIndexBudgetContainer').load(baseUrl + 'home/FixedTablePartialView', function () {
                    
                    $('#fixedTitle').focus();
                    SplitExpenseOptions.ReloadSplitExpenseTable();
                    $('#FixedModelBody').load(baseUrl + 'home/FixedTablePartialView', function () {
                        FixedExpenseOptions.hideLoading();
                        AddDeleteFixedListeners();
                        YearlyTotalOptions.ReloadYearlySummaryTotal();
                    });
                });
            });
        });

    }
}

function AddDeleteVariableListeners() {

    let VariableExpenseDelete = document.querySelectorAll('.VariableExpenseDelete');

    for (let i = 0; i < VariableExpenseDelete.length; i++) {
        VariableExpenseDelete[i].addEventListener('click', function () {
            let EntryID = VariableExpenseDelete[i].getAttribute('variabledeleteid') * 1;
            VariableExpenseOptions.showLoading();
            VariableExpenseOptions.DeleteVaraibleExpenseEntry(EntryID, UserLoggedInID).then(function (ResultMessage) {
                //Load Main budgetsheet
                $('#VariableExpenseIndexBudgetContainer').load(baseUrl + 'home/VariableTablePartialView', function () {
                   
                    $('#expenseitle').focus();
                    SplitExpenseOptions.ReloadSplitExpenseTable();

                    //Loads Modal Variable table
                    $('#VariableModelBody').load(baseUrl + 'home/VariableTablePartialView', function () {
                        VariableExpenseOptions.hideLoading();
                        AddDeleteVariableListeners();
                        YearlyTotalOptions.ReloadYearlySummaryTotal();
                    });

                });
            });
        });
    }
}

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
                    
                    $('#expenseitle').focus();
                    SplitExpenseOptions.ReloadSplitExpenseTable();
                    //Loads The Variable Model Table again
                    $('#VariableModelBody').load(baseUrl + 'home/VariableTablePartialView', function () {
                        VariableExpenseOptions.hideLoading();
                        AddDeleteVariableListeners();
                        YearlyTotalOptions.ReloadYearlySummaryTotal();
                    });
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
                $('#FixedModelBody').load(baseUrl + 'home/FixedTablePartialView', function () {
                    AddDeleteFixedListeners()
                    YearlyTotalOptions.ReloadYearlySummaryTotal();
                });
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
                SplitExpenseOptions.ReloadSplitExpenseTable();
                AddDeleteIncomeListener();
                YearlyTotalOptions.ReloadYearlySummaryTotal();
            });
        }
    })
}