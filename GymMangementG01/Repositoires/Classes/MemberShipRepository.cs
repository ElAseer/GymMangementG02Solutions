using GymMangementG01.Contexts;
using GymMangementG01.Entities;
using GymMangementG01.Repositoires.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymMangementG01.Repositoires.Classes
{
    public class MemberShipRepository : IMemberShipRepository
    {
        private readonly GymDbContext _dbContext;

        public MemberShipRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AnyAsync(Expression<Func<MemberShip, bool>> predicate, CancellationToken ct = default)
        {
           return await _dbContext.Memberships.AnyAsync(predicate, ct);
        }
    }
}
