using CarSenegalBackend.Infrastruture.Data;
using CarSenegalBakend.Domain.Common;
using CarSenegalBakend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBackend.Infrastruture.Repositories
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity:EntityBase
    {
        public readonly CarSenegalDbContext _context;
        public DbSet<TEntity> entity => _context.Set<TEntity>();
        public UserRepository(CarSenegalDbContext context)
        {
            context = _context;
        }

        public void Add(TEntity entity)
        {
            this.entity.Add(entity);
            _context.SaveChanges();
        }
        public List<TEntity> GetAll()
        {
            return this.entity.ToList();
        }

        public TEntity GetById(int id)
        {
            var entity = _context.Find<TEntity>(id);
            return entity;
        }

    }
}
