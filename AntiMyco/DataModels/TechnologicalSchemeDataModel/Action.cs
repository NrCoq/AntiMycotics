using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class Action
    {
        public Action()
        {
            EquipmentInvolvedInActions = new HashSet<EquipmentInvolvedInAction>();
            InverseIdNextActionNavigation = new HashSet<Action>();
            Operations = new HashSet<Operation>();
            ParameterValues = new HashSet<ParameterValue>();
        }

        public int Id { get; set; }
        public int? IdNextAction { get; set; }
        public string Name { get; set; } = null!;

        public virtual Action? IdNextActionNavigation { get; set; }
        public virtual ICollection<EquipmentInvolvedInAction> EquipmentInvolvedInActions { get; set; }
        public virtual ICollection<Action> InverseIdNextActionNavigation { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
