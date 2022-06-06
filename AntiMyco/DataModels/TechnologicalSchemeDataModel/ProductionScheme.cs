using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class ProductionScheme
    {
        public int Id { get; set; }
        public int IdStartSstage { get; set; }
        public string Name { get; set; } = null!;

        public virtual Stage IdStartSstageNavigation { get; set; } = null!;
    }
}
