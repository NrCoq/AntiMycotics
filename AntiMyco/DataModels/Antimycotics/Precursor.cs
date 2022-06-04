using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.Antimycotics
{
    public partial class Precursor
    {
        public Precursor()
        {
            Antimycotics = new HashSet<Antimycotic>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Smiles { get; set; } = null!;

        public virtual ICollection<Antimycotic> Antimycotics { get; set; }
    }
}
