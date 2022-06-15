import { SummaryModel } from '../Model/BudgetSheet/SummaryModel.js'
import { YearlyTotalModel } from '../Model/BudgetSheet/YearlyTotalModel.js'

let SummaryModelOptions = new SummaryModel();
let YearlyTotalOptions = new YearlyTotalModel();


//This also loads the Sumary Monthly totals
SummaryModelOptions.ReloadMonthlySummaryLabels();
YearlyTotalOptions.ReloadYearlySummaryTotal();