using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Data
{
    public class ProjectDbContext : DbContext
    {


        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

    }
}
