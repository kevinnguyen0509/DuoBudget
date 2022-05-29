using DuoBudget.DataFatory.GetData;
using DuoBudget.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models
{
    public class BudgetTable : ResultMessage
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


        /// <summary>
        /// This will calcuate the total for the specific budget item
        /// </summary>
        /// <param name="ListOfNumbers">Takes in a list of expenses</param>
        /// <returns>A total after adding up everything from the list</returns>
        public int CalculateBudgetTableTotal(List<int> ListOfNumbers)
        {
            int total = 0;
            return total;
        }


    }
}