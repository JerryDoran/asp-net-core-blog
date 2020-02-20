using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class IRepository : DbContext
    {
        public IRepository(DbContextOptions<IRepository> options) : base(options)
        {

        }

        // Create a tables called 'Posts' and 'Users' and each record is a singel 'Post'
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
