using Domain.Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ISurveyRepo : ICRUDRepo<Survey>
    {
        ICollection<Survey> ReadAll();
        bool AddQuestionToSurvey(int questionId, int surveyId);
        ICollection<Question> ReadQuestions(int survey_id);
    }
}
