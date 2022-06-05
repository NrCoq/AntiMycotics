using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Action
    {
        public Action()
        {
            InverseIdNextActionNavigation = new HashSet<Action>();
            Operations = new HashSet<Operation>();
            ParameterValues = new HashSet<ParameterValue>();
        }

        public int Id { get; set; }
        public int? IdNextAction { get; set; }
        public string Name { get; set; } = null!;

        public virtual Action? IdNextActionNavigation { get; set; }
        public virtual ICollection<Action> InverseIdNextActionNavigation { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
