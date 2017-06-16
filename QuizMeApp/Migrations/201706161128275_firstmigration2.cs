namespace QuizMeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectifs", "CoursId", c => c.Int(nullable: false));
            CreateIndex("dbo.Objectifs", "CoursId");
            AddForeignKey("dbo.Objectifs", "CoursId", "dbo.Cours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objectifs", "CoursId", "dbo.Cours");
            DropIndex("dbo.Objectifs", new[] { "CoursId" });
            DropColumn("dbo.Objectifs", "CoursId");
        }
    }
}
