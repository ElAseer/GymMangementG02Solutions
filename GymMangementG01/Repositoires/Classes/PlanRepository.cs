using GymMangementG01.Contexts;
using GymMangementG01.Entities;
using GymMangementG01.Repositoires.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymMangementG01.Repositoires.Classes
{
    public class PlanRepository : IPlanRepository
    {
        //private GymDbContext dbContext = new GymDbContext();
        private GymDbContext _dbContext;
        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Plans.AsNoTracking().ToListAsync();
        }

        public async Task<Plan?> GetPlanByIdAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Plans.FindAsync([id], cancellationToken: ct);
        }

        public async Task<int> UpdateAsync(CancellationToken ct)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
