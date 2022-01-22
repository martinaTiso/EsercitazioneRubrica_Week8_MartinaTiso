using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatto contattiRepo;
        private readonly IRepositoryIndirizzo indirizziRepo;


        //Costruttore
        public MainBusinessLayer(IRepositoryContatto contatti, IRepositoryIndirizzo indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito EliminaContatto(int idContattoDaEliminare)
        {
            
            var contattoEsistente = contattiRepo.GetByCode(idContattoDaEliminare);
            if (contattoEsistente == null)
            {
                return new Esito { Messaggio = "Id non valido.Impossibile eliminare.", IsOk = false };
            }
            else
            {
                List<Indirizzo> indirizzoDelcontatto = indirizziRepo.GetIndirizziByID(idContattoDaEliminare);
                if (indirizzoDelcontatto.Count == 0)
                {
                    contattiRepo.Delete(contattoEsistente);
                    return new Esito { Messaggio = "Contatto eliminato con successo", IsOk = true };
                }
                else
                {

                    return new Esito { Messaggio = "non è possibile eliminare il contatto", IsOk = false };
                }

            }
        }


        public List<Contatto> GetAllContatti()
        {
            return contattiRepo.GetAll().ToList();
        }
        public List<Indirizzo> GetAllIndirizzi()
        {
            return indirizziRepo.GetAll().ToList();
        }




        public Esito InserisciNuovoContatto(Contatto nuovoContatto)
        {
            //controllo input
            //non deve esistere un altro contatto con lo stesso nome, cognome 
            var docenteEsistente = GetAllContatti().FirstOrDefault(d => d.Nome == nuovoContatto.Nome && d.Cognome == nuovoContatto.Cognome);

            if (docenteEsistente != null)
            {
                return new Esito { Messaggio = "Contattp già esistente", IsOk = false };
            }
            contattiRepo.Add(nuovoContatto);
            return new Esito { Messaggio = "Contatto Aggiunto con successo", IsOk = true };

        }

        public Esito InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo)
        {
              Indirizzo indirizzoEsistente=indirizziRepo.GetByCode(nuovoIndirizzo.IndirizzoID);
           
            if (indirizzoEsistente == null)
            {
                indirizziRepo.Add(nuovoIndirizzo);
                return new Esito { Messaggio = "Indirizzo Aggiunto con successo", IsOk = true };

            }
            else
            {
                return new Esito { Messaggio = "impossibile aggiungere indirizzo", IsOk = false };
            }
            

        }
    }
}

    

