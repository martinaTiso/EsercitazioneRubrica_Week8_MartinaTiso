using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.EF.RepositoryEF
{
    public class RepositoryContattiEF : IRepositoryContatto
    {
        private readonly Context ctx;
        public RepositoryContattiEF()
        {
            ctx = new Context();
        }
        public Contatto Add(Contatto item)
        {
            using (var ctx = new Context())
            {
                ctx.Contatti.Add(item);
            ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Contatto item)
        {
            ctx.Contatti.Remove(item);
            ctx.SaveChanges();

            return true;
        }

        public IList<Contatto> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Contatti.ToList();
            }
        }

        public Contatto GetByCode(int codice)
        {
            using (var ctx = new Context())
            {
                return ctx.Contatti.FirstOrDefault(c => c.ContattoID == codice);
            }
        }
    }
}
