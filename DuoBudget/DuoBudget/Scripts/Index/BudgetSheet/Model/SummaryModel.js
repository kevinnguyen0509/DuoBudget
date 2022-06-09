

export class SummaryModel {
    constructor() {

    }
    ReloadMonthlySummaryLabels() {
        //Totals
        let VariableExpenseTotal = document.getElementById('VariableExpenseTotal');
        let SplitExpenseTotalLabel = document.getElementById('SplitExpenseTotalLabel');
        let FixedExpenseTotalLabel = document.getElementById('FixedExpenseTotalLabel');
        let IncomeExpenseTotalLabel = document.getElementById('IncomeExpenseTotalLabel');

        //Monthly Summary Labels
        let incomeSummaryMonthLbl = document.getElementById('incomeSummaryMonthLbl');
        let ExpenseSummaryMonthLbl = document.getElementById('ExpenseSummaryMonthLbl');
        let SplitSummaryMonthlyLbl = document.getElementById('SplitSummaryMonthlyLbl');
        let TotalSumaryMonthlyLbl = document.getElementById('TotalSumaryMonthlyLbl');


        incomeSummaryMonthLbl.innerHTML = IncomeExpenseTotalLabel.innerHTML;
        ExpenseSummaryMonthLbl.innerHTML = ((FixedExpenseTotalLabel.innerHTML * 1) + (VariableExpenseTotal.innerHTML * 1)).toFixed(2);
        SplitSummaryMonthlyLbl.innerHTML = SplitExpenseTotalLabel.innerHTML;
        TotalSumaryMonthlyLbl.innerHTML = ((incomeSummaryMonthLbl.innerHTML * 1) - (ExpenseSummaryMonthLbl.innerHTML * 1) + (SplitExpenseTotalLabel.innerHTML * 1)).toFixed(2);
        
    }
}