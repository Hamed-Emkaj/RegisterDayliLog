using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayliLogs.Model
{
    public class DProject
    {
        [Display(Name = "شناسه پروژه")]
        public int Id { get; set; }
        [Display(Name = "عنوان پروژه"), Required]
        public string ProjectName { get; set; }
        [Display(Name = " نام کاربر انتخاب شده اول"),Required]
        public virtual User Userselect01 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده دوم")]
        public virtual User Userselect02 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده سوم")]
        public virtual User Userselect03 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده چهارم")]
        public virtual User Userselect04 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده پنجم")]
        public virtual User Userselect05 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده ششم")]
        public virtual User Userselect06 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده هفتم")]
        public virtual User Userselect07 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده هشتم")]
        public virtual User Userselect08 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده نهم")]
        public virtual User Userselect09 { get; set; }
        [Display(Name = " نام کاربر انتخاب شده دهم")]
        public virtual User Userselect10 { get; set; }

        [Display(Name = "تاریخ شروع "), Required, Column(TypeName = "DateTime2")]
        public DateTime DateOfStart { get; set; }
        [Display(Name = "تاریخ پایان "), Column(TypeName = "DateTime2")]
        public DateTime DateOfEnd { get; set; }
        [Display(Name = "وضعیت")]
        public Boolean Engheza { get; set; }

    }
}