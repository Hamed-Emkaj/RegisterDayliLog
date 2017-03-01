using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayliLogs.Model
	{
	public class LogRoozane
		{
		[Display ( Name = "شناسه فعالیت " ), Required, DatabaseGenerated ( DatabaseGeneratedOption.None )]
		public int Id { get; set; }
		[Display ( Name = "عنوان پروژه " )]
		public virtual DProject OnvanProject { get; set; }
		[Display ( Name = "درخواست کننده " )]
		public string Requester { get; set; }
		[Display ( Name = "از " ), Column ( TypeName = "DateTime2" )]
		public DateTime Az { get; set; }
		[Display ( Name = " تا " ), Column ( TypeName = "DateTime2" )]
		public DateTime Ta { get; set; }
		[Display ( Name = "مجموع به دقیقه  " )]
		public int Maj { get; set; }
		[Display ( Name = "شرح فعالیت " )]
		public string Tozihat { get; set; }
		[Display ( Name = "تعداد خروجی " )]
		public int Tedad { get; set; }
		[Display ( Name = "عنوان خروجی" )]
		public string onvankhorooji { get; set; }
		[Display ( Name = "تاریخ فعالیت " ), Column ( TypeName = "DateTime2" )]
		public DateTime TaskDate { get; set; }
		[Display ( Name = "مرخصی ساعتی" )]
		public Boolean Mo { get; set; }
		[Display ( Name = "ماموریت اداری" )]
		public Boolean Ma { get; set; }
		[Display ( Name = "فعالیت کاری" )]
		public Boolean Ka { get; set; }
		[Display ( Name = "فعالیت غیر کاری" )]
		public Boolean GHka { get; set; }

		[Display ( Name = "تاریخ ثبت فعالیت" )]
		public DateTime Regdate { get; set; }
		[Display ( Name = "ثبت کننده فعالیت" )]
		public virtual User Reguser { get; set; }

		}
	}