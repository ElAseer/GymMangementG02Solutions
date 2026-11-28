using System.ComponentModel.DataAnnotations;

namespace GymMangementG01.Entities
{
    public class Plan:BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        [Range(1, 365, ErrorMessage = "Out of Duration Range")]
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        //Relationship
        public ICollection<MemberShip>? PlanSubscriptions { get; set; } = default!;
    }
}
