using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.Antimycotics
{
    public partial class Antimycotic
    {
        public Antimycotic()
        {
            Diseases = new HashSet<Disease>();
            Effects = new HashSet<SideEffect>();
        }

        public int Id { get; set; }
        public int PrecursorId { get; set; }
        public string? Name { get; set; }
        public string Smiles { get; set; } = null!;
        public decimal Toxicity { get; set; }
        public string Properties { get; set; } = null!;

        public virtual Precursor Precursor { get; set; } = null!;

        public virtual ICollection<Disease> Diseases { get; set; }
        public virtual ICollection<SideEffect> Effects { get; set; }
    }
}
