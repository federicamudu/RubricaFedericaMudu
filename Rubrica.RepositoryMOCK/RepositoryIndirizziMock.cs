using Rubrica.Core.Entities;
using Rubrica.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMOCK
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>();

        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count == 0)
            {
                item.IdIndirizzo = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var i in Indirizzi)
                {
                    if (i.IdIndirizzo > maxId)
                    {
                        maxId = i.IdIndirizzo;
                    }
                }
                item.IdIndirizzo = maxId + 1;
            }

            Indirizzi.Add(item);
            return item;
        }

        public List<Indirizzo> GetAll()
        {
            return Indirizzi;
        }
    }
}
