using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Data.Concreate
{
    public class Context:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Orders> Orderss { get; set; }
        public DbSet<Category> Categories {  get; set; }
    }
}
