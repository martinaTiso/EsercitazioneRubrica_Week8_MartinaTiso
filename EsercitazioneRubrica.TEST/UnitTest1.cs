using EsercitazioneRubrica.Core.BusinessLayer;
using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.EF.RepositoryEF;
using Xunit;

namespace EsercitazioneRubrica.TEST
{
    public class UnitTest1
    {
        [Fact]
        public void AggiungiContattoTest1()
        {
            //ARRANGE: predisposizione del test
            IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiEF(), new RepositoryIndirizziEF());
            Contatto contatto = new Contatto()
            {
                Nome = "Martino",
                Cognome = "Giggi",
            };
            //ACT: chiamata alla funzionalità da testare
            Esito risultato = bl.InserisciNuovoContatto(contatto);
            //ASSERT: valutazione del risultato atteso vs restituito
            Assert.True(risultato.IsOk);
        }
    }
}