namespace Olimpiad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewWay : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PartiLists", "KindSportId", c => c.Int(nullable: false));
            DropColumn("dbo.Participants", "KindSportId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "KindSportId", c => c.Int(nullable: false));
            AlterColumn("dbo.PartiLists", "KindSportId", c => c.String());
        }
    }
}
