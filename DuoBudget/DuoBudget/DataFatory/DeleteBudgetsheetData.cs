using DuoBudget.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuoBudget.DataFatory
{
    public class DeleteBudgetsheetData
    {
        public ResultMessage DeleteVaraibleExpenseEntry(int id, int UserID)
        {

            ResultMessage ReturnValues = new ResultMessage();
            SqlConnection SQLConn = new SqlConnection();
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();
            SqlCommand SQLComm = new SqlCommand("[dbo].[dbo.ssp_BudgetSheet_DeleteExpenseEntryByIDAndUserID]", SQLConn);
            SqlDataReader SQLRec;
            SQLComm.CommandType = CommandType.StoredProcedure;

            try
            {

                SQLComm.Parameters.AddWithValue("@ID", id);
                SQLComm.Parameters.AddWithValue("@UserId", UserID);

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