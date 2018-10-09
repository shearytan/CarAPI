using System;
using Microsoft.EntityFrameworkCore;
using CarAPI.Entities;

namespace CarAPI.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<CarItem> CarItems{ get; set; }
    }
}
