using System;

namespace GymWebApplication1.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public Trainer Trainer { get; set; }
    }
}
