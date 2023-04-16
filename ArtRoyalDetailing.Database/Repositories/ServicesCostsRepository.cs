using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class ServicesCostsRepository : IBaseRepository<ServicesCosts>
    {
        private readonly ArdContext _db;

        public ServicesCostsRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<ServicesCosts> GetAll()
        {
            return _db.ServicesCosts;
        }

        public async Task Delete(ServicesCosts entity)
        {
            _db.ServicesCosts.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(ServicesCosts entity)
        {
            await _db.ServicesCosts.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ServicesCosts> Update(ServicesCosts entity)
        {
            _db.ServicesCosts.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
