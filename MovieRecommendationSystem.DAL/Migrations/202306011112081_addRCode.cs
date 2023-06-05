namespace MovieRecommendationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RoleCode");
        }
    }
}
