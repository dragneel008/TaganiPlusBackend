using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Barangays
    {
        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        public string Name { get; set; }

        public virtual Municipalities Municipality { get; set; }
    }
}
