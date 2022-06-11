using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Stage
    {
        public Stage()
        {
            MaterialBalances = new HashSet<MaterialBalance>();
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public int? IdScheme { get; set; }
        public string Name { get; set; } = null!;
        public int OrderInScheme { get; set; }

        public virtual ProductionScheme? IdSchemeNavigation { get; set; }
        public virtual ICollection<MaterialBalance> MaterialBalances { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
