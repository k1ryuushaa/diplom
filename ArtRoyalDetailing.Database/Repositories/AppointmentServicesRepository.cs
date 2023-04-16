using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class AppointmentServicesRepository : IBaseRepository<ContractsServices>
    {
        private readonly ArdContext _db;

        public AppointmentServicesRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<ContractsServices> GetAll()
        {
            return _db.ContractsServices.Include(x=>x.IdContractNavigation).Include(x => x.IdServiceNavigation).Include(x => x.IdWasherNavigation);
        }

        public async Task Delete(ContractsServices entity)
        {
            _db.ContractsServices.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(ContractsServices entity)
        {
            await _db.ContractsServices.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ContractsServices> Update(ContractsServices entity)
        {
            _db.ContractsServices.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
