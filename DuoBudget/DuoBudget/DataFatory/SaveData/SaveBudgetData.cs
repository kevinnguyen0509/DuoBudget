using DuoBudget.Models;
using DuoBudget.Models.BudgetModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuoBudget.DataFatory
{
    public class SaveBudgetData
    {


        /************************Variable*********************************/
        public ResultMessage SaveVariableExpenseEntry(VariableExpenseModel expenseEntry)
        {

            ResultMessage ReturnValues = new ResultMessage();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[ssp_BudgetSheet_SaveExpenseEntry]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {

                SQLComm.Parameters.AddWithValue("@UserId", expenseEntry.UserId);
                SQLComm.Parameters.AddWithValue("@Title", expenseEntry.Title);
                SQLComm.Parameters.AddWithValue("@ExpenseDate", expenseEntry.Date);
                SQLComm.Parameters.AddWithValue("@Description", expenseEntry.Description);
                SQLComm.Parameters.AddWithValue("@Category", expenseEntry.Category);
                SQLComm.Parameters.AddWithValue("@Amount", expenseEntry.Amount);
                SQLComm.Parameters.AddWithValue("@SplitExpense", expenseEntry.Split);

                SQLRec = SQLComm.ExecuteReader();

                while (SQLRec.Read())
                {
                    ReturnValues.ReturnMessage = SQLRec.GetString(SQLRec.GetOrdinal("ReturnMessage"));
                    ReturnValues.ReturnStatus = SQLRec.GetString(SQLRec.GetOrdinal("ReturnStatus"));
                    ReturnValues.newId = SQLRec.GetInt32(SQLRec.GetOrdinal("NewIdRow"));
                }
            }
            catch (Exception e)
            {
                ReturnValues.ReturnMessage = "Oops, something went wrong! \n" + e.Message;
                ReturnValues.ReturnStatus = "Failed";
            }
            finally
            {
                SQLConn.Close();
            }
            return ReturnValues;
        }


        /************************Fixed*********************************/
        public ResultMessage SaveFixedExpenseEntry(FixedExpenseModel FixedExpenseEntry)
        {

            ResultMessage ReturnValues = new ResultMessage();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[ssp_BudgetSheet_SaveFixedExpenseEntry]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {

                SQLComm.Parameters.AddWithValue("@UserId", FixedExpenseEntry.UserId);
                SQLComm.Parameters.AddWithValue("@Title", FixedExpenseEntry.Title);
                SQLComm.Parameters.AddWithValue("@ExpenseDate", FixedExpenseEntry.Date);
                SQLComm.Parameters.AddWithValue("@Description", FixedExpenseEntry.Description);
                SQLComm.Parameters.AddWithValue("@Category", FixedExpenseEntry.Category);
                SQLComm.Parameters.AddWithValue("@Amount", FixedExpenseEntry.Amount);
                SQLComm.Parameters.AddWithValue("@Split", FixedExpenseEntry.Split);

                SQLRec = SQLComm.ExecuteReader();

                while (SQLRec.Read())
                {
                    ReturnValues.ReturnMessage = SQLRec.GetString(SQLRec.GetOrdinal("ReturnMessage"));
                    ReturnValues.ReturnStatus = SQLRec.GetString(SQLRec.GetOrdinal("ReturnStatus"));
                    ReturnValues.newId = SQLRec.GetInt32(SQLRec.GetOrdinal("NewIdRow"));
                }
            }
            catch (Exception e)
            {
                ReturnValues.ReturnMessage = "Oops, something went wrong! \n" + e.Message;
                ReturnValues.ReturnStatus = "Failed";
            }
            finally
            {
                SQLConn.Close();
            }
            return ReturnValues;
        }

        /************************Income*********************************/
        public ResultMessage SaveIncomeEntry(IncomeModel incomeModel)
        {

            ResultMessage ReturnValues = new ResultMessage();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[ssp_BudgetSheet_SaveIncomeEntry]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {

                SQLComm.Parameters.AddWithValue("@UserId", incomeModel.UserId);
                SQLComm.Parameters.AddWithValue("@Title", incomeModel.Title);
                SQLComm.Parameters.AddWithValue("@IncomeDate", incomeModel.Date);
                SQLComm.Parameters.AddWithValue("@Description", incomeModel.Description);
                SQLComm.Parameters.AddWithValue("@Amount", incomeModel.Amount);

                SQLRec = SQLComm.ExecuteReader();

                while (SQLRec.Read())
                {
                    ReturnValues.ReturnMessage = SQLRec.GetString(SQLRec.GetOrdinal("ReturnMessage"));
                    ReturnValues.ReturnStatus = SQLRec.GetString(SQLRec.GetOrdinal("ReturnStatus"));
                    ReturnValues.newId = SQLRec.GetInt32(SQLRec.GetOrdinal("NewIdRow"));
                }
            }
            catch (Exception e)
            {
                ReturnValues.ReturnMessage = "Oops, something went wrong! \n" + e.Message;
                ReturnValues.ReturnStatus = "Failed";
            }
            finally
            {
                SQLConn.Close();
            }
            return ReturnValues;
        }
    }
}