using System.Collections.Generic;

namespace GymWebApplication1.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerLastName { get; set; }
        public string TrainerAddress { get; set; }
        public string TrainerContact { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
