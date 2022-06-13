using DuoBudget.Models.BudgetModels;
using DuoBudget.Models.ChartModels;
using DuoBudget.Models.Parents;
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

        /*********************Categories*************************/
        public List<PieChartCategoryModel> GetMonthlyCategoriesSummaryChart(int UserID, int month, int year)
        {

            List<PieChartCategoryModel> PieChartModel = new List<PieChartCategoryModel>();

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
            SQLComm.Parameters.AddWithValue("@CurrentMonth", month);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                while (SQLRec.Read())
                {
                    PieChartModel.Add(new PieChartCategoryModel
                    {
                        Category = SQLRec.GetString(SQLRec.GetOrdinal("Category")),
                        PercentAmount = SQLRec.GetDecimal(SQLRec.GetOrdinal("PercentAmount")),
                        DollarAmount = SQLRec.GetDecimal(SQLRec.GetOrdinal("DollarAmount")),
                        AmountTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("AmountTotal"))
                    });
                }
            }
            catch (Exception e)
            {
                PieChartModel.Add(new PieChartCategoryModel
                {
                    ReturnMessage = e.Message,
                    ReturnStatus = "Failed",
                    newId = -1
                });


            }
            finally
            {
                SQLRec.Close();
                SQLConn.Close();
            }
            return PieChartModel;
        }


        public List<PieChartCategoryModel> GetYearlyCategoriesSummaryChart(int UserID, int year)
        {

            List<PieChartCategoryModel> PieChartModel = new List<PieChartCategoryModel>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetYearlyCategoriesSummaryChart]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", UserID);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                while (SQLRec.Read())
                {
                    PieChartModel.Add(new PieChartCategoryModel
                    {
                        Category = SQLRec.GetString(SQLRec.GetOrdinal("Category")),
                        PercentAmount = SQLRec.GetDecimal(SQLRec.GetOrdinal("PercentAmount")),
                        DollarAmount = SQLRec.GetDecimal(SQLRec.GetOrdinal("DollarAmount")),
                        AmountTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("AmountTotal"))
                    });
                }
            }
            catch (Exception e)
            {
                PieChartModel.Add(new PieChartCategoryModel
                {
                    ReturnMessage = e.Message,
                    ReturnStatus = "Failed",
                    newId = -1
                });


            }
            finally
            {
                SQLRec.Close();
                SQLConn.Close();
            }
            return PieChartModel;
        }

        /*********************Monthly Summary*************************/
        public SummaryChartModel GetMonthlySummaryChart(int UserID, int month, int year)
        {

            SummaryChartModel SummaryChartModel = new SummaryChartModel();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetMonthlySummaryChart]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", UserID);
            SQLComm.Parameters.AddWithValue("@CurrentMonth", month);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                if (SQLRec.Read())
                {
                   
                    SummaryChartModel.VariableTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableTotal"));
                    SummaryChartModel.VariablePercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariablePercentage"));
                    SummaryChartModel.FixedTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedTotal"));
                    SummaryChartModel.FixedPercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedPercentage"));
                    SummaryChartModel.FixedExpenseSplitTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedExpenseSplitTotal"));
                    SummaryChartModel.FixedSplitTotalPercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedSplitTotalPercentage"));
                    SummaryChartModel.VariableSplitSumTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableSplitSumTotal"));
                    SummaryChartModel.VariableSplitSumTotalPercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableSplitSumTotalPercentage"));
                    SummaryChartModel.Total = SQLRec.GetDecimal(SQLRec.GetOrdinal("Total"));

                }
            }
            catch (Exception e)
            {

                SummaryChartModel.ReturnMessage = e.Message;
                SummaryChartModel.ReturnStatus = "Failed";
                SummaryChartModel.newId = -1;

            }
            finally
            {
                SQLRec.Close();
                SQLConn.Close();
            }

            return SummaryChartModel;
        }

        public SummaryChartModel GetYearlySummaryChart(int UserID, int year)
        {

            SummaryChartModel SummaryChartModel = new SummaryChartModel();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetYearlySummaryChart]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", UserID);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                if (SQLRec.Read())
                {

                    SummaryChartModel.VariableTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableTotal"));
                    SummaryChartModel.VariablePercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariablePercentage"));
                    SummaryChartModel.FixedTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedTotal"));
                    SummaryChartModel.FixedPercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedPercentage"));
                    SummaryChartModel.FixedExpenseSplitTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedExpenseSplitTotal"));
                    SummaryChartModel.FixedSplitTotalPercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedSplitTotalPercentage"));
                    SummaryChartModel.VariableSplitSumTotal = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableSplitSumTotal"));
                    SummaryChartModel.VariableSplitSumTotalPercentage = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableSplitSumTotalPercentage"));
                    SummaryChartModel.Total = SQLRec.GetDecimal(SQLRec.GetOrdinal("Total"));

                }
            }
            catch (Exception e)
            {

                SummaryChartModel.ReturnMessage = e.Message;
                SummaryChartModel.ReturnStatus = "Failed";
                SummaryChartModel.newId = -1;

            }
            finally
            {
                SQLRec.Close();
                SQLConn.Close();
            }

            return SummaryChartModel;
        }

        /*********************Monthly Summary Chart*************************/
        public List<MonthlySummaryBarChartModel> GetMonthlyAmountsForTheYearChart(int UserID)
        {

            List<MonthlySummaryBarChartModel> MonthlySummaryBarChartModel = new List<MonthlySummaryBarChartModel>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetMonthlyAmountsForTheYearChart]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", UserID);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                while (SQLRec.Read())
                {
                    MonthlySummaryBarChartModel.Add(new MonthlySummaryBarChartModel
                    {
                        VariableExpense = SQLRec.GetDecimal(SQLRec.GetOrdinal("VariableExpense")),
                        FixedExpense = SQLRec.GetDecimal(SQLRec.GetOrdinal("FixedExpense")),
                        SpltExpense = SQLRec.GetDecimal(SQLRec.GetOrdinal("SpltExpense")),
                        Total = SQLRec.GetDecimal(SQLRec.GetOrdinal("Total")),
                    });

                }
            }
            catch (Exception e)
            {
                MonthlySummaryBarChartModel.Add(new MonthlySummaryBarChartModel
                {
                    ReturnMessage = e.Message,
                    ReturnStatus = "Failed",
                    newId = -1
                });
            }
            finally
            {
                SQLRec.Close();
                SQLConn.Close();
            }

            return MonthlySummaryBarChartModel;
        }


    }
}


