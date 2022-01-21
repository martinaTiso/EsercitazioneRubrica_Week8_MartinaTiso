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
    public class ContattoConfiguration:IEntityTypeConfiguration<Contatto>
    {
        public void Configure(EntityTypeBuilder<Contatto> builder)
        {
            builder.ToTable("Contatto"); //Specifico nome della tabella.
            builder.HasKey(c => c.ContattoID); //specifico qual è la PK                                                     
            
            
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Cognome).IsRequired();

            
            builder.HasMany(c => c.Indirizzi).WithOne(l => l.Contatto).HasForeignKey(l => l.ContattoID);
           
           
        }
    
    }
}
