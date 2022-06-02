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
                ReturnValues.ReturnMessage = "Oops, something went wrong!" + e.Message;
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