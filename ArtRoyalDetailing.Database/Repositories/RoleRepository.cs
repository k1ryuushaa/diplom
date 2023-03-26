using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    class RoleRepository : IBaseRepository<Roles>
    {
        private readonly ArdContext _db;

        public RoleRepository(ArdContext db)
        {
            _db = db;
        }
        public Task Create(Roles entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Roles entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Roles> GetAll()
        {
            return _db.Roles;
        }

        public Task<Roles> Update(Roles entity)
        {
            throw new NotImplementedException();
        }
    }
}
