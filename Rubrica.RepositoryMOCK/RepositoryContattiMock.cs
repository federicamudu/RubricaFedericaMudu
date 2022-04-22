using Rubrica.Core.Entities;
using Rubrica.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMOCK
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        public static List<Contatto> contatti = new List<Contatto>()
        {
             new Contatto {ID=1, Nome = "Federica", Cognome = "Mudu"},
             new Contatto {ID=2, Nome = "Paola", Cognome = "Ruggero"},
             new Contatto {ID=3, Nome = "Pinco", Cognome = "Pallino"}
        };

        public Contatto Add(Contatto item)
        {
            if (contatti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var c in contatti)
                {
                    if (c.ID > maxId)
                    {
                        maxId = c.ID;
                    }
                }
                item.ID = maxId + 1;
            }
            contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            contatti.Remove(item);
            return true;
        }

        public List<Contatto> GetAll()
        {
            return contatti;
        }

        public Contatto GetById(int id)
        {
            foreach (var item in contatti)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
