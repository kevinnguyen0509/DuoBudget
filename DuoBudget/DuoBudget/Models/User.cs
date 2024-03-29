﻿using DuoBudget.DataFatory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoBudget.Models
{
    public class User
    {
        GetUserData GetData = new GetUserData();
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PartnerID { get; set; }

        public User GetUserIfExists(string Email)
        {
            return GetData.GetUser(Email);
        }

        public User GetLoggedInUserCookie()
        {
             HttpCookie CurrentUserCookie = HttpContext.Current.Request.Cookies["DuoBudgetCurrentUserCookie"];
             this.ID = Int32.Parse(CurrentUserCookie.Values["ID"]);
             this.PartnerID = CurrentUserCookie.Values["PartnerID"].ToString();

            return this;
        }
    }
}