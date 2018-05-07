using Business.Interfaces;
using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Business.Implementations
{
    /// <summary>
    /// Service layer for CRUD methods of Question.
    /// </summary>
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo _dataRepository;
        public QuestionService(IQuestionRepo dataRepository)
        {
            _dataRepository = dataRepository;
        }
        /// <summary>
        /// Business rules for create an Question.
        /// </summary>
        /// <param name="entity">Question</param>
        /// <returns>int id</returns>
        public int Create(Question entity)
        {
            if (string.IsNullOrEmpty(entity.Text) || string.IsNullOrWhiteSpace(entity.Text)) return 0;
            int id = _dataRepository.Create(entity);
            return id;
        }
        /// <summary>
        /// Gets an Question from a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Question</returns>
        public Question Read(int id)
        {
            if (id <= 0) return null;
            Question entity = _dataRepository.Read(id);
            if (entity == null) return null;
            return entity;
        }
        /// <summary>
        /// Update properties and fields on a <see cref="T:Domain.Entities.Question"/>.
        /// </summary>
        /// <param name="entity"><see cref="T:Domain.Entities.Question"/></param>
        /// <returns>boolean value</returns>
        public bool Update(Question entity)
        {
            if (entity.Id <= 0) return false;
            if (string.IsNullOrEmpty(entity.Text) || string.IsNullOrWhiteSpace(entity.Text)) return false;
            bool response = _dataRepository.Update(entity);
            return response;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Question> ReadAll()
        {
            ICollection<Question> list = new List<Question>();
            list = _dataRepository.ReadAll();
            return list;
        }
    }
}
