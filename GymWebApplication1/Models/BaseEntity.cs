using System;
using System.ComponentModel;

namespace GymWebApplication1.Models
{
    public class BaseEntity
    {
        [DisplayName("Created by")]

        public String CreatedBy { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Updated by")]
        public String UpdatedBy { get; set; }
        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }


    }
}
