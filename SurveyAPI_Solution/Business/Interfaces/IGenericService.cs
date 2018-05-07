namespace Business.Interfaces
{
    /// <summary>
    /// Generic interface for CRUD methods
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IGenericService<T> where T : class
    {
        int Create(T entity);

        T Read(int id);

        bool Update(T entity);

        bool Delete(int id);
    }

}
