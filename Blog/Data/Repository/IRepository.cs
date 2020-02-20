using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);
        List<T> GetAll(int id);
        void Add(T value);
        void Update(T value);
        void Remove(int id);
        Task<bool> SaveChangesAsync();
    }
}
