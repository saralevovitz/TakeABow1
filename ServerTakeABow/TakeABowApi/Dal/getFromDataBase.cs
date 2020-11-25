using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeABowApi.Common;
using TakeABowApi.Logic;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Security.Authentication.ExtendedProtection;
using WebGrease.Css.Extensions;
using System.Runtime.InteropServices;

namespace TakeABowApi.Dal
{
    public  class getFromDataBase
    {
        private TakaABowContext data = new TakaABowContext();
        static string connectionString = WebConfigurationManager.AppSettings["TakeABowDB"];// ConfigurationManager.ConnectionStrings["TakeABowDB"].ConnectionString;
        private IOrderedEnumerable<KeyValuePair<int, List<Feedbacks>>> feedbacks;

        /*User*/
        public  List<User> GetUsers()
        {
            try
            {
                var c = WebConfigurationManager.AppSettings["TakeABowDB"];
                var users = data.Users.Where(u => u.Is_Deleted == false).ToList();
                return users;
            }
            catch (Exception ex)
            {
                return new List<User>();
                throw;
            }
        }

        //public List<User> GetTopUsers()
        //{
        //    try
        //    {
        //        var c = WebConfigurationManager.AppSettings["TakeABowDB"];
        //       // var users = data.Users.Where().ToList();
        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<User>();
        //        throw;
        //    }
        //}

        /*Feedback*/
        public List<Feedbacks> GetAllfeedbackByUser( int  id)
        {
            var feedbacks = data.Feedbacks.Where(f => f.ToUserId == id).ToList();
            return feedbacks;
        }

        public IOrderedEnumerable<KeyValuePair<int, List<Feedbacks>>> GetTopFeedbacks()
        {
            try
            {
                var c = WebConfigurationManager.AppSettings["TakeABowDB"];
                DateTime twoWeeksAgo = DateTime.Today.Subtract(TimeSpan.FromDays(14));
                //  feedbacks = data.Feedbacks.Where(d => d.CreateDate > twoWeeksAgo).GroupBy(b => b.ToUserId).ToDictionary(p => p.Key, p => p.ToList()).OrderByDescending(p=>p.Value.Count).Take(5).ToList();
               // feedbacks = data.Feedbacks.Where(d => d.CreateDate > twoWeeksAgo);
                return feedbacks;
            
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }



    }
}