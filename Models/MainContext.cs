using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationBlog.Models
{
    public class MainContext:DbContext
    {
        public MainContext()
        {
            Database.SetInitializer(new MainInitializer());
        }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarList> CarLists { get; set; }
        //public DbSet<CarSupplier> CarSuppliers { get; set; }
    }
}