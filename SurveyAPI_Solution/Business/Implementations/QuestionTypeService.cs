using Business.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
namespace Business.Implementations
{
    /// <summary>
    /// Service layer for CRUD methods of QuestionType.
    /// </summary>
    public class QuestionTypeService : IQuestionTypeService

    {
        public QuestionType Read(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<QuestionType> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
