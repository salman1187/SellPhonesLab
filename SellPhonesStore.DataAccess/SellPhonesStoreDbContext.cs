using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public class SellPhonesStoreDbContext : DbContext
    {
        // configure database
        public SellPhonesStoreDbContext() : base("defaultConnection")
        {

        }
        //configure tables
        public DbSet<Phone> Phones { get; set; }
        public DbSet<OrderedPhone> OrderedPhones { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
