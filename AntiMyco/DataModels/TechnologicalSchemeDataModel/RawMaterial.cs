using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class RawMaterial
    {
        public RawMaterial()
        {
            IdOperations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameInNtd { get; set; }
        public string? SortOrVendorCode { get; set; }
        public string? IndicatorsForChecking { get; set; }

        public virtual ICollection<Operation> IdOperations { get; set; }
    }
}
