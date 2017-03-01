using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DayliLogs.Model
  {
  public class User
    {
    [Display(Name ="شناسه کاربر")]
    public int Id { get; set; }
    [StringLength(50), Display(Name ="نام")]
    public string Name { get; set; }
    [StringLength(50), Display(Name ="نام خانوادگی")]
    public string Family { get; set; }
    [StringLength(50), Required, Display(Name ="نام کاربری"), Index(IsUnique =true)]
    public string UserName { get; set; }
    [Required, Display(Name ="کلمه عبور"),StringLength(100,MinimumLength = 3)]
    public string Password { get; set; }
    [Display(Name ="مدیر سایت")]
    public Boolean BeAdmin { get; set; }
    }
  }