using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class Operation
    {
        public Operation()
        {
            EquipmentInvolvedInOperations = new HashSet<EquipmentInvolvedInOperation>();
            InverseIdNextOperationNavigation = new HashSet<Operation>();
            Stages = new HashSet<Stage>();
            IdRawMaterials = new HashSet<RawMaterial>();
        }

        public int Id { get; set; }
        public int IdStartAction { get; set; }
        public int? IdNextOperation { get; set; }
        public string Name { get; set; } = null!;

        public virtual Operation? IdNextOperationNavigation { get; set; }
        public virtual Action IdStartActionNavigation { get; set; } = null!;
        public virtual ICollection<EquipmentInvolvedInOperation> EquipmentInvolvedInOperations { get; set; }
        public virtual ICollection<Operation> InverseIdNextOperationNavigation { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }

        public virtual ICollection<RawMaterial> IdRawMaterials { get; set; }
    }
}
