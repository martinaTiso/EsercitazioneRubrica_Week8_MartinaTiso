using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.EF.RepositoryEF
{
    public class RepositoryIndirizziEF : IRepositoryIndirizzo
    {
        private readonly Context ctx;
        public RepositoryIndirizziEF()
        {
            ctx = new Context();
        }

        public Indirizzo Add(Indirizzo item)
        {
            using (var ctx = new Context())
            {
                ctx.Indirizzi.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Indirizzo item)
        {
            throw new NotImplementedException();
        }

        public IList<Indirizzo> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Indirizzi.ToList();
            }
        }

        public Indirizzo GetByCode(int codice)
        {
            using (var ctx = new Context())
            {
                return ctx.Indirizzi.FirstOrDefault(c => c.IndirizzoID == codice);
            }
        }
        
            public Indirizzo GetIndirizziByID(int id)
            {
                return GetAll().Where(i => i.ContattoID == id).FirstOrDefault();
            }
        }
    }

