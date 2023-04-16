using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class ServiceTypesRepository : IBaseRepository<ServiceType>
    {
        private readonly ArdContext _db;

        public ServiceTypesRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<ServiceType> GetAll()
        {
            return _db.ServiceType;
        }

        public async Task Delete(ServiceType entity)
        {
            _db.ServiceType.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(ServiceType entity)
        {
            await _db.ServiceType.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ServiceType> Update(ServiceType entity)
        {
            _db.ServiceType.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
