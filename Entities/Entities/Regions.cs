using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Regions
    {
        public Regions()
        {
            Provinces = new HashSet<Provinces>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProvinceJson { get; set; }

        public virtual ICollection<Provinces> Provinces { get; set; }
    }
}
