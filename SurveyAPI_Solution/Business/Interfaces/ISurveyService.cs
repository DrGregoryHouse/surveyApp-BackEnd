using Business.Interfaces;
using Domain.Entities;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface ISurveyService : IGenericService<Survey>
    {
        //ICollection<Question> GetQuestionsBySurveyId(int id);
        ICollection<Survey> ReadAll();
    }
}
