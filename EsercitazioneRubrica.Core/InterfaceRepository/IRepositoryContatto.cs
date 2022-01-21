using EsercitazioneRubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Core.InterfaceRepository
{
    public interface IRepositoryContatto : IRepository<Contatto>
    {
        public Contatto GetByCode(int codice);
    }
   
 }

