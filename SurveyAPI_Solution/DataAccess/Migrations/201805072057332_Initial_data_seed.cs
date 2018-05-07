namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_data_seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guest = c.String(),
                        OpenText = c.String(),
                        QuestionId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 50),
                        Value = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Answer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answer_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        QuestionTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, cascadeDelete: true)
                .Index(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Option_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Option_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.Option_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "dbo.SurveyAnswers",
                c => new
                    {
                        Survey_Id = c.Int(nullable: false),
                        Answer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Survey_Id, t.Answer_Id })
                .ForeignKey("dbo.Surveys", t => t.Survey_Id, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: true)
                .Index(t => t.Survey_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.SurveyQuestions",
                c => new
                    {
                        Survey_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Survey_Id, t.Question_Id })
                .ForeignKey("dbo.Surveys", t => t.Survey_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Survey_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Options", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.Surveys", "StatusId", "dbo.Status");
            DropForeignKey("dbo.SurveyQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SurveyQuestions", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.SurveyAnswers", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.SurveyAnswers", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropForeignKey("dbo.QuestionOptions", "Option_Id", "dbo.Options");
            DropForeignKey("dbo.QuestionOptions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.SurveyQuestions", new[] { "Question_Id" });
            DropIndex("dbo.SurveyQuestions", new[] { "Survey_Id" });
            DropIndex("dbo.SurveyAnswers", new[] { "Answer_Id" });
            DropIndex("dbo.SurveyAnswers", new[] { "Survey_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "Option_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "Question_Id" });
            DropIndex("dbo.Surveys", new[] { "StatusId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropIndex("dbo.Options", new[] { "Answer_Id" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.SurveyQuestions");
            DropTable("dbo.SurveyAnswers");
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.Status");
            DropTable("dbo.Surveys");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
            DropTable("dbo.Answers");
        }
    }
}
