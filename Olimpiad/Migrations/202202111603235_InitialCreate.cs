namespace Olimpiad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KindSports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KindSportName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OlimpInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OlimpName = c.String(),
                        CityCountryId = c.Int(nullable: false),
                        OlympType = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartiLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartiId = c.Int(nullable: false),
                        KindSportId = c.String(),
                        OlimpInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OlimpInfoes", t => t.OlimpInfo_Id)
                .Index(t => t.OlimpInfo_Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParticipantName = c.String(),
                        CountryId = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        Photo = c.Binary(),
                        KindSportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartiListId = c.Int(nullable: false),
                        OlimpInfoId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartiLists", "OlimpInfo_Id", "dbo.OlimpInfoes");
            DropIndex("dbo.PartiLists", new[] { "OlimpInfo_Id" });
            DropTable("dbo.Results");
            DropTable("dbo.Participants");
            DropTable("dbo.PartiLists");
            DropTable("dbo.OlimpInfoes");
            DropTable("dbo.KindSports");
            DropTable("dbo.Countries");
            DropTable("dbo.CityCountries");
            DropTable("dbo.Cities");
        }
    }
}
