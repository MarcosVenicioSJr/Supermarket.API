﻿namespace Supermarket.API.Interfaces.Services
{
    public interface IServices<T> where T : class
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(int id);
    }
}
