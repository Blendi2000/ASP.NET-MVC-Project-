using System;

namespace GymWebApplication1.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime paidDate { get; set; }
        public DateTime dueDate { get; set; }
        public string Price { get; set; }
        public Membership Membership { get; set; }

    }
}
