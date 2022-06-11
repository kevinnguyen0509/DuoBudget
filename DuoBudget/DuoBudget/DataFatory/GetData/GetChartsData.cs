using DuoBudget.Models.BudgetModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuoBudget.DataFatory.GetData
{
    public class GetChartsData
    {
        public PieChartModel GetMonthlyCategoriesSummaryChart(int UserID, int month, int year)
        {

            PieChartModel PieChartModel = new PieChartModel();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetMonthlyCategoriesSummaryChart]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", UserID);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                if (SQLRec.Read())
                {
                    PieChartModel.Category = SQLRec.GetString(SQLRec.GetOrdinal("Category"));
                    PieChartModel.PercentAmount = SQLRec.GetDecimal(SQLRec.GetOrdinal("PercentAmount"));
                    PieChartModel.DollarAmount = SQLRec.GetDecimal(SQLRec.GetOrdinal("DollarAmount"));
                    PieChartModel.AmountTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("AmountTotal"));
                   
                }
            }
            catch (Exception e)
            {

                PieChartModel.ReturnMessage = e.Message;
                PieChartModel.ReturnStatus = "Failed";
                PieChartModel.newId = -1;

            }
            finally
            {
                SQLRec.Close();
                SQLConn.Close();
            }

            return PieChartModel;
        }
    }
}