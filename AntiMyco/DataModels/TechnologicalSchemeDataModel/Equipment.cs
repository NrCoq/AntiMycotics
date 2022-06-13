using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentInvolvedInOperations = new HashSet<EquipmentInvolvedInOperation>();
            EquipmentParameters = new HashSet<EquipmentParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? AdditionalSpecifications { get; set; }
        public byte[]? Macro { get; set; }

        public virtual ICollection<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; }
        public virtual ICollection<EquipmentParameter> EquipmentParameters { get; set; }
    }
}
