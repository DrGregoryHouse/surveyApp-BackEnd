using DataAccess.Helpers;
using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Data.Implementations
{
    /// <summary>
    /// Data Access to database for Survey entity.
    /// </summary>
    public class SurveyRepo : ISurveyRepo
    {
        /// <summary>
        /// Adds a Survey to database.
        /// </summary>
        /// <param name="entity">Survey</param>
        /// <returns>int id</returns>
        public int Create(Survey entity)
        {
            using (var ctx = new DataContext())
            {
                //Survey newSurvey = ctx.Surveys.Include(i => i.Status).FirstOrDefault();
                //var selectStatus = ctx.Statuses.Where(i => i.Label == "Draft").FirstOrDefault();
                //newSurvey.Title = entity.Title;
                //newSurvey.Description = entity.Description;
                //newSurvey.CreatedDate = DateTime.Now;
                //newSurvey.ModifiedDate = null;
                //newSurvey.IsActive = true;
                //newSurvey.Status.Add(selectStatus);
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = null;
                entity.IsActive = true;
                entity.StatusId = 1;
                ctx.Surveys.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }
        /// <summary>
        /// Gets a Survey from database.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Survey</returns>
        public Survey Read(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Surveys.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }
        /// <summary>
        /// Update properties and fields on a Survey.
        /// </summary>
        /// <param name="entity">Survey</param>
        /// <returns>boolean value</returns>
        public bool Update(Survey entity)
        {
            using (var ctx = new DataContext())
            {
                Survey currentSurvey = ctx.Surveys.SingleOrDefault(x => x.Id == entity.Id);
                if (currentSurvey == null) return false;
                currentSurvey.Title = entity.Title;
                currentSurvey.Description = entity.Description;
                currentSurvey.ModifiedDate = DateTime.Now;
                ctx.Entry(currentSurvey).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Implements a soft-delete on a Survey to deactivate from App.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>boolean value</returns>
        public bool Delete(int id)
        {
            using (var ctx = new DataContext())
            {
                Survey entity = ctx.Surveys.AsNoTracking().SingleOrDefault(x => x.Id == id);
                if (entity == null) return false;
                entity.IsActive = true;
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Adds a Question to a Survey by ID's
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        public bool AddQuestionToSurvey(int questionId, int surveyId)
        {
            using (var ctx = new DataContext())
            {
                Survey survey = ctx.Surveys.AsNoTracking().SingleOrDefault(x => x.Id == surveyId);
                Question question = ctx.Questions.AsNoTracking().SingleOrDefault(x => x.Id == questionId);
                if (survey == null || question == null) return false;
                survey.Questions.Add(question);
                ctx.Entry(survey).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }

        }

        public ICollection<Survey> ReadAll()
        {
            ICollection<Survey> list = new List<Survey>();
            using (var ctx = new DataContext())
            {
                list = ctx.Surveys.ToList();
                return list;
            }
        }

        public ICollection<Question> ReadQuestions(int survey_id)
        {
            throw new NotImplementedException();
        }
    }
}
