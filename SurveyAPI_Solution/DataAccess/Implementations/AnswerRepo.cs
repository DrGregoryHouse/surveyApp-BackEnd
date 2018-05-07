using DataAccess.Helpers;
using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Data.Entity;
using System.Linq;
namespace Data.Implementations
{
    /// <summary>
    /// Data Access to database for Answer entity.
    /// </summary>
    public class AnswerRepo : IAnswerRepo
    {
        /// <summary>
        /// Adds an Answer to database.
        /// </summary>
        /// <param name="entity">Answer</param>
        /// <returns>int id</returns>
        public int Create(Answer entity)
        {
            using (var ctx = new DataContext())
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = null;
                ctx.Answers.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }
        /// <summary>
        /// Gets a Answers from database.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Answer</returns>
        public Answer Read(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update properties and fields on a Answer.
        /// </summary>
        /// <param name="entity">Answer</param>
        /// <returns>boolean value</returns>
        public bool Update(Answer entity)
        {
            using (var ctx = new DataContext())
            {
                Answer currentAnswer = ctx.Answers.SingleOrDefault(x => x.Id == entity.Id);
                if (currentAnswer == null) return false;
                currentAnswer.OpenText = entity.OpenText;
                currentAnswer.ModifiedDate = DateTime.Now;
                ctx.Entry(currentAnswer).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Implements a soft-delete on a Answer to deactivate from App.
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>boolean value</returns>
        public bool Delete(int id)
        {
            using (var ctx = new DataContext())
            {
                Answer entity = ctx.Answers.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (entity == null) return false;

                ctx.Entry(entity).State = EntityState.Deleted;

                ctx.SaveChanges();

                return true;
            }
        }
    }
}
