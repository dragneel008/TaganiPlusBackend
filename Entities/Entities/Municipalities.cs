using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Municipalities
    {
        public Municipalities()
        {
            Barangays = new HashSet<Barangays>();
        }

        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public string BarangayJson { get; set; }

        public virtual Provinces Province { get; set; }
        public virtual ICollection<Barangays> Barangays { get; set; }
    }
}
