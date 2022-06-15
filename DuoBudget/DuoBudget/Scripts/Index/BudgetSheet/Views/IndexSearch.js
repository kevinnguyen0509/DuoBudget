import { SummaryModel } from '../Model/BudgetSheet/SummaryModel.js'
import { YearlyTotalModel } from '../Model/BudgetSheet/YearlyTotalModel.js'

let SummaryModelOptions = new SummaryModel();
let YearlyTotalOptions = new YearlyTotalModel();

const month = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const d = new Date();
let name = month[d.getMonth()];
document.getElementById('CurrentMonth').innerHTML = name;

//This also loads the Sumary Monthly totals
SummaryModelOptions.ReloadMonthlySummaryLabels();
YearlyTotalOptions.ReloadYearlySummaryTotal();