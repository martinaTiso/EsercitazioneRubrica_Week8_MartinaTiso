using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.EF
{
    public class Context :DbContext
    {
        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Indirizzo> Indirizzi { get; set; }
        

        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RubricaContatt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Contatto>(new ContattoConfiguration());
            modelBuilder.ApplyConfiguration<Indirizzo>(new IndirizzoConfiguration());
           
        }

    }
}

