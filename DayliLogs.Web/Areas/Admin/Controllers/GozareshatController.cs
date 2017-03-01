using DayliLogs.Model;
using DayliLogs.Web.Areas.Admin.ViewModels;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Text;
using ExcelLibrary.SpreadSheet;
using Excel = Microsoft.Office.Interop.Excel;

namespace DayliLogs.Web.Areas.Admin.Controllers
{

    public class GozareshatController : Controller
    {
        DayliLogsDb ctx = new DayliLogsDb();
        static void DisplayInExcel( GozareshatLogVM  s)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned 
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a praticular template. 
            // Because no argument is sent in this example, Add creates a new workbook. 
            excelApp.Workbooks.Add();

            // This example uses a single workSheet. The explicit type casting is
            // removed in a later procedure.
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "نام کاربر";
            workSheet.Cells[1, "B"] = "نام پروژه ها";
            workSheet.Cells[1, "C"] = "عنوان خروجی ها";
            workSheet.Cells[1, "D"] = "تعداد خروجی ها";
            workSheet.Cells[1, "E"] = "مجموع ساعات کاری";
            workSheet.Cells[1, "F"] = "مجموع ساعات غیر  کاری";
            workSheet.Cells[1, "G"] = "مجموع ساعات مرخصی";
            workSheet.Cells[1, "H"] = "مجموع ساعات ماموریت";
            workSheet.Cells[1, "I"] = "مجموع کل مرخصی روزانه";
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            workSheet.Columns[3].AutoFit();
            workSheet.Columns[4].AutoFit();
            workSheet.Columns[5].AutoFit();
            workSheet.Columns[6].AutoFit();
            workSheet.Columns[7].AutoFit();
            workSheet.Columns[8].AutoFit();
            workSheet.Columns[9].AutoFit();
            workSheet.Cells[2, "A"] = s.Username;


            Range range = workSheet.UsedRange;
            int row;
            for (row = 2; row <= range.Rows.Count; row++)
            {
              var  xlDropDowns = ((DropDowns)(workSheet.DropDowns(Type.Missing)));
             var   xlDropDown = xlDropDowns.Add((double)range[row, 2].Left, (double)range[row, 1].Top,
                    (double)range[row, 1].Width, (double)range[row, 2].Height, true);
                var counter = 1;
                foreach (var item in s.ProjectNames)
                {
                    xlDropDown.AddItem(item,counter + 1);
                }
            }
            Range range01 = workSheet.UsedRange;
            int row01;
            for (row01 = 2; row01 <= range01.Rows.Count; row01++)
            {
                var xlDropDowns = ((DropDowns)(workSheet.DropDowns(Type.Missing)));
                var xlDropDown = xlDropDowns.Add((double)range01[row01, 3].Left, (double)range01[row01, 1].Top,
                       (double)range01[row01, 1].Width, (double)range01[row01, 2].Height, true);
                var counter = 1;
                foreach (var item in s.Onvankhorooji)
                {
                    xlDropDown.AddItem(item, counter + 1);
                }
            }
            workSheet.Cells[2, "D"] = s.MajKhorooji;
            workSheet.Cells[2, "E"] = s.MajKa;
            workSheet.Cells[2, "F"] = s.MajGhk;
            workSheet.Cells[2, "G"] = s.MajMo;
            workSheet.Cells[2, "H"] = s.MajMa;

            Range range02 = workSheet.UsedRange;
            int row02;
            for (row02 = 2; row02 <= range02.Rows.Count; row02++)
            {
                var xlDropDowns = ((DropDowns)(workSheet.DropDowns(Type.Missing)));
                var xlDropDown = xlDropDowns.Add((double)range02[row02, 9].Left, (double)range01[row02, 1].Top,
                       (double)range02[row02, 1].Width, (double)range02[row02, 2].Height, true);
                var counter = 1;
                foreach (var item in s.Morkhasis)
                {
                    xlDropDown.AddItem(item, counter + 1);
                }
            }

        }

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

        string ConvertTopersian(DateTime d1)
        {
            var calendar = new PersianCalendar();
            var year = calendar.GetYear(d1);
            var mounth = calendar.GetMonth(d1);
            var day = calendar.GetDayOfMonth(d1);

            if (mounth < 10 && day < 10)
            {
                var result01 = year + "/" + "0" + mounth + "/" + "0" + day;
                return (result01);
            }

            if (mounth < 10 && day > 10)
            {
                var result02 = year + "/" + "0" + mounth + "/" + day;
                return (result02);
            }
            if (mounth > 10 && day < 10)
            {
                var result03 = year + "/" + mounth + "/" + "0" + day;
                return (result03);
            }
            var result = year + "/" + mounth + "/" + day;
            return (result);
        }
        public int tafrighTime(DateTime date01, DateTime date2)
        {
            TimeSpan ts = date01 - date2;
            int h = ts.Hours;
            int m = ts.Minutes;
            int maj = (h * 60) + m;

            return (maj);
        }

