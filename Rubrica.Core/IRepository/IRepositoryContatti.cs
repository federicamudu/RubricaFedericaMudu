using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.IRepository
{
    public interface IRepositoryContatti : IRepository<Contatto>
    {
        public bool Delete(Contatto item);
        public Contatto GetById(int id);
    }
}
