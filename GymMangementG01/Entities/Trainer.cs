using GymMangementG01.Entities.Enums;

namespace GymMangementG01.Entities
{
    public class Trainer:GymUser
    {
        public DateTime HireDate { get; set; }
        public Specialties Specialties { get; set; }


        //Relationship
        public ICollection<Session> Sessions { get; set; } = default!;
    }
}
