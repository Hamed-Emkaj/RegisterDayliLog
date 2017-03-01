using DayliLogs.Model;
using DayliLogs.Web.Areas.Admin.ViewModels;
using DayliLogs.Web.ViewModels;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayliLogs.Web.Areas.Admin.Controllers
{
    public class AddProjectController : Controller
    {
        DayliLogsDb ctx = new DayliLogsDb();
        // GET: Admin/AddProject
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                var cs = PersianDateTime.Now;
                ViewBag.cs = cs;
                string c = PersianDateTime.Now.Date.ToString().Substring(0, 10);
                var t = c.ToList();
                string h = "";

                for (int L = 0; L < 10; L++)
                {

                    if (t[L] == '۱')
                    {
                        h += '1';
                    }
                    if (t[L] == '۰')
                    {
                        h += '0';
                    }
                    if (t[L] == '۲')
                    {
                        h += '2';
                    }
                    if (t[L] == '۳')
                    {
                        h += '3';
                    }

                    if (t[L] == '۴')
                    {
                        h += '4';
                    }
                    if (t[L] == '۵')
                    {
                        h += '5';
                    }
                    if (t[L] == '۶')
                    {
                        h += '6';
                    }
                    if (t[L] == '۷')
                    {
                        h += '7';
                    }
                    if (t[L] == '۸')
                    {
                        h += '8';
                    }
                    if (t[L] == '۹')
                    {
                        h += '9';
                    }
                }

                var d = h.Substring(0, 4) + "/" + h.Substring(4, 2) + "/" + h.Substring(6, 2);
                ViewBag.datetoday = d;
                List<User> Userlist = ctx.Users.ToList();
                ViewBag.userlist = Userlist;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public ActionResult InsertProject(String Date01, String Date02, String Name01, String Name02, String Name03, String Name04, String Name05, String Name06, String Name07, String Name08, String Name09, String Name10, string PName)
        {
            if (ModelState.IsValid)
            {

                PersianDateTime persianDateTime01 = PersianDateTime.Parse(Date01);
                DateTime gregorianDatetime01 = persianDateTime01.Date;
                PersianDateTime persianDateTime02 = PersianDateTime.Parse(Date02);
                DateTime gregorianDatetime02 = persianDateTime02.Date;
                var activeuser = ctx.Users.Find(Session["UserId"]);

                List<User> Luser = ctx.Users.ToList();

                User U1 = Luser[0];
                User U2 = Luser[0];
                User U3 = Luser[0];
                User U4 = Luser[0];
                User U5 = Luser[0];
                User U6 = Luser[0];
                User U7 = Luser[0];
                User U8 = Luser[0];
                User U9 = Luser[0];
                User U10= Luser[0];

               
                    if ("on" == Name01)
                    {
                        U1 = Luser[1];
                    }
                    if ("on" == Name02)
                    {
                        U2 = Luser[2];
                    }
                    if ("on" == Name03)
                    {
                        U3 = Luser[3];
                    }
                    if ("on" == Name04)
                    {
                        U4 = Luser[4];
                    }
                    if ("on" == Name05)
                    {
                        U5 = Luser[5];
                    }
                    if ("on" == Name06)
                    {
                        U6 = Luser[6];
                    }
                    if ("on" == Name07)
                    {
                        U7 = Luser[7];
                    }
                    if ("on" == Name08)
                    {
                        U8 = Luser[8];
                    }
                    if ("on" == Name09)
                    {
                        U9 = Luser[9];
                    }
                    if ("on" == Name10)
                    {
                        U10 = Luser[10];
                    }

            
                List<DProject> Lproject =ctx.DProjects.ToList();
                var lastPid = Lproject.Select(r => r.Id).ToList().Max() + 1;
                DProject Vm = new DProject()
                {
                    DateOfStart = gregorianDatetime01,
                    DateOfEnd = gregorianDatetime02,
                    Userselect01 = U1,
                    Userselect02 = U2,
                    Userselect03 = U3,
                    Userselect04 = U4,
                    Userselect05 = U5,
                    Userselect06 = U6,
                    Userselect07 = U7,
                    Userselect08 = U8,
                    Userselect09 = U9,
                    Userselect10 = U10,
                    ProjectName = PName,
                    Engheza = false,
                    Id = lastPid
                };

                ctx.DProjects.Add(Vm);
                ctx.SaveChanges();
                return RedirectToAction("Index", "AdminUser");
            }
            return RedirectToAction("Index", "Home");

        }

    }

}
