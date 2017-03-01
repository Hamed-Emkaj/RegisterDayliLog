namespace DayliLogs.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firsttime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        DateOfStart = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateOfEnd = c.DateTime(precision: 7, storeType: "datetime2"),
                        Engheza = c.Boolean(nullable: false),
                        Userselect01_Id = c.Int(nullable: false),
                        Userselect02_Id = c.Int(),
                        Userselect03_Id = c.Int(),
                        Userselect04_Id = c.Int(),
                        Userselect05_Id = c.Int(),
                        Userselect06_Id = c.Int(),
                        Userselect07_Id = c.Int(),
                        Userselect08_Id = c.Int(),
                        Userselect09_Id = c.Int(),
                        Userselect10_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Userselect01_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Userselect02_Id)
                .ForeignKey("dbo.Users", t => t.Userselect03_Id)
                .ForeignKey("dbo.Users", t => t.Userselect04_Id)
                .ForeignKey("dbo.Users", t => t.Userselect05_Id)
                .ForeignKey("dbo.Users", t => t.Userselect06_Id)
                .ForeignKey("dbo.Users", t => t.Userselect07_Id)
                .ForeignKey("dbo.Users", t => t.Userselect08_Id)
                .ForeignKey("dbo.Users", t => t.Userselect09_Id)
                .ForeignKey("dbo.Users", t => t.Userselect10_Id)
                .Index(t => t.Userselect01_Id)
                .Index(t => t.Userselect02_Id)
                .Index(t => t.Userselect03_Id)
                .Index(t => t.Userselect04_Id)
                .Index(t => t.Userselect05_Id)
                .Index(t => t.Userselect06_Id)
                .Index(t => t.Userselect07_Id)
                .Index(t => t.Userselect08_Id)
                .Index(t => t.Userselect09_Id)
                .Index(t => t.Userselect10_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        BeAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.EnterExits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vorood = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Khorooj = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mroozaneh = c.Boolean(nullable: false),
                        TarikhRooz = c.DateTime(nullable: false),
                        ActiveUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ActiveUser_Id)
                .Index(t => t.ActiveUser_Id);
            
            CreateTable(
                "dbo.LogRoozanes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Requester = c.String(),
                        Az = c.DateTime(precision: 7, storeType: "datetime2"),
                        Ta = c.DateTime(precision: 7, storeType: "datetime2"),
                        Maj = c.Int(nullable: false),
                        Tozihat = c.String(),
                        Tedad = c.Int(nullable: false),
                        onvankhorooji = c.String(),
                        TaskDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mo = c.Boolean(nullable: false),
                        Ma = c.Boolean(nullable: false),
                        Ka = c.Boolean(nullable: false),
                        GHka = c.Boolean(nullable: false),
                        Regdate = c.DateTime(nullable: false),
                        OnvanProject_Id = c.Int(),
                        Reguser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DProjects", t => t.OnvanProject_Id)
                .ForeignKey("dbo.Users", t => t.Reguser_Id)
                .Index(t => t.OnvanProject_Id)
                .Index(t => t.Reguser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogRoozanes", "Reguser_Id", "dbo.Users");
            DropForeignKey("dbo.LogRoozanes", "OnvanProject_Id", "dbo.DProjects");
            DropForeignKey("dbo.EnterExits", "ActiveUser_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect10_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect09_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect08_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect07_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect06_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect05_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect04_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect03_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect02_Id", "dbo.Users");
            DropForeignKey("dbo.DProjects", "Userselect01_Id", "dbo.Users");
            DropIndex("dbo.LogRoozanes", new[] { "Reguser_Id" });
            DropIndex("dbo.LogRoozanes", new[] { "OnvanProject_Id" });
            DropIndex("dbo.EnterExits", new[] { "ActiveUser_Id" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.DProjects", new[] { "Userselect10_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect09_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect08_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect07_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect06_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect05_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect04_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect03_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect02_Id" });
            DropIndex("dbo.DProjects", new[] { "Userselect01_Id" });
            DropTable("dbo.LogRoozanes");
            DropTable("dbo.EnterExits");
            DropTable("dbo.Users");
            DropTable("dbo.DProjects");
        }
    }
}
