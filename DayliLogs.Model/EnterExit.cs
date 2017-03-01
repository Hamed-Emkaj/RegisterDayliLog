using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayliLogs.Model
  {
  public class EnterExit
    {
    [Display(Name = "شناسه ورود و خروج")]
    public int Id { get; set; }
    [Display(Name = "ساعت ورود"), Column(TypeName = "DateTime2")]
    public  DateTime  Vorood{ get; set; }
    [Display(Name = "ساعت خروج"), Column(TypeName = "DateTime2")]
    public DateTime Khorooj { get; set; }
    [Display(Name = "نام کاربر ")]
    public virtual User ActiveUser { get; set; }
    [Display(Name = "مرخصی روزانه")]
    public Boolean Mroozaneh { get; set; }
    [Display(Name = "تاریخ روز حضور")]
    public DateTime TarikhRooz { get; set; }
    }
  }