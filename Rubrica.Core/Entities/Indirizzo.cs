using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        //FK verso Contatto
        public int ContattoID { get; set; }
        public Contatto Contatto { get; set; }

        public override string ToString()
        {
            return $"{IdIndirizzo} - Tipo: {Tipologia}: {Via}, {Citta}, {CAP}, ({Provincia}), {Nazione}";
        }

    }
}
