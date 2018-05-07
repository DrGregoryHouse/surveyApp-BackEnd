using Domain.Entities;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IQuestionTypeService
    {
        QuestionType Read(int id);

        ICollection<QuestionType> ReadAll();
    }
}
