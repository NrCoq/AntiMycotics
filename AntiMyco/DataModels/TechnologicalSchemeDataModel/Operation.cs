using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Operation
    {
        public Operation()
        {
            ActionLists = new HashSet<ActionList>();
            EquipmentInvolvedInOperations = new HashSet<EquipmentInvolvedInOperation>();
            OperationLists = new HashSet<OperationList>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ActionList> ActionLists { get; set; }
        public virtual ICollection<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; }
        public virtual ICollection<OperationList> OperationLists { get; set; }
    }
}
