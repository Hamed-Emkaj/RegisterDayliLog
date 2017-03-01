using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayliLogs.Web.Areas.Admin.ViewModels
{
    public class GozareshatLogVM
    {
        public string Username { get; set; }
        public List<string> ProjectNames { get; set; }
        public List<string> Onvankhorooji { get; set; }
        public string MajKhorooji { get; set; }
        public string MajKa { get; set; }
        public string MajGhk { get; set; }
        public string MajMo { get; set; }
        public string MajMa { get; set; }
        public List<string> Morkhasis { get; set; }
        public string Majkolhozoor { get; set; }
        public string az {get;set;}
        public string ta { get; set; }

    }
}