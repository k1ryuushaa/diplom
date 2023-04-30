using ArtRoyalDetailing.Database.Interfaces;
using ArtRoyalDetailing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtRoyalDetailing.Database.Repositories
{
    public class SalaryRepository : IBaseRepository<Salary>
    {
        private readonly ArdContext _db;

        public SalaryRepository(ArdContext db)
        {
            _db = db;
        }

        public IQueryable<Salary> GetAll()
        {
            return _db.Salary;
        }

        public async Task Delete(Salary entity)
        {
            _db.Salary.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(Salary entity)
        {
            await _db.Salary.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Salary> Update(Salary entity)
        {
            _db.Salary.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
