using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.Parents
{
    public class MonthlySummaryBarChartModel : ResultMessage
    {
        public Decimal VariableExpense { get; set; }
        public Decimal FixedExpense { get; set; }
        public Decimal SpltExpense { get; set; }
        public Decimal Total { get; set; }
    }
}