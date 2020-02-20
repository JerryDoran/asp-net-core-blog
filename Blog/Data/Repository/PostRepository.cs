using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private IRepository _context;

        public PostRepository(IRepository context)
        {
            _context = context;
        }

        public void Add(Post value)
        {
            _context.Posts.Add(value);
        }

        public Post Get(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetAll(int id)
        {
            return _context.Posts.ToList();
        }

        public void Remove(int id)
        {
            _context.Posts.Remove(Get(id));
        }

        public void Update(Post value)
        {
            _context.Posts.Update(value);
        }


        // This method actually makes the changes to the database.
        public async Task<bool> SaveChangesAsync()
        {
            if(await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }        
    }
}
