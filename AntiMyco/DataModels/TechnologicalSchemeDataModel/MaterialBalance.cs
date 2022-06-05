using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class MaterialBalance
    {
        public int IdSubstance { get; set; }
        public int IdClass { get; set; }
        public int IdStage { get; set; }
        public float? ChanfeG { get; set; }
        public float? ChangeMl { get; set; }

        public virtual SubstanceClass IdClassNavigation { get; set; } = null!;
        public virtual Stage IdStageNavigation { get; set; } = null!;
        public virtual Substance IdSubstanceNavigation { get; set; } = null!;
    }
}
