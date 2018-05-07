using DataAccess.Helpers;
using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Data.Implementations
{
    public class QuestionRepo : IQuestionRepo
    {
        /// <summary>
        /// Adds a Question to database.
        /// </summary>
        /// <param name="entity">Question</param>
        /// <returns>int id</returns>
        public int Create(Question entity)
        {
            using (var ctx = new DataContext())
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = null;
                ctx.Questions.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }
        /// <summary>
        /// Gets a Question from database.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Question</returns>
        public Question Read(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Questions.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }
        /// <summary>
        /// Update properties and fields on a Question.
        /// </summary>
        /// <param name="entity">Question</param>
        /// <returns>boolean value</returns>
        public bool Update(Question entity)
        {
            using (var ctx = new DataContext())
            {
                Question currentQuestion = ctx.Questions.SingleOrDefault(x => x.Id == entity.Id);

                if (currentQuestion == null) return false;

                currentQuestion.Text = entity.Text;

                currentQuestion.ModifiedDate = DateTime.Now;

                ctx.Entry(currentQuestion).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }
        /// <summary>
        /// Implements a soft-delete on a Question to deactivate from App.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>boolean value</returns>
        public bool Delete(int id)
        {
            using (var ctx = new DataContext())
            {
                Question currentQuestion = ctx.Questions.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (currentQuestion == null) return false;

                currentQuestion.IsActive = false;

                ctx.Entry(currentQuestion).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public ICollection<Question> ReadAll()
        {
            ICollection<Question> list = new List<Question>();
            using (var ctx = new DataContext())
            {
                list = ctx.Questions.ToList();
                return list;
            }
        }
    }
}
