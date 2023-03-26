using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class UserRepository : IBaseRepository<Users>
    {
        private readonly ArdContext _db;

        public UserRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<Users> GetAll()
        {
            return _db.Users;
        }

        public async Task Delete(Users entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(Users entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Users> Update(Users entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
