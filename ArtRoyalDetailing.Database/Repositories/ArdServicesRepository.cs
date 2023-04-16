using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class ArdServicesRepository : IBaseRepository<Services>
    {
        private readonly ArdContext _db;

        public ArdServicesRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<Services> GetAll()
        {
            return _db.Services;
        }

        public async Task Delete(Services entity)
        {
            _db.Services.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(Services entity)
        {
            await _db.Services.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Services> Update(Services entity)
        {
            _db.Services.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
