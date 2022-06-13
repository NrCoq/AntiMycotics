using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Operation
    {
        public Operation()
        {
            Actions = new HashSet<Action>();
            EquipmentInvolvedInOperations = new HashSet<EquipmentInvolvedInOperation>();
        }

        public int? IdStage { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrderInStage { get; set; }

        public virtual Stage? IdStageNavigation { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; }
    }
}
