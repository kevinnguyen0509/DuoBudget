using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.BudgetModels
{
    public class PieChartCategoryModel : ResultMessage
    {
        public string Category { get; set; }
        public Decimal PercentAmount { get; set; }
        public Decimal DollarAmount { get; set; }
        public Decimal AmountTotal { get; set; }
    }
}