using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMSServiceAgent.Models;
namespace SMSServiceAgent.Helpers
{
    public class CustomHelper
    {
        public static string GetAuthenticatedUserId()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string id = ApplicationDbContext.GetInstance()
                    .Users
                    .Single(u => u.Email == HttpContext.Current.User.Identity.Name).Id;
                return id;
            }
            else
            {
                return null;
            }
        }
    }
}