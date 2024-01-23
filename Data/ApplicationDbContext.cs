using Cotrageco.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cotrageco.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Cotrageco_Content>Cotrageco_Contents { get; set; }
        public DbSet<Home_Banner>Home_Banners { get; set; }
        public DbSet<Objective>Objectives { get; set; }
        public DbSet<Project>Projects { get; set; }
        public DbSet<OFS>OFSs { get; set; }
        public DbSet<Partner>Partners { get; set; }
        public DbSet<Corperate_Info> Corperate_Infos { get; set; }

        // I've added the following tables

        public DbSet<Sectors_Of_Intervention> Sectors_Of_Interventions { get; set; } 
        public DbSet<Registration> Registrations { get; set; } 
        public DbSet<Our_Realisation> Our_Realisations { get; set; } 
        public DbSet<Corperate_Purpose> Corperate_Purposes { get; set; }
        public DbSet<Project_Title> Project_Titles { get; set; }
        public DbSet<Realisation_Caption> Realisation_Captions { get; set; }
        public DbSet<Cotrageco.Models.Banner> Banner { get; set; } = default!;

    }
}