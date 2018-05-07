namespace DataAccess.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Helpers.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Helpers.DataContext ctx)
        {
            ctx.Statuses.Add(new Status { Label = "Draft", CreatedDate = DateTime.Now });
            ctx.Statuses.Add(new Status { Label = "Ready", CreatedDate = DateTime.Now });
            ctx.Statuses.Add(new Status { Label = "Done", CreatedDate = DateTime.Now });
            ctx.Statuses.Add(new Status { Label = "Cancel", CreatedDate = DateTime.Now });
            ctx.SaveChanges();
            ctx.QuestionTypes.Add(new QuestionType { Description = "Si/No", CreatedDate = DateTime.Now });
            ctx.QuestionTypes.Add(new QuestionType { Description = "Open Response", CreatedDate = DateTime.Now });
            ctx.QuestionTypes.Add(new QuestionType { Description = "Multiple Choice", CreatedDate = DateTime.Now });
            ctx.SaveChanges();
            ctx.Options.Add(new Option { Text = "Easy", Value = 1, CreatedDate = DateTime.Now });
            ctx.Options.Add(new Option { Text = "Medium", Value = 2, CreatedDate = DateTime.Now });
            ctx.Options.Add(new Option { Text = "Normal", Value = 3, CreatedDate = DateTime.Now });
            ctx.Options.Add(new Option { Text = "Advanced", Value = 4, CreatedDate = DateTime.Now });
            ctx.Options.Add(new Option { Text = "Expert", Value = 5, CreatedDate = DateTime.Now });
            ctx.SaveChanges();
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"Analysis and Design\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"Foundations of C#\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"Databases and SQL Server\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"ADO.NET and Entity Frameworks\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"Service Layer\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"MVC\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify the content of the \"Front-end development\" module?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"AngularJS\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"Bootstrap\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"JavaScript\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"Entity Frameworks\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"ADO.NET\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"ASP.NET\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"MVC\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"SQL\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in database administration?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"React.js\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"Node.js\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"HTML\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"CSS\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"SASS\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"Visual Studio 2017\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills in \"MonoDevelop\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills to develop applications in \"C#\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills to develop applications in \"C++\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills to develop applications in \"Java\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How do you qualify your skills to develop applications in \"Python\"?",
                IsActive = true,
                QuestionTypeId = 3,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "What is the goal of your life?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "What is your name?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "What do you like the most?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "How many questions does this survey have?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "Define yourself in one word.",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "If you could be an animal in a zoo, which one would you like to be?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "Does this survey has bored you yet?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.Questions.Add(new Question
            {
                Text = "Can you tell me one question?",
                IsActive = true,
                QuestionTypeId = 2,
                CreatedDate = DateTime.Now
            });
            ctx.SaveChanges();
            ctx.Surveys.Add(new Survey
            {
                Title = "Encuesta X",
                Description = "Esta es la primer encuesta hecha por seed migration",
                IsActive = true,
                StatusId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });

            ctx.Surveys.Add(new Survey
            {
                Title = "Encuesta Presidencial",
                Description = "Encuesta realizada para las elecciones 2018",
                IsActive = true,
                StatusId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });
            ctx.SaveChanges();
        }
    }
}
