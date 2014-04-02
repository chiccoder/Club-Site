using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace TTC.Controllers.Index
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public String CreateUser(TTC.Models.Index.IndexPageModel model)
        {
            if (String.IsNullOrEmpty(model.FirstName) || String.IsNullOrEmpty(model.LastName)
            || String.IsNullOrEmpty(model.Email) || String.IsNullOrEmpty(model.ID) || String.IsNullOrEmpty(model.PhoneNumber))
            {
               
                return "Not all values are filled";
            }
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=127.0.0.1;Database=ttc_database;Uid=root;Pwd=dontfearthereaper";
            Database.Member newMember = new Database.Member(conn);
            newMember.FirstName = model.FirstName;
            newMember.LastName = model.LastName;
            newMember.Email = model.Email;
            newMember.PhoneNumber = model.PhoneNumber;
            newMember.StudentID = model.ID;
            newMember.ShirtSize = model.ShirtSize + "";
            try
            {
                newMember.Save();
                return "SignedUp!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
