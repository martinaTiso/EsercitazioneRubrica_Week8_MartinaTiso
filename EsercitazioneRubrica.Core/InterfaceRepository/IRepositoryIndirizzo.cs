using EsercitazioneRubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Core.InterfaceRepository
{
    public interface IRepositoryIndirizzo : IRepository<Indirizzo>
    {
        public Indirizzo GetByCode(int codice);
        public List<Indirizzo> GetIndirizziByID( int id);
    }
}
