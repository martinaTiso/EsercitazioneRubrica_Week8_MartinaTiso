using EsercitazioneRubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        public List<Contatto> GetAllContatti();
        public Esito InserisciNuovoContatto(Contatto nuovoContatto);
        public Esito InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo);
        public Esito EliminaContatto(int idContattoDaEliminare);
    }
}
