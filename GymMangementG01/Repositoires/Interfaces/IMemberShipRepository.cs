using GymMangementG01.Entities;
using System.Linq.Expressions;

namespace GymMangementG01.Repositoires.Interfaces
{
    public interface IMemberShipRepository
    {
        Task<bool> AnyAsync(Expression<Func<MemberShip, bool>> predicate , CancellationToken ct= default);
    }
}
