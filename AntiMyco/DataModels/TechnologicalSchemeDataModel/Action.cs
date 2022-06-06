using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Action
    {
        public Action()
        {
            ActionLists = new HashSet<ActionList>();
            ParameterValues = new HashSet<ParameterValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ActionList> ActionLists { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
