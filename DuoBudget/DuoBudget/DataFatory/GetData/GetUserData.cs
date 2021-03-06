using DuoBudget.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuoBudget.DataFatory
{
    public class GetUserData
    {

        public User GetUser(string email)
        {

            User userData = new User();

            SqlConnection SQLConn = new SqlConnection();
            SqlCommand SQLComm = new SqlCommand();
            SqlDataReader SQLRec;

            // Configure the ConnectionString to access the database content
            SQLConn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["tableCon"].ConnectionString;
            SQLConn.Open();


            /*string SQL = "SELECT * FROM dbo.GeneralLiabilityClaims";*/
            string SQL = "[dbo].[dbo.ssp_BudgetSheet_GetUser]";
            SQLComm = new SqlCommand(SQL, SQLConn);
            SQLComm.CommandType = CommandType.StoredProcedure;
            SQLComm.Parameters.AddWithValue("@Email", email);

            SQLRec = SQLComm.ExecuteReader();

            if (SQLRec.HasRows)
            {
                while (SQLRec.Read())
                {
                    userData = new User
                    {
                        ID = SQLRec.GetInt32(SQLRec.GetOrdinal("ID")),
                        Email = SQLRec.GetString(SQLRec.GetOrdinal("Email")),
                        Password = SQLRec.GetString(SQLRec.GetOrdinal("password")),
                        PartnerID = SQLRec.IsDBNull(SQLRec.GetOrdinal("PartnerID")) == true ? null : SQLRec.GetString(SQLRec.GetOrdinal("PartnerID"))
                        
                    };
                }
            }
            else
            {

            }
            SQLRec.Close();
            SQLConn.Close();

            return userData;
        }
    }
}