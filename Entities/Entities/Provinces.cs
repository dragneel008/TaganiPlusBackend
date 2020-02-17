using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Provinces
    {
        public Provinces()
        {
            Municipalities = new HashSet<Municipalities>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string MunicipalityJson { get; set; }

        public virtual Regions Region { get; set; }
        public virtual ICollection<Municipalities> Municipalities { get; set; }
    }
}
