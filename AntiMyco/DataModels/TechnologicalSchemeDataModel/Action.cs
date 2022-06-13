using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Action
    {
        public Action()
        {
            ParameterValues = new HashSet<ParameterValue>();
        }

        public int? OrderNum { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrderInOperation { get; set; }

        public virtual Operation? OrderNumNavigation { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
