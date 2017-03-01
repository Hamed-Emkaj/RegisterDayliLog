using DayliLogs.Model;
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

    public class HomeController : Controller
    {
        DayliLogsDb ctx = new DayliLogsDb();
        //تابع های سودمند 

        #region
        // جدا کردن دقیقه و ساعت از یک تاریخ و بازگرداندن یک استرینگ به فرمت دقیقه:ساعت
        public string Datetotime(DateTime insertDate)
        {
            var hour = insertDate.Hour.ToString();
            var minut = insertDate.Minute.ToString();
            return string.Format("{0} : {1}", minut, hour);
        }
        // تبدیل دقیقه به ساعت
        public string Hourtotime(int inserthour)
        {
            int hours = inserthour / 60;
            //total minutes
            int minutes = inserthour % 60;
            //output is 1:10
            return string.Format("{0} : {1}", minutes, hours);
        }
        #endregion

        //تابع پیغام ثبت صحیح در دیتا بیس

        // انتقال دیتا به دیتا بیس تابع ورود روز جدید
        [HttpPost]
        public ActionResult InsertAddDay(String Date, int time01min, int time01hour, int time02min, int time02hour, string morkhasi01)
        {
            if (ModelState.IsValid)
            {

                PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
                DateTime gregorianDatetime = persianDateTime.Date;
                DateTime vorood = new DateTime(gregorianDatetime.Year, gregorianDatetime.Month, gregorianDatetime.Day, time01hour, time01min, 0);
                DateTime khorooj = new DateTime(gregorianDatetime.Year, gregorianDatetime.Month, gregorianDatetime.Day, time02hour, time02min, 0);
                List<LogRoozane> Loglist = ctx.LogRozanes.ToList();
                List<EnterExit> enterexit = ctx.EnterExits.ToList();
                if (morkhasi01 == "on")
                {
                    var activeuser = ctx.Users.Find(Session["UserId"]);
                    EnterExit newItem01 = new EnterExit()
                    {
                        TarikhRooz = gregorianDatetime,
                        Khorooj = DateTime.Now,
                        Vorood = DateTime.Now,
                        Mroozaneh = true,
                        ActiveUser = activeuser
                    };
                    ctx.EnterExits.Add(newItem01);
                    ctx.SaveChanges();
                }

                if (morkhasi01 == null || morkhasi01 == "off")
                {
                    var activeuser = ctx.Users.Find(Session["UserId"]);

                    EnterExit newItem = new EnterExit()
                    {
                        ActiveUser = activeuser,
                        Khorooj = khorooj,
                        Vorood = vorood,
                        TarikhRooz = gregorianDatetime,
                    };
                    ctx.EnterExits.Add(newItem);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("SuccessAddDayAlert", "Home");
        }

        // نمایش صفحه ورود روز جدید
        public ActionResult AddDay()
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
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // نمایش  صفحه تابع ورود لاگ جدید


        public ActionResult AddLog()
        {
            // شروع پر کردن پراپرتی های گزارش صفحه ورود فعالیت
            if (Session["UserId"] != null)
            {
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                var rpersiandatenow = PersianDateTime.Now.ToString().Substring(0, 10);
                #region 
                List<LogReportVM> sendLogs = new List<LogReportVM>();
                var LisLogs = ctx.LogRozanes.ToList();
                List<LogRoozane> selectLog = new List<LogRoozane>();
                int Counter = 0;
                foreach (var item in LisLogs)
                {
                    if (item.Regdate.Date == DateTime.Now.Date && item.Reguser.Id == Convert.ToInt32(Session["UserId"]))
                    {
                        selectLog.Add(item);
                        Counter += 1;
                    }
                }
                string rrequester;
                string rdatenow;
                string rtkhorooji;
                string rnkhorooji;
                string rsharh;
                string rend;
                string rstart; ;
                List<int> rmajghkari = new List<int>();
                List<int> rmajkari = new List<int>();
                List<int> rmajma = new List<int>();
                List<int> rmajmo = new List<int>();
                string rnameproject;
                string rnofaaliyat;
                string rtedadsabt = Counter.ToString();

                foreach (var item in selectLog)
                {
                    if (item.Ma)
                    {
                        rrequester = item.Requester;
                        rend = Datetotime(item.Ta);
                        rstart = Datetotime(item.Az);
                        rnofaaliyat = "ماموریت اداری";
                        rtkhorooji = item.Tedad.ToString();
                        rnkhorooji = item.onvankhorooji;
                        rsharh = item.Tozihat;
                        rdatenow = PersianDateTime.Now.ToString().Substring(0, 10);
                        LogReportVM sendlog = new LogReportVM()
                        {
                            Rrequester = "---",
                            Rtkhoroji = rtkhorooji,
                            Rnkhorooji = rnkhorooji,
                            Rsharh = rsharh,
                            Rend = rend,
                            Rstart = rstart,
                            Rnameproject = "---",
                            Rnofaaliyat = rnofaaliyat
                        };
                        sendLogs.Add(sendlog);
                        rmajma.Add(item.Maj);
                    }
                    if (item.Mo)
                    {
                        rend = Datetotime(item.Ta);
                        rstart = Datetotime(item.Az);
                        rnofaaliyat = "مرخصی ساعتی";
                        rtkhorooji = item.Tedad.ToString();
                        rnkhorooji = item.onvankhorooji;
                        rsharh = item.Tozihat;
                        rdatenow = PersianDateTime.Now.ToString().Substring(0, 10);
                        LogReportVM sendlog = new LogReportVM()
                        {
                            Rrequester = "---",
                            Rtkhoroji = rtkhorooji,
                            Rnkhorooji = rnkhorooji,
                            Rsharh = rsharh,
                            Rend = rend,
                            Rstart = rstart,
                            Rnameproject = "---",
                            Rnofaaliyat = rnofaaliyat
                        };
                        sendLogs.Add(sendlog);
                        rmajmo.Add(item.Maj);
                    }
                    if (item.Ka)
                    {
                        rrequester = item.Requester;
                        rend = Datetotime(item.Ta);
                        rstart = Datetotime(item.Az);
                        rnameproject = item.OnvanProject.ProjectName;
                        rnofaaliyat = "فعالیت کاری";
                        rtkhorooji = item.Tedad.ToString();
                        rnkhorooji = item.onvankhorooji;
                        rsharh = item.Tozihat;
                        rdatenow = PersianDateTime.Now.ToString().Substring(0, 10);
                        LogReportVM sendlog = new LogReportVM()
                        {
                            Rrequester = rrequester,
                            Rtkhoroji = rtkhorooji,
                            Rnkhorooji = rnkhorooji,
                            Rsharh = rsharh,
                            Rend = rend,
                            Rstart = rstart,
                            Rnameproject = rnameproject,
                            Rnofaaliyat = rnofaaliyat
                        };
                        sendLogs.Add(sendlog);
                        rmajkari.Add(item.Maj);
                    }
                    if (item.GHka)
                    {
                        rend = Datetotime(item.Ta);
                        rstart = Datetotime(item.Az);
                        rnofaaliyat = "فعالیت غیر کاری";
                        rtkhorooji = item.Tedad.ToString();
                        rnkhorooji = item.onvankhorooji;
                        rsharh = item.Tozihat;
                        rdatenow = PersianDateTime.Now.ToString().Substring(0, 10);
                        LogReportVM sendlog = new LogReportVM()
                        {
                            Rrequester = "---",
                            Rtkhoroji = rtkhorooji,
                            Rnkhorooji = rnkhorooji,
                            Rsharh = rsharh,
                            Rend = rend,
                            Rstart = rstart,
                            Rnameproject = "---",
                            Rnofaaliyat = rnofaaliyat

                        };
                        sendLogs.Add(sendlog);
                        rmajghkari.Add(item.Maj);
                    }
                }
                #endregion
                //  کار کند where در این بخش ساخت متغیر تاریخ از datepicker  حتما باید در متغیر ریخته شود تا در متد userId
                #region
                var userId = Convert.ToInt32(Session["UserId"]);
                var Prolist = ctx.DProjects.Where(x => x.Userselect01.Id == userId || x.Userselect02.Id == userId || x.Userselect03.Id == userId || x.Userselect04.Id == userId || x.Userselect05.Id == userId || x.Userselect06.Id == userId || x.Userselect07.Id == userId || x.Userselect08.Id == userId || x.Userselect09.Id == userId || x.Userselect10.Id == userId).ToList();
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
                var Userlist = ctx.Users.ToList();
                Userlist.RemoveAt(0);
                #endregion
                var mk = 0;
                var mgh = 0;
                var mma = 0;
                var mmo = 0;
                foreach (var item in rmajghkari)
                {
                    mgh += item;
                }
                foreach (var item in rmajkari)
                {
                    mk += item;
                }
                foreach (var item in rmajma)
                {
                    mma += item;
                }
                foreach (var item in rmajmo)
                {
                    mmo += item;
                }
                TotalModelVM vm = new TotalModelVM
                {
                    LogreportList = sendLogs,
                    RegProject = Prolist,
                    UserList = Userlist,
                    Rmajghkari = Hourtotime(mgh),
                    Rmajkari = Hourtotime(mk),
                    Rmajma = Hourtotime(mma),
                    Rmajmo = Hourtotime(mmo),
                    Rpersiandatenow = rpersiandatenow,
                    CounterLog = Counter.ToString()
                };
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Insertlog(string Date, string Requester, string Projectname, int Houraz, int Minutaz, int Hourta, int Minutta, string Tozihat01, string Onvan, int Tedad, string chkmorkhasi01, string chkmamooriyat01, string chkghkari01, string chkkari01)
        {
            if (ModelState.IsValid)
            {
                //تبدیل ورودی ها به فیلد تاریخ زمان
                #region
                var Auser = ctx.Users.Find(Session["UserId"]);
                ViewBag.AUser = Auser;
                PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
                DateTime gregorianDatetime = persianDateTime.Date;

                DateTime taz = new DateTime(gregorianDatetime.Year, gregorianDatetime.Month, gregorianDatetime.Day, Houraz, Minutaz, 0);
                DateTime tta = new DateTime(gregorianDatetime.Year, gregorianDatetime.Month, gregorianDatetime.Day, Hourta, Minutta, 0);

                DateTime majmoomo = new DateTime();
                List<LogRoozane> Loglist = ctx.LogRozanes.ToList();
                var sampleproject = ctx.DProjects.Find(int.Parse(Projectname));
                var lastlogid = Loglist.Select(r => r.Id).ToList().Max() + 1;
                #endregion
                // مرخصی
                #region
                if (chkmorkhasi01 == "on")
                {
                    TimeSpan ts = tta - taz;
                    int h = ts.Hours;
                    int m = ts.Minutes;
                    int maj = (h * 60) + m;
                    LogRoozane add01 = new LogRoozane()
                    {
                        Id = lastlogid,
                        Az = taz,
                        Ta = tta,
                        TaskDate = gregorianDatetime,
                        Tozihat = Tozihat01,
                        Mo = true,
                        Ma = false,
                        Ka = false,
                        GHka = false,
                        Maj = maj,
                        onvankhorooji = Onvan,
                        Regdate = DateTime.Now,
                        Requester = "فیلد خالی",
                        Tedad = 0,
                        OnvanProject = sampleproject,
                        Reguser = Auser
                    };
                    ctx.LogRozanes.Add(add01);
                    ctx.SaveChanges();

                }
                #endregion
                // ماموریت
                #region
                if (chkmamooriyat01 == "on")
                {
                    TimeSpan ts = tta - taz;
                    int h = ts.Hours;
                    int m = ts.Minutes;
                    int maj = (h * 60) + m;
                    LogRoozane add01 = new LogRoozane()
                    {
                        Id = lastlogid,
                        TaskDate = gregorianDatetime,
                        Tozihat = Tozihat01,
                        Az = taz,
                        Ta = tta,
                        Maj = maj,
                        onvankhorooji = Onvan,
                        Regdate = DateTime.Now,
                        Requester = "فیلد خالی",
                        Mo = false,
                        Ma = true,
                        Ka = false,
                        GHka = false,
                        Tedad = 0,
                        OnvanProject = sampleproject,
                        Reguser = Auser
                    };
                    ctx.LogRozanes.Add(add01);
                    ctx.SaveChanges();

                }
                #endregion
                // غیر کاری
                #region
                if (chkghkari01 == "on")
                {
                    TimeSpan ts = tta - taz;
                    int h = ts.Hours;
                    int m = ts.Minutes;
                    int maj = (h * 60) + m;
                    LogRoozane add01 = new LogRoozane()
                    {
                        Id = lastlogid,
                        TaskDate = gregorianDatetime,
                        Tozihat = Tozihat01,
                        Az = taz,
                        Ta = tta,
                        Maj = maj,
                        onvankhorooji = Onvan,
                        Regdate = DateTime.Now,
                        Requester = "فیلد خالی",
                        Mo = false,
                        Ma = false,
                        Ka = false,
                        GHka = true,
                        Tedad = 0,
                        OnvanProject = sampleproject,
                        Reguser = Auser
                    };
                    ctx.LogRozanes.Add(add01);
                    ctx.SaveChanges();

                }
                #endregion
                //  کاری
                #region
                if (chkkari01 == "on")
                {
                    TimeSpan ts = tta - taz;
                    int h = ts.Hours;
                    int m = ts.Minutes;
                    int maj = (h * 60) + m;
                    LogRoozane add01 = new LogRoozane()
                    {
                        Id = lastlogid,
                        TaskDate = gregorianDatetime,
                        Tozihat = Tozihat01,
                        Az = taz,
                        Ta = tta,
                        Maj = maj,
                        onvankhorooji = Onvan,
                        Regdate = DateTime.Now,
                        Requester = Requester,
                        Mo = false,
                        Ma = false,
                        Ka = true,
                        GHka = false,
                        Tedad = Tedad,
                        OnvanProject = sampleproject,
                        Reguser = Auser
                    };
                    ctx.LogRozanes.Add(add01);
                    ctx.SaveChanges();

                }
                #endregion
            }

            return RedirectToAction("AddLog", "Home");



        }



        public ActionResult SuccessAddDayAlert()
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
        public ActionResult Enter()
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

            return View();
        }
        public ActionResult Index()
        {

            return View();
        }

    }
}