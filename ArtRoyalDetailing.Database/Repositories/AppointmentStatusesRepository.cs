using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class AppointmentStatusesRepository : IBaseRepository<ContractStatuses>
    {
        private readonly ArdContext _db;

        public AppointmentStatusesRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<ContractStatuses> GetAll()
        {
            return _db.ContractStatuses;
        }

        public async Task Delete(ContractStatuses entity)
        {
            _db.ContractStatuses.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(ContractStatuses entity)
        {
            await _db.ContractStatuses.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ContractStatuses> Update(ContractStatuses entity)
        {
            _db.ContractStatuses.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
