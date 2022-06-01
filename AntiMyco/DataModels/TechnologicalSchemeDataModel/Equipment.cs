using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentInvolvedInActions = new HashSet<EquipmentInvolvedInAction>();
            EquipmentInvolvedInOperations = new HashSet<EquipmentInvolvedInOperation>();
            EquipmentInvolvedInStages = new HashSet<EquipmentInvolvedInStage>();
            EquipmentParameters = new HashSet<EquipmentParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? AdditionalSpecifications { get; set; }

        public virtual ICollection<EquipmentInvolvedInAction> EquipmentInvolvedInActions { get; set; }
        public virtual ICollection<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; }
        public virtual ICollection<EquipmentInvolvedInStage> EquipmentInvolvedInStages { get; set; }
        public virtual ICollection<EquipmentParameter> EquipmentParameters { get; set; }
    }
}
