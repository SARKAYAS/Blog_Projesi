using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using System.Data.SqlClient;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=AYSEGUL;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

           // optionsBuilder.UseSqlServer(@"Data Source=AYSEGUL;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=True");


            //string connectionString = "Server=AYSEGUL;Database=Blog;User Id=saa;Password=123456789;TrustServerCertificate=true;";
            //SqlConnection connection = new SqlConnection(connectionString);

        }

        public Microsoft.EntityFrameworkCore.DbSet<About> Abouts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Admin> Admins { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Author> Author { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Blog> Blogs { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Contact> Contact { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Comment> Comment { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SubscribeMail> SubscribeMails { get; set; }
    }
}
