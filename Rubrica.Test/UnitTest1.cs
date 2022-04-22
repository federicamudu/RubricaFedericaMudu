using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryMOCK;
using Xunit;

namespace Rubrica.Test
{
    public class UnitTest1
    {
        IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        [Fact]
        public void ShouldAddContact()
        {
            //ARRANGE: predisposizione del test

            Contatto newContact = new Contatto()
            {
                Nome = "NomeProva",
                Cognome = "CognomeProva"
            };
            int numeroContattiGiaPresenti = bl.GetAllContatti().Count;

            //ACT: chiamata alla funzionalita da testare
            bl.InserisciNuovoContatto(newContact);

            //ASSERT: valutazione del risultato atteso vs restituito
            Assert.Equal(bl.GetAllContatti().Count, numeroContattiGiaPresenti + 1);
        }
    }
}