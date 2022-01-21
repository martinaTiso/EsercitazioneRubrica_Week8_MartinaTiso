using EsercitazioneRubrica.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.EF.Configuration
{
    public class IndirizzoConfiguration : IEntityTypeConfiguration<Indirizzo>
    {
        public void Configure(EntityTypeBuilder<Indirizzo> builder)
        {
            builder.ToTable("Indirizzo");
            builder.HasKey(l => l.IndirizzoID);
            builder.Property(l => l.Tipologia).IsRequired();
            builder.Property(l => l.Via).IsRequired();
            builder.Property(l => l.Citta).IsRequired();
            builder.Property(l => l.Cap).IsRequired();
            builder.Property(l => l.Provincia).IsRequired();
            builder.Property(l => l.Nazione).IsRequired();

            
            builder.HasOne(l => l.Contatto).WithMany(c => c.Indirizzi).HasForeignKey(l => l.ContattoID);
            
           
        }
    }
    
    }

