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
    public class AppointmentsRepository:IBaseRepository<Contracts>
    {
        private readonly ArdContext _db;

        public AppointmentsRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<Contracts> GetAll()
        {
            return _db.Contracts;
        }

        public async Task Delete(Contracts entity)
        {
            _db.Contracts.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(Contracts entity)
        {
            await _db.Contracts.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Contracts> Update(Contracts entity)
        {
            _db.Contracts.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
