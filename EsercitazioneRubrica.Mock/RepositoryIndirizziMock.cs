using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Mock
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzo
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>()
        {
            new Indirizzo{IndirizzoID=1, Tipologia="Domicilio", Via= "Rossi",Citta="Roma",Cap=00056,Provincia="RM",Nazione="Italia"},
            new Indirizzo{IndirizzoID=1, Tipologia="Residenza", Via= "Rossi",Citta="Milano",Cap=00047,Provincia="MI",Nazione="Italia"},
        };
        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count() == 0)
            {
                item.IndirizzoID = 1;
            }
            else
            {
                item.IndirizzoID = Indirizzi.Max(x => x.ContattoID) + 1;
            }
            Indirizzi.Add(item);
            return item;
        }

        public bool Delete(Indirizzo item)
        {
            Indirizzi.Remove(item);
            return true;
        }

        public IList<Indirizzo> GetAll()
        {
            return Indirizzi;
        }

        public Indirizzo GetByCode(int codice)
        {
            return Indirizzi.FirstOrDefault(c => c.IndirizzoID == codice);
        }

        public Indirizzo GetIndirizziByID(int id)
        {
            return GetAll().Where(i=>i.ContattoID==id).FirstOrDefault();
        }
    }
}
