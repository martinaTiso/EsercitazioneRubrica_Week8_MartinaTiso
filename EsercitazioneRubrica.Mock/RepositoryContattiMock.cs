using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Mock
{
    public class RepositoryContattiMock : IRepositoryContatto
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto{ContattoID=1, Nome="Mario", Cognome= "Rossi"},
            new Contatto{ContattoID=2, Nome="Martina", Cognome= "Tiso"},
        };


        public IList<Contatto> GetAll()
        {
            return Contatti;
        }
        public Contatto Add(Contatto item)
        {
            if (Contatti.Count()==0)
            {
                item.ContattoID = 1;
            }else
            {
                item.ContattoID = Contatti.Max(x => x.ContattoID) + 1;
            }
            Contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            Contatti.Remove(item);
            return true;
        }

        public Contatto GetByCode(int codice)
        {
            return Contatti.FirstOrDefault(c => c.ContattoID == codice);
        }



        

    }
}

