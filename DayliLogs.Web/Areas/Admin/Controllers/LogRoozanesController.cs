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
namespace DayliLogs.Web.Areas.Admin.Controllers
{
    public class LogRoozanesController : Controller
    {
        private DayliLogsDb ctx = new DayliLogsDb();

       
        [HttpPost]
        public ActionResult WithDateEditPost(string Date)
        {
           
            return View();
        }
        // GET: LogRoozanes
        public ActionResult Index()
        {
			if ( Session["UserId"] != null )
				{
				var Auser = ctx.Users.Find(Session["UserId"]);
				ViewBag.AUser = Auser;
				var userid = Convert.ToInt32(Session["UserId"]);
				var now = DateTime.Now.Date;
				var LisLogs = ctx.LogRozanes.ToList();
				List<LogRoozane> selectLog = new List<LogRoozane>() ;
				int Counter = 0 ;
				foreach ( var item in LisLogs )
					{
					if ( item.Regdate.Date == DateTime.Now.Date  && item.Reguser.Id == Convert.ToInt32 ( Session["UserId"] ) )
						{
						selectLog.Add ( item );
						}
					}

				return View(selectLog);
				}
			else
				{
				return RedirectToAction ( "Index","Home" );
				}

			}

        // GET: LogRoozanes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogRoozane logRoozane = ctx.LogRozanes.Find(id);
            if (logRoozane == null)
            {
                return HttpNotFound();
            }
			if ( Session["UserId"] != null )
				{
				var Auser = ctx.Users.Find(Session["UserId"]);
				ViewBag.AUser = Auser;
				return View(logRoozane);
				}
			else
				{
				return RedirectToAction ( "Index","Home" );
				}
        }

        // GET: LogRoozanes/Create
        public ActionResult Create()
        {
			if ( Session["UserId"] != null )
				{
				var Auser = ctx.Users.Find(Session["UserId"]);
				ViewBag.AUser = Auser;
				return View();
				}
			else
				{
				return RedirectToAction ( "Index","Home" );
				}
        }

        // POST: LogRoozanes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Requester,Az,Ta,Maj,Tozihat,Tedad,onvankhorooji,TaskDate,Mo,Ma,Ka,GHka,Regdate")] LogRoozane logRoozane)
        {
            if (ModelState.IsValid)
            {

                ctx.LogRozanes.Add(logRoozane);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            var Auser = ctx.Users.Find(Session["UserId"]);
            ViewBag.AUser = Auser;
            return View(logRoozane);
        }

        // GET: LogRoozanes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogRoozane logRoozane = ctx.LogRozanes.Find(id);
            if (logRoozane == null)
            {
                return HttpNotFound();
            }
			if ( Session["UserId"] != null )
				{
				var Auser = ctx.Users.Find(Session["UserId"]);
				ViewBag.AUser = Auser;
				return View(logRoozane);
				}
			else
				{
				return RedirectToAction ( "Index","Home" );
				}
        }

        // POST: LogRoozanes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Requester,Az,Ta,Maj,Tozihat,Tedad,onvankhorooji,TaskDate,Mo,Ma,Ka,GHka,Regdate")] LogRoozane logRoozane)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(logRoozane).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            var Auser = ctx.Users.Find(Session["UserId"]);
            ViewBag.AUser = Auser;
            return View(logRoozane);
        }

        // GET: LogRoozanes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogRoozane logRoozane = ctx.LogRozanes.Find(id);
            if (logRoozane == null)
            {
                return HttpNotFound();
            }
			if ( Session["UserId"] != null )
				{
				var Auser = ctx.Users.Find(Session["UserId"]);
				ViewBag.AUser = Auser;
				return View(logRoozane);
				}
			else
				{
				return RedirectToAction ( "Index","Home" );
				}
        }

        // POST: LogRoozanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogRoozane logRoozane = ctx.LogRozanes.Find(id);
            ctx.LogRozanes.Remove(logRoozane);
            ctx.SaveChanges();
            return RedirectToAction("Index");
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
