using ConsummingWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsummingWebApi.Data
{
    public class AppWebContext :IdentityDbContext
    {
        public AppWebContext(DbContextOptions<AppWebContext> options) : base(options)
        {

        }

        public DbSet<Users> users { get; set; }
    }
}
