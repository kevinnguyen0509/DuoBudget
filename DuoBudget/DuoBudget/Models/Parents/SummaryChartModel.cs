using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models.Parents
{
    public class SummaryChartModel : ResultMessage
    {
        public Decimal VariableTotal { get; set; }
        public Decimal VariablePercentage { get; set; }
        public Decimal FixedTotal { get; set; }
        public Decimal FixedPercentage { get; set; }
        public Decimal FixedExpenseSplitTotal { get; set; }
        public Decimal FixedSplitTotalPercentage { get; set; }
        public Decimal VariableSplitSumTotal { get; set; }
        public Decimal VariableSplitSumTotalPercentage { get; set; }
        public Decimal Total { get; set; }
    }
}