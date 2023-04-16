using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class WorkersShedulerRepository : IBaseRepository<WorkersSheduler>
    {
        private readonly ArdContext _db;

        public WorkersShedulerRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<WorkersSheduler> GetAll()
        {
            return _db.WorkersSheduler;
        }

        public async Task Delete(WorkersSheduler entity)
        {
            _db.WorkersSheduler.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(WorkersSheduler entity)
        {
            await _db.WorkersSheduler.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<WorkersSheduler> Update(WorkersSheduler entity)
        {
            _db.WorkersSheduler.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
