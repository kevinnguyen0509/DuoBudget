using DuoBudget.Models.BudgetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoBudget.Models.Interfaces
{
    interface IBudgetForm<T>
    {
        List<T> GetExpenses();
        List<T> GetExpenses(int Month, int Year);

        ResultMessage SaveExpense(T ExpenseModel);
        ResultMessage DeleteEntry(int ID, int UserId);
    }
}
