namespace MovieRecommendationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieComments", "CommentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieComments", "CommentDate");
        }
    }
}
