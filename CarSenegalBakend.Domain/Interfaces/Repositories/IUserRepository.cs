using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Interfaces.Repositories
{
    public interface IUserRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity);       
        public List<TEntity> GetAll();
        public TEntity GetById(int id);


    }
}
