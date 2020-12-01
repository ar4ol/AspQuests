using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.EF;

namespace WebApplication6.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id); 
        public void Create(T item);
        public void Update(T item);
        public void Delete(int id);        
    }
}
