using DuoBudget.Models.Interfaces;
using DuoBudget.Models.Parents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models
{
    public class BudgetTable : Calculation, IBudgetForm<BudgetTable>
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string DateAsString { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Decimal Amount { get; set; }
        public bool Split { get; set; }
        public Decimal Total { get; set; }//This is obtained by calculating all rows in the budget table


        public List<BudgetTable> GetExpenses(int OwnerID)
        {
            throw new NotImplementedException();
        }
    }
}