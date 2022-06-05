using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Substance
    {
        public Substance()
        {
            MaterialBalances = new HashSet<MaterialBalance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Indicator { get; set; }

        public virtual ICollection<MaterialBalance> MaterialBalances { get; set; }
    }
}
