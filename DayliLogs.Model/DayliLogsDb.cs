namespace DayliLogs.Model
  {
  using System;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.ComponentModel.DataAnnotations;
  using System.Data.Entity;
  using System.Linq;

  public class DayliLogsDb : DbContext
    {
    public DbSet<User> Users { get; set; }
    public DbSet<EnterExit> EnterExits { get; set; }
    public DbSet<LogRoozane> LogRozanes { get; set; }
    public DbSet<DProject> DProjects { get; set; }
    public DayliLogsDb()
        : base("DayliLogsDb")
      {
      }
    }

 
  }