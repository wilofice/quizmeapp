namespace QuizMeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        choix = c.String(),
                        dateReponse = c.String(),
                        QuestionId = c.Int(nullable: false),
                        ApprenantId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apprenants", t => t.ApprenantId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.ApprenantId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        enonce = c.String(),
                        point = c.Int(nullable: false),
                        niveauDifficulte = c.Int(nullable: false),
                        explication = c.String(),
                        EvaluationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evaluations", t => t.EvaluationId, cascadeDelete: true)
                .Index(t => t.EvaluationId);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date_creation = c.String(),
                        description = c.String(),
                        type = c.String(),
                        scoreSuccess = c.Int(nullable: false),
                        EnseignantId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enseignants", t => t.EnseignantId)
                .Index(t => t.EnseignantId);
            
            CreateTable(
                "dbo.Certificats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        EvaluationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evaluations", t => t.EvaluationId, cascadeDelete: true)
                .Index(t => t.EvaluationId);
            
            CreateTable(
                "dbo.Cours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        intitule = c.String(),
                        date_creation = c.String(),
                        description = c.String(),
                        EnseignantId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enseignants", t => t.EnseignantId)
                .Index(t => t.EnseignantId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        score = c.Int(nullable: false),
                        EvaluationId = c.Int(nullable: false),
                        ApprenantId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apprenants", t => t.ApprenantId)
                .ForeignKey("dbo.Evaluations", t => t.EvaluationId, cascadeDelete: true)
                .Index(t => t.EvaluationId)
                .Index(t => t.ApprenantId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        intitule = c.String(),
                        is_correct = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Objectifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        intitule = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SousObjectifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        intitule = c.String(),
                        ObjectifId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Objectifs", t => t.ObjectifId, cascadeDelete: true)
                .Index(t => t.ObjectifId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SousObjectifs", "ObjectifId", "dbo.Objectifs");
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Scores", "EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.Scores", "ApprenantId", "dbo.Apprenants");
            DropForeignKey("dbo.Questions", "EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.Evaluations", "EnseignantId", "dbo.Enseignants");
            DropForeignKey("dbo.Cours", "EnseignantId", "dbo.Enseignants");
            DropForeignKey("dbo.Certificats", "EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.Reponses", "ApprenantId", "dbo.Apprenants");
            DropIndex("dbo.SousObjectifs", new[] { "ObjectifId" });
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropIndex("dbo.Scores", new[] { "ApprenantId" });
            DropIndex("dbo.Scores", new[] { "EvaluationId" });
            DropIndex("dbo.Cours", new[] { "EnseignantId" });
            DropIndex("dbo.Certificats", new[] { "EvaluationId" });
            DropIndex("dbo.Evaluations", new[] { "EnseignantId" });
            DropIndex("dbo.Questions", new[] { "EvaluationId" });
            DropIndex("dbo.Reponses", new[] { "ApprenantId" });
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropTable("dbo.SousObjectifs");
            DropTable("dbo.Objectifs");
            DropTable("dbo.Options");
            DropTable("dbo.Scores");
            DropTable("dbo.Cours");
            DropTable("dbo.Certificats");
            DropTable("dbo.Evaluations");
            DropTable("dbo.Questions");
            DropTable("dbo.Reponses");
        }
    }
}
