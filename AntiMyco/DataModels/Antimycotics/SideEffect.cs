using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.Antimycotics
{
    public partial class SideEffect
    {
        public SideEffect()
        {
            Antimycotics = new HashSet<Antimycotic>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Antimycotic> Antimycotics { get; set; }
    }
}
