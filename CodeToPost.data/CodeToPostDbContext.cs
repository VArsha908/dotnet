using CodeToPost.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeToPost.Data
{
    public class CodeToPostDbContext : DbContext
    {
        public CodeToPostDbContext(DbContextOptions<CodeToPostDbContext> options)
            : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }

        internal Post ClickCounter()
        {
            throw new NotImplementedException();
        }
    }
}
