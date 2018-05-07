using Business.Interfaces;
using DataAccess.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Business.Implementations
{
    /// <summary>
    /// Service layer for CRUD methods of Survey.
    /// </summary>
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepo _dataRepository;
        /// <summary>
        /// Initializa a new instance of <see cref="T:Data.Implementations.SurveyRepository"/>
        /// </summary>
        /// <param name="dataRepository"></param>
        public SurveyService(ISurveyRepo dataRepository)
        {
            _dataRepository = dataRepository;
        }
        /// <summary>
        /// Business rules for create an Survey.
        /// </summary>
        /// <param name="entity">Survey</param>
        /// <returns>int id</returns>
        public int Create(Survey entity)
        {
            if (string.IsNullOrEmpty(entity.Title) || string.IsNullOrWhiteSpace(entity.Title)) return 0;
            if (string.IsNullOrEmpty(entity.Description) || string.IsNullOrWhiteSpace(entity.Description)) return 0;
            int id = _dataRepository.Create(entity);
            return id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the Questions given id Survey.
        /// </summary>
        /// <param name="id">survey Id</param>
        /// <returns>ICollection<Question></returns>
        public ICollection<Question> GetQuestionsBySurveyId(int survey_id)
        {
            if (survey_id <= 0) return null;
            ICollection<Question> questionList = _dataRepository.ReadQuestions(survey_id);
            if (questionList == null) return null;
            return questionList;
        }
        /// <summary>
        /// Gets an Survey from a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Survey</returns>
        public Survey Read(int id)
        {
            if (id <= 0) return null;
            Survey survey = _dataRepository.Read(id);
            if (survey == null) return null;
            return survey;
        }
        /// <summary>
        /// Update properties and fields on a <see cref="T:Domain.Entities.Survey"/>.
        /// </summary>
        /// <param name="entity"><see cref="T:Domain.Entities.Survey"/></param>
        /// <returns>boolean value</returns>
        public bool Update(Survey entity)
        {
            if (entity.Id <= 0) return false;
            if (string.IsNullOrEmpty(entity.Title) || string.IsNullOrWhiteSpace(entity.Title)) return false;
            //bool OptionTextExist = _dataRepository.Exist(entity.Title);
            //if (OptionTextExist) return false;
            bool response = _dataRepository.Update(entity);
            return response;
        }
        public bool AddQuestionToSurvey(int questionId, int surveyId)
        {
            if (questionId <= 0 || surveyId <= 0) return false;
            bool result = _dataRepository.AddQuestionToSurvey(questionId, surveyId);
            return result;
        }
        public ICollection<Survey> ReadAll()
        {
            ICollection<Survey> list = new List<Survey>();
            list = _dataRepository.ReadAll();
            return list;
        }
    }
}
