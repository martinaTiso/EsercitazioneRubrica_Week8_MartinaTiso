using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneRubrica.Core.InterfaceRepository
{
    public interface IRepository<T>
    {
        public IList<T> GetAll();
        public T Add(T item);
       
        public bool Delete(T item);
    }
}
