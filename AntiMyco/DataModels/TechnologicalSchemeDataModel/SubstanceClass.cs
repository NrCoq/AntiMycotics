using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class SubstanceClass
    {
        public SubstanceClass()
        {
            MaterialBalances = new HashSet<MaterialBalance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MaterialBalance> MaterialBalances { get; set; }
    }
}
