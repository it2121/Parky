using Microsoft.EntityFrameworkCore;
using Parky_API.Models;

namespace Parky_API.Data
{
    public class ApplicationDbContext : DbContext




    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }


        public DbSet<NationalPark> NationalPark { get; set; } 
        public DbSet<Trail> Trails { get; set; }

    }
}
