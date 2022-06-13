using System;
using System.Collections.Generic;

namespace Hostel.Domain.Entities
{
    public partial class Floor
    {
        public Floor()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FloorNumber { get; set; }
        public int HostelId { get; set; }

        public virtual Hostel Hostel { get; set; } = null!;
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
