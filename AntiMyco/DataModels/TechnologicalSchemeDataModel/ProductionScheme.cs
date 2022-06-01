using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class ProductionScheme
    {
        public int Id { get; set; }
        public int IdStartSstage { get; set; }
        public string Name { get; set; } = null!;
        public string? ProductPurpose { get; set; }
        public string? PharmacologicalProperties { get; set; }
        public string? DescriptionProperties { get; set; }

        public virtual Stage IdStartSstageNavigation { get; set; } = null!;
    }
}
