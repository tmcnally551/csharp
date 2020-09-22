using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace Csharp2
{
    public class BloggingContext : Context
    {
        public ISet<Blog> Blogs { get; set; }
        public ISet<Post> Posts { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
