using Domain.Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IQuestionRepo : ICRUDRepo<Question>
    {
        ICollection<Question> ReadAll();
    }
}