        // GET: Admin/Gozareshat
        public ActionResult GozareshPro()
        {
            int counter = 1;
            var Auser = ctx.Users.Find(Session["UserId"]);
            ViewBag.AUser = Auser;
            var listp = ctx.DProjects.ToList();
            List<ProjectForViwVM> listpr = new List<ProjectForViwVM>();

            foreach (var item in listp)
            {
                var date01 = ConvertTopersian(item.DateOfStart);
                var date02 = ConvertTopersian(item.DateOfEnd);
                var pname = item.ProjectName;
                var name01 = item.Userselect01.Name + " " + item.Userselect01.Family;
                var name02 = item.Userselect02.Name + " " + item.Userselect02.Family;
                var name03 = item.Userselect03.Name + " " + item.Userselect03.Family;
                var name04 = item.Userselect04.Name + " " + item.Userselect04.Family;
                var name05 = item.Userselect05.Name + " " + item.Userselect05.Family;
                var name06 = item.Userselect06.Name + " " + item.Userselect06.Family;
                var name07 = item.Userselect07.Name + " " + item.Userselect07.Family;
                var name08 = item.Userselect08.Name + " " + item.Userselect08.Family;
                var name09 = item.Userselect09.Name + " " + item.Userselect09.Family;
                var name10 = item.Userselect10.Name + " " + item.Userselect10.Family;

                ProjectForViwVM vm = new ProjectForViwVM()
                {
                    End = date02,
                    Start = date01,
                    NameProject = pname,
                    User01 = name01,
                    User02 = name02,
                    User03 = name03,
                    User04 = name04,
                    User05 = name05,
                    User06 = name06,
                    User07 = name07,
                    User08 = name08,
                    User09 = name09,
                    User10 = name10,
                    Counter = counter
                };
                listpr.Add(vm);
                counter++;
            }

            return View(listpr);
        }
        [HttpPost]
        public ActionResult Gopost(string Requester, string Date01, string Date02)
        {
            var hozoorghiyab = ctx.EnterExits.ToList();
            var s = ConvertTopersian(DateTime.Now);
            var Auser = ctx.Users.Find(Session["UserId"]);
            ViewBag.AUser = Auser;
            var Loglist = ctx.LogRozanes.ToList();
            PersianDateTime persianDateTime01 = PersianDateTime.Parse(Date01);
            DateTime gregorianDatetime01 = persianDateTime01.Date;
            PersianDateTime persianDateTime02 = PersianDateTime.Parse(Date02);
            DateTime gregorianDatetime02 = persianDateTime02.Date;

            string usern = "";
            List<string> projects = new List<string>();
            List<string> onvankhorooji = new List<string>();
            int majkhorooji = 0;
            int majkari = 0;
            int majghkari = 0;
            int majsaati = 0;
            int majmamooriyat = 0;
            List<string> roozaneh = new List<string>();
            int kolehozoor = 0;

            foreach (var item in Loglist)
            {

                if (item.Az >= gregorianDatetime01 && item.Ta <= gregorianDatetime02 && Requester == item.Reguser.Family)
                {
                    usern = item.Reguser.Name + " " + item.Reguser.Family;
                    projects.Add(item.OnvanProject.ProjectName);
                    if (item.Tedad != 0)
                    {
                        onvankhorooji.Add(item.onvankhorooji + "  " + item.Tedad + " عدد در تاریخ  " + ConvertTopersian(item.TaskDate));
                    }
                    majkhorooji += item.Tedad;
                    if (item.Ka)
                    {
                        majkari += item.Maj;
                    }
                    if (item.GHka)
                    {
                        majghkari += item.Maj;
                    }
                    if (item.Ma)
                    {
                        majmamooriyat += item.Maj;
                    }
                    if (item.Mo)
                    {
                        majsaati += item.Maj;
                    }

                }

            }

            var kari = Hourtotime(majkari);
            var gheyrekari = Hourtotime(majghkari);
            var morkhasisaati = Hourtotime(majsaati);
            var mamooriyat = Hourtotime(majmamooriyat);
            foreach (var item02 in hozoorghiyab)
            {
                if (item02.ActiveUser.Family == Requester && item02.Mroozaneh)
                {
                    roozaneh.Add(ConvertTopersian(item02.TarikhRooz));
                }
                kolehozoor += tafrighTime(item02.Khorooj, item02.Vorood);
            }
            var finallolehozoor = Hourtotime(kolehozoor);
            GozareshatLogVM FinalExport = new GozareshatLogVM()
            {
                Username = usern,
                ProjectNames = projects,
                Onvankhorooji = onvankhorooji,
                MajKa = Hourtotime(majkari),
                MajGhk = Hourtotime(majghkari),
                MajMa = Hourtotime(majmamooriyat),
                MajMo = Hourtotime(majsaati),
                MajKhorooji = majkhorooji.ToString(),
                Majkolhozoor = finallolehozoor,
                az = Date01,
                ta = Date02,
                Morkhasis = roozaneh

            };

            DisplayInExcel(FinalExport);


            return View(FinalExport);

        }
        public ActionResult GozareshLogDuration()
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
                var userlist = ctx.Users.ToList();
                return View(userlist);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

    }
}