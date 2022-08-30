using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalSami.Entity;
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
        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<Experiences> experiences { get; set; }
    }
}
