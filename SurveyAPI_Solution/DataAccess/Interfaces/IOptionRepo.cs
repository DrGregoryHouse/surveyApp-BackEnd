using Domain.Entities;

namespace DataAccess.Interfaces
{
    public interface IOptionRepo : ICRUDRepo<Option>
    {
        bool Exist(string label);
    }
}
