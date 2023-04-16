using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class RoleRepository : IBaseRepository<Roles>
    {
        private readonly ArdContext _db;

        public RoleRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<Roles> GetAll()
        {
            return _db.Roles;
        }

        public async Task Delete(Roles entity)
        {
            _db.Roles.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(Roles entity)
        {
            await _db.Roles.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Roles> Update(Roles entity)
        {
            _db.Roles.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
