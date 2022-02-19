namespace Olimpiad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalCountryNameType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.Int(nullable: false));
        }
    }
}
