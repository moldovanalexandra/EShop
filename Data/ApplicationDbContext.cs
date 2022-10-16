using EShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategorieProdus> CategorieProdus { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<DetaliiComanda> DetaliiComenzi { get; set; }
    }
}
