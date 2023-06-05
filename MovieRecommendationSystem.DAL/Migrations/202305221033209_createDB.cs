namespace MovieRecommendationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreIDFromApi = c.Int(nullable: false),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        iso_639_1 = c.String(),
                        EnglishName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.MovieComments",
                c => new
                    {
                        MovieCommentID = c.Int(nullable: false, identity: true),
                        MovieIDFromApi = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Comment = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieCommentID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Mail = c.String(),
                        RoleID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieComments", "UserID", "dbo.Users");
            DropIndex("dbo.MovieComments", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.MovieComments");
            DropTable("dbo.Languages");
            DropTable("dbo.Genres");
        }
    }
}
