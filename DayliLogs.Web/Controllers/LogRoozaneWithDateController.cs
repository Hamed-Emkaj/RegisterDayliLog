using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DayliLogs.Model;
using DayliLogs.Web.ViewModels;
using MD.PersianDateTime;
using System.Globalization;


namespace DayliLogs.Web.Controllers
{
    public class LogRoozaneWithDateController : Controller
    {
        private DayliLogsDb ctx = new DayliLogsDb();

        public ActionResult WithDateEditGet()
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
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
                return View();
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
        // GET: LogRoozaneWithDate
        public ActionResult Index(string Date)
        {

            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                var userid = Convert.ToInt32(Session["UserId"]);

                PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
                DateTime gregorianDatetime = persianDateTime.Date;

                var LisLogs = ctx.LogRozanes.ToList();
                List<LogRoozane> selectLog = new List<LogRoozane>();
                int Counter = 0;
                foreach (var item in LisLogs)
                {
                    if (item.Regdate.Date == persianDateTime.Date && item.Reguser.Id == Convert.ToInt32(Session["UserId"]))
                    {
                        selectLog.Add(item);
                    }
                }

                return View(selectLog);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: LogRoozaneWithDate/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LogRoozane logRoozane = ctx.LogRozanes.Find(id);
                
                if (logRoozane == null)
                {
                    return HttpNotFound();
                }

                return View(logRoozane);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: LogRoozaneWithDate/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: LogRoozaneWithDate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Requester,Az,Ta,Maj,Tozihat,Tedad,onvankhorooji,TaskDate,Mo,Ma,Ka,GHka,Regdate")] LogRoozane logRoozane)
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                if (ModelState.IsValid)
                {
                    ctx.LogRozanes.Add(logRoozane);
                    ctx.SaveChanges();
                    return RedirectToAction("WithDateEditGet");
                }



                return RedirectToAction("WithDateEditGet");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: LogRoozaneWithDate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                LogRoozane logRoozane = ctx.LogRozanes.Find(id);
                if (logRoozane == null)
                {
                    return HttpNotFound();
                }
                return View(logRoozane);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: LogRoozaneWithDate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Requester,Az,Ta,Maj,Tozihat,Tedad,onvankhorooji,TaskDate,Mo,Ma,Ka,GHka,Regdate")] LogRoozane logRoozane)
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                if (ModelState.IsValid)
                {
                    ctx.Entry(logRoozane).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return RedirectToAction("WithDateEditGet");
                }

                return View(logRoozane);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: LogRoozaneWithDate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LogRoozane logRoozane = ctx.LogRozanes.Find(id);
                if (logRoozane == null)
                {
                    return HttpNotFound();
                }
                return View(logRoozane);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: LogRoozaneWithDate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                LogRoozane logRoozane = ctx.LogRozanes.Find(id);
                ctx.LogRozanes.Remove(logRoozane);
                ctx.SaveChanges();
                return RedirectToAction("WithDateEditGet");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
