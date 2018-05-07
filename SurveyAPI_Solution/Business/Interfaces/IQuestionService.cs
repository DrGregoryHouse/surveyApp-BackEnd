using Domain.Entities;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IQuestionService : IGenericService<Question>
    {
        ICollection<Question> ReadAll();
    }
}
