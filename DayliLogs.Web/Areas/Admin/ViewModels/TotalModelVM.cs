using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;
using DayliLogs . Model;

namespace DayliLogs.Web.Areas.Admin.ViewModels
{
      public class TotalModelVM
            {
            public List<User> UserList { get; set; }
            public List<EnterExit> VoroodKhorooj { get; set; }
            public List<LogRoozane> Logroozaneh { get; set; }
            public List<DProject> RegProject { get; set; }
            public User ActiveUser { get; set; }
            public LogRoozane OneLog { get; set; }
            public List<LogReportVM> LogreportList { get; set; }
        public List<ProjectForViwVM> projectforview { get; set; }

        public string Rdatenow { get; set; }
		public string Rmajkari { get; set; }
		public string Rmajghkari { get; set; }
		public string Rmajma { get; set; }
		public string Rmajmo { get; set; }
		public string  Rpersiandatenow { get; set; }
		public string CounterLog { get; set; }

		}	 
      }