// See https://aka.ms/new-console-template for more information
using EsercitazioneRubrica.Core.BusinessLayer;
using EsercitazioneRubrica.Core.Entities;
using EsercitazioneRubrica.EF.RepositoryEF;
using EsercitazioneRubrica.Mock;

Console.WriteLine("Hello, World!");


//IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiEF(), new RepositoryIndirizziEF());

bool continua = true;

while (continua)
{
    int scelta = SchermoMenu();
    continua = AnalizzaScelta(scelta);
}

int SchermoMenu()
{
    Console.WriteLine("***************Menu**************");
    
    Console.WriteLine("1.Visualizza i contatti");
    Console.WriteLine("2.Aggiungere nuovo Contatto");
    Console.WriteLine("3.Aggiungere un indirizzo associato ad  un contatto");
    Console.WriteLine("4.Eliminare un Contatto");
    Console.WriteLine("5.Exit");
    

    int scelta;
    Console.WriteLine("Inserisci la tua scelta: ");
    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 5))
    {
        Console.WriteLine("Scelta errata. Inserisci una scelta corretta: ");
    }
    return scelta;

}

bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaContatti();
            break;
        case 2:
            InserisciContatto();
            break;
        case 3:
            InserisciIndirizzo();
            break;
        case 4:
            EliminaContatto();
            break;
       
        case 5:
            return false;
            //default:
            //    break;
    }
    return true;
}


void EliminaContatto()
{
    Console.WriteLine("Elenco completo dei indirizzi disponibili:");
    VisualizzaContatti();
    Console.WriteLine("Quale contatto vuoi eliminare? Inserisci l'id");
    int idContattoDaEliminare = int.Parse(Console.ReadLine());
    Esito esito = bl.EliminaContatto(idContattoDaEliminare);
    Console.WriteLine(esito.Messaggio);

}
void InserisciIndirizzo()
{
    string tipologia;
    do
    {
        Console.WriteLine("inserisci tipologia :Residenza o Domicilio");
        tipologia = Console.ReadLine();

    } while (!(tipologia == "Residenza" || tipologia == "Domicilio"));


    Console.WriteLine("Inserisci la via del nuovo indirizzo");
    string via = Console.ReadLine();
    Console.WriteLine("Inserisci la città  del nuovo indirizzo");
    string citta = Console.ReadLine();
    Console.WriteLine("Inserisci il cap del nuovo indirizzo");
    int cap =int.Parse( Console.ReadLine());
    Console.WriteLine("Inserisci la provincia del nuovo indirizzo");
    string provincia = Console.ReadLine();
    Console.WriteLine("Inserisci la Nazione del nuovo indirizzo");
    string nazione = Console.ReadLine();


    //lo creo
    Indirizzo nuovoIndirizzo = new Indirizzo();
    nuovoIndirizzo.Tipologia = tipologia;
    nuovoIndirizzo.Via = via;
    nuovoIndirizzo.Citta = citta;
    nuovoIndirizzo.Cap = cap;
    nuovoIndirizzo.Provincia = provincia;
    nuovoIndirizzo.Nazione = nazione;


    //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB".
    Esito esito = bl.InserisciNuovoIndirizzo(nuovoIndirizzo);
    //Stampo il "risultato/messaggio"
    Console.WriteLine(esito.Messaggio);
}
void InserisciContatto()
{

    
        //chiedo all'utente i dati per "creare" il nuovoDocente;            
        Console.WriteLine("Inserisci il nome del nuovo Contatto:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome del nuovo Contatto:");
        string cognome = Console.ReadLine();
        

        //lo creo
        Contatto nuovoContatto = new Contatto();
        nuovoContatto.Nome = nome;
        nuovoContatto.Cognome = cognome;
       

        //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB".
        Esito esito = bl.InserisciNuovoContatto(nuovoContatto);
        //Stampo il "risultato/messaggio"
        Console.WriteLine(esito.Messaggio);
    }


void VisualizzaContatti()
{
    List<Contatto> contatti = bl.GetAllContatti();
    if (contatti.Count == 0)
    {
        Console.WriteLine("Nessun contatto presente");
    }
    else
    {
        foreach (var item in contatti)
        {
            Console.WriteLine(item);
        }
    }
}