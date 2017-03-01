namespace DayliLogs.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulabledate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DProjects", "DateOfEnd", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LogRoozanes", "Az", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LogRoozanes", "Ta", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogRoozanes", "Ta", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LogRoozanes", "Az", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.DProjects", "DateOfEnd", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
