﻿namespace DataAccess.Interfaces
{
    public interface ICRUDRepo<T> where T : class
    {
        int Create(T entity);

        T Read(int id);

        bool Update(T entity);

        bool Delete(int id);
    }
}
