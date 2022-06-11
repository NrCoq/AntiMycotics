using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class ProductionScheme
    {
        public ProductionScheme()
        {
            Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Stage> Stages { get; set; }
    }
}
