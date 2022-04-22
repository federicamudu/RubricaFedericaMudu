using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryADO;
using Rubrica.RepositoryMOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Presentation
{
    internal class Menu
    {
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiADO(), new RepositoryIndirizziADO());
        internal static void Start()
        {
            bool continua = true;
            
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    InserisciNuovoContatto();
                    break;
                case 3:
                    InserisciNuovoIndirizzo();
                    break;
                case 4:
                    EliminaContatto();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void EliminaContatto()
        {
            Console.WriteLine("Ecco l'elenco dei contatti:\n");
            VisualizzaContatti();
            Console.WriteLine("Quale Contatto vuoi eliminare? Inserisci l'id");
            int idContattoDaEliminare;
            while (!int.TryParse(Console.ReadLine(), out idContattoDaEliminare))
            {
                Console.WriteLine("Inserisci un id numerico");
            }
            Esito esito = bl.EliminaContatto(idContattoDaEliminare);
            Console.WriteLine(esito);
            

        }

        private static void InserisciNuovoIndirizzo()
        {
            Console.Write("Ecco i Contatti disponibili:\n");
            VisualizzaContatti();
            Console.Write("\nInserisci l'id del contatto a cui vuoi associare il nuovo indirizzo: ");
            int idContatto;
            while (!int.TryParse(Console.ReadLine(), out idContatto)) //TODO: impostare controllo dell'id prima
            {
                Console.WriteLine("Inserisci un numero");
            }
            Console.WriteLine("Inserisci la tipologia");
            string tipologia = Console.ReadLine();
            Console.WriteLine("Inserisci la via");
            string via = Console.ReadLine();
            Console.WriteLine("Inserisci la città");
            string citta = Console.ReadLine();
            Console.WriteLine("Inserisci il CAP");
            string cap = Console.ReadLine();
            Console.WriteLine("Inserisci la provincia");
            string provincia = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione");
            string nazione = Console.ReadLine();

            Indirizzo nuovoIndirizzo = new Indirizzo();
            nuovoIndirizzo.Tipologia = tipologia;
            nuovoIndirizzo.Provincia = provincia;
            nuovoIndirizzo.Nazione = nazione;
            nuovoIndirizzo.Citta = citta;
            nuovoIndirizzo.Via = via;
            nuovoIndirizzo.CAP = cap;
            nuovoIndirizzo.ContattoID = idContatto;

            Esito esito = bl.InserisciNuovoIndirizzo(nuovoIndirizzo);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoContatto()
        {          
            Console.WriteLine("Inserisci il nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            string cognome = Console.ReadLine();

            Contatto nuovoContatto = new Contatto();
            nuovoContatto.Nome = nome;
            nuovoContatto.Cognome = cognome;

            Esito esito = bl.InserisciNuovoContatto(nuovoContatto);
            Console.WriteLine(esito);
        }

        private static void VisualizzaContatti()
        {
            var contatti = bl.GetAllContatti();
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

        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("1. Visualizza Contatti");
            Console.WriteLine("2. Inserisci nuovo contatto");
            Console.WriteLine("3. Inserisci nuovo Indirizzo");
            Console.WriteLine("4. Elimina Contatto");
            Console.WriteLine("\n0. Exit");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }
    }
}
