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

        /************************Income*********************************/
        public List<IncomeModel> getAllIncomeListThisMonth(int month, int year, int userId)
        {

            List<IncomeModel> incomeList = new List<IncomeModel>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[ssp_BudgetSheet_GetIncomeByIDAndCurrentMonthAndYear]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", userId);
            SQLComm.Parameters.AddWithValue("@CurrentMonth", month);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                if (SQLRec.HasRows)
                {
                    while (SQLRec.Read())
                    {
                        incomeList.Add(new IncomeModel
                        {
                            ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                            UserId = SQLRec.GetInt32(SQLRec.GetOrdinal("UserId")),
                            Title = SQLRec.GetString(SQLRec.GetOrdinal("Title")),
                            Date = SQLRec.GetDateTime(SQLRec.GetOrdinal("IncomeDate")),
                            Description = SQLRec.GetString(SQLRec.GetOrdinal("Description")),
                            Amount = SQLRec.GetDecimal(SQLRec.GetOrdinal("Amount"))
                        });
                    }
                }
            }
            catch(Exception e)
            {
                incomeList.Add(new IncomeModel
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

            return incomeList;
        }









        /*****************************Varaiable***********************************/
        /// <summary>
        /// Gets All Variable expense for this month and year for the user logged in
        /// </summary>
        /// <param name="month">Takes a Month's Number</param>
        /// <param name="year">Takes in a current year</param>
        /// <param name="userId">Takes in user's ID that is logged in</param>
        /// <returns>Returns a list of variable expenses</returns>
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


        /// <summary>
        /// Gets All Fixed expense for this month and year for the user logged in
        /// </summary>
        /// <param name="month">Takes a Month's Number</param>
        /// <param name="year">Takes in a current year</param>
        /// <param name="userId">Takes in user's ID that is logged in</param>
        /// <returns>Returns a list of Fixed expenses</returns>
        public List<FixedExpenseModel> getAllFixedThisMonth(int month, int year, int userId)
        {
            List<FixedExpenseModel> expenseList = new List<FixedExpenseModel>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetAllFixedExpenseByUserIdFromCurrentMonthAndYear]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", userId);
            SQLComm.Parameters.AddWithValue("@CurrentMonth", month);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();
            
            try
            {
                if (SQLRec.HasRows)
                {
                    while (SQLRec.Read())
                    {
                        expenseList.Add(new FixedExpenseModel
                        {
                            ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                            UserId = SQLRec.GetInt32(SQLRec.GetOrdinal("UserId")),
                            Title = SQLRec.GetString(SQLRec.GetOrdinal("Title")),
                            Date = SQLRec.GetDateTime(SQLRec.GetOrdinal("ExpenseDate")),
                            Description = SQLRec.GetString(SQLRec.GetOrdinal("Description")),
                            Category = SQLRec.GetString(SQLRec.GetOrdinal("Category")),
                            Amount = SQLRec.GetDecimal(SQLRec.GetOrdinal("Amount")),
                            Split = SQLRec.GetBoolean(SQLRec.GetOrdinal("split")),

                        });
                    }
                }
            }
            catch(Exception e)
            {
                expenseList.Add(new FixedExpenseModel
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

            return expenseList;
        }

        /// <summary>
        /// Gets All Split expense for this month and year for the user logged in
        /// </summary>
        /// <param name="month">Takes a Month's Number</param>
        /// <param name="year">Takes in a current year</param>
        /// <param name="userId">Takes in user's ID that is logged in</param>
        /// <returns>Returns a list of Split expenses</returns>
        public List<SplitExpenseModel> getAllSplitExpenseThisMonth(int month, int year, int userId)
        {
            List<SplitExpenseModel> expenseList = new List<SplitExpenseModel>();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();

            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetAllSplitExpenseByUserIdFromCurrentMonthAndYear]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@UserId", userId);
            SQLComm.Parameters.AddWithValue("@CurrentMonth", month);
            SQLComm.Parameters.AddWithValue("@CurrentYear", year);
            SQLRec = SQLComm.ExecuteReader();

            try
            {
                if (SQLRec.HasRows)
                {
                    while (SQLRec.Read())
                    {
                        expenseList.Add(new SplitExpenseModel
                        {
                            ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                            UserId = SQLRec.GetInt32(SQLRec.GetOrdinal("UserId")),
                            Title = SQLRec.GetString(SQLRec.GetOrdinal("Title")),
                            Date = SQLRec.GetDateTime(SQLRec.GetOrdinal("ExpenseDate")),
                            Description = SQLRec.GetString(SQLRec.GetOrdinal("Description")),
                            Category = SQLRec.GetString(SQLRec.GetOrdinal("Category")),
                            Amount = SQLRec.GetDecimal(SQLRec.GetOrdinal("Amount")),
                            Split = SQLRec.GetBoolean(SQLRec.GetOrdinal("split")),
                        });
                    }
                }
            }
            catch(Exception e)
            {
                expenseList.Add(new SplitExpenseModel
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