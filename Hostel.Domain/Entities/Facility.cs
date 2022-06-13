using System;
using System.Collections.Generic;

namespace Hostel.Domain.Entities
{
    public partial class Facility
    {
        public Facility()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public decimal Charges { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
