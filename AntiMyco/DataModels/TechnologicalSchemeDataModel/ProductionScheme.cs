using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class ProductionScheme
    {
        public ProductionScheme()
        {
            StageLists = new HashSet<StageList>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<StageList> StageLists { get; set; }
    }
}
