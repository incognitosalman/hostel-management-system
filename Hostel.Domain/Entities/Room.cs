using System;
using System.Collections.Generic;

namespace Hostel.Domain.Entities
{
    public partial class Room
    {
        public Room()
        {
            Facilities = new HashSet<Facility>();
        }

        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int FloorId { get; set; }

        public virtual Floor Floor { get; set; } = null!;

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
