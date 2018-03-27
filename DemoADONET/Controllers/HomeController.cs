using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoADONET.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string sql = "select productid,productname from products order by productid";
            string connectionstring = ConfigurationManager.ConnectionStrings["NortWhind"].ConnectionString;
            var connection = new SqlConnection(connectionstring);
            var Command = new SqlCommand(sql,connection);
            connection.Open();
            var Reader = Command.ExecuteReader();
            string html = string.Empty;
            while (Reader.Read())
            {
                html += string.Format("{0} {1}<br/>", Reader["productid"], Reader["productname"]);
            }
            connection.Dispose();
            Command.Dispose();
            return Content(html);
        }
    }
}