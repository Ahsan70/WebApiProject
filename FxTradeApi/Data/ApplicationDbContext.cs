using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FxTradeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FxTradeApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<NationalPark> NationalParks { get; set; }

    }
}
