using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Geek_Inside.Models.db;
using Geek_Inside.Models;
using Dapper;


namespace Geek_Inside.Controllers
{
    public class LoginController : Controller
    {

        // GET: Logout
        public ActionResult Logout()
        {

            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Access", "Login");

        }

        // GET: Access
        public ActionResult Access()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        // POST: Access
        [HttpPost]
        public ActionResult Access(LoginModel model)
        {
            using (var cn = Connection.Connect())
            {
                string sql = "SELECT * FROM users WHERE email ='" + model.Email + "' AND passwd = '" + model.Passwd + "'";
                var result = cn.Query<LoginModel>(sql).ToList();
                if (result.Count > 0 && result.Count < 2)
                {
                    Session["User"] = model.Email;
                    FormsAuthentication.SetAuthCookie(Session["User"].ToString(), true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>" +
                        "alert('Usuario o contraseña invalido.');" +
                        " window.location.href = '../Login/Access';" +
                        "</script>");
                }
            }
        }
    }
}