using System;
using System.Collections.Generic;

namespace Hostel.Domain.Entities
{
    public partial class Hostel
    {
        public Hostel()
        {
            Floors = new HashSet<Floor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int NumberOfFloors { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
    }
}
