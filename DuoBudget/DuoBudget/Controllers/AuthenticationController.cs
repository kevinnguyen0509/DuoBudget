﻿using DuoBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DuoBudget.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public JsonResult LoginVerification(string Email, string password)
        {
            User UserFromDatabase = new User(); //Creates a user model to store User inforamation
            UserFromDatabase = UserFromDatabase.GetUserIfExists(Email);
            bool PasswordIsCorrect = Crypto.VerifyHashedPassword(UserFromDatabase.Password, password);

            if (PasswordIsCorrect)
            {
                //Create cookie, Add the ID and PartnerID that belongs with Logged in user
                //Set it to expire in 90 days.
                HttpCookie CurrentUserCookie = new HttpCookie("DuoBudgetCurrentUserCookie");
                CurrentUserCookie.Values.Add("ID", UserFromDatabase.ID.ToString());
                CurrentUserCookie.Values.Add("PartnerID", UserFromDatabase.PartnerID);
                CurrentUserCookie.Expires = DateTime.Now.AddDays(90);
                Response.Cookies.Add(CurrentUserCookie);

                return Json("Success", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }

        }
    }
}