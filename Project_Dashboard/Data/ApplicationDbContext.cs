using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project_Dashboard.Models;

namespace Project_Dashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Facture> factures { get; set; }
        public DbSet<Fournisseur> fournisseurs { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Article> articles { get; set; }


    }
}
