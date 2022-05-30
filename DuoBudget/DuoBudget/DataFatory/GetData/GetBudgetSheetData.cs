using DuoBudget.Models;
using DuoBudget.Models.BudgetModels;
using DuoBudget.Models.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuoBudget.DataFatory.GetData
{
    public class GetBudgetSheetData
    {
        public List<VariableExpenseModel> getAllVariableExpense(int month, int year, int userId)
        {

            List<VariableExpenseModel> expenseList = new List<VariableExpenseModel>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();


            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetAllExpenseByUserIdFromCurrentMonthAndYear]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", userId);
            SQLComm.Parameters.AddWithValue("@CurrentMonth", month);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            if (SQLRec.HasRows)
            {
                try
                {
                    while (SQLRec.Read())
                    {
                        expenseList.Add(new VariableExpenseModel
                        {
                            ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                            UserId = SQLRec.GetInt32(SQLRec.GetOrdinal("UserId")),
                            Title = SQLRec.GetString(SQLRec.GetOrdinal("Title")),
                            Date = SQLRec.GetDateTime(SQLRec.GetOrdinal("ExpenseDate")),
                            Description = SQLRec.GetString(SQLRec.GetOrdinal("Description")),
                            Category = SQLRec.GetString(SQLRec.GetOrdinal("Category")),
                            Amount = SQLRec.GetDecimal(SQLRec.GetOrdinal("Amount")),
                            Split = SQLRec.GetBoolean(SQLRec.GetOrdinal("splitExpense")),

                        });
                    }

                }
                catch(Exception e)
                {
                    expenseList.Add(new VariableExpenseModel
                    {
                        ReturnMessage = "Something went wrong: " + e.Message

                    }) ;
                }

            }
            SQLRec.Close();
            SQLConn.Close();
            return expenseList;
        }

        public List<DropDownOptions> getAllCategories()
        {
            List<DropDownOptions> categories = new List<DropDownOptions>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();


            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetAllCategories]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLRec = SQLComm.ExecuteReader();
            try
            {
                if (SQLRec.HasRows)
                {
                    while (SQLRec.Read())
                    {
                        categories.Add(new DropDownOptions
                        {
                            ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                            Option = SQLRec.GetString(SQLRec.GetOrdinal("Category"))
                        });
                    }
                }
            }
            catch(Exception e)
            {
                categories.Add(new DropDownOptions
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
            return categories;

        }
    }
}