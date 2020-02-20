using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class UserRespository : IRepository<User>
    {
        private IRepository _context;

        public UserRespository(IRepository context)
        {
            _context = context;
        }

        public void Add(User value)
        {
            _context.Users.Add(value);
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public List<User> GetAll(int id)
        {
            return _context.Users.ToList();
        }

        public void Remove(int id)
        {
            _context.Users.Remove(Get(id));
        }

        public void Update(User value)
        {
            _context.Users.Update(value);
        }

        // This method actually makes the changes to the database.
        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
