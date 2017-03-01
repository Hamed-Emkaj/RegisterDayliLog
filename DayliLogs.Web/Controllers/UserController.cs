using DayliLogs.Model;
using DayliLogs.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayliLogs.Web.Controllers
  {

  public class UserController : Controller
    {
    DayliLogsDb ctx = new DayliLogsDb();

 
    public ActionResult Sighnout()
      {
    
      Session["UserId"] = null;
      return RedirectToAction("Index", "Home");
      }
    public ActionResult Errorlogin()
      {
      return View();
      }

    [HttpPost]
    
    public ActionResult Signin(User signin)
      {
			
      var user = ctx.Users.Where
        (u => u.UserName == signin.UserName &&
        u.Password == signin.Password).FirstOrDefault();

      if (user != null)
        {
        Session["UserId"] = user.Id;
        var loginuser = ctx.Users.Find(Session["UserId"]);
        var userId = Convert.ToInt32(Session["UserId"]);
        var user01 = ctx.Users.Find(userId);
        if (user01.BeAdmin == true)
          {
                    var Auser = ctx.Users.Find(Session["UserId"]);
                    ViewBag.AUser = Auser;
                    return RedirectToAction("Index", "AdminUser", new { Area = "Admin" });
          }
        else
          {
          return RedirectToAction("Enter", "Home");
          }
        }
      else
        {
        Session["UserId"] = null;
        return RedirectToAction("Errorlogin", "User");
        }
      
     

      }
    // GET: User
    public ActionResult Index()
      {
      return View();
      }
    }
  }