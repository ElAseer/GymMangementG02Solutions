using GymMangementG01.Entities;

namespace GymMangementG01.Repositoires.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct=default);

        Task<Plan?> GetPlanByIdAsync(int  id,CancellationToken ct=default);

        Task<int> UpdateAsync (CancellationToken ct);
    }
}
