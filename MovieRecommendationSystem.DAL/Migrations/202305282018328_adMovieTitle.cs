namespace MovieRecommendationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adMovieTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieComments", "MovieTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieComments", "MovieTitle");
        }
    }
}
