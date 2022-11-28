using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using personalsami.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalSami.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerModel> customerModels { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<NormalOrderModel> normalOrders { get; set; }
        public DbSet<SpeccialOrderModel> speccialOrders { get; set; }

    }
}
