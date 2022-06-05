using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Parameter
    {
        public Parameter()
        {
            EquipmentParameters = new HashSet<EquipmentParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Unit { get; set; }

        public virtual ICollection<EquipmentParameter> EquipmentParameters { get; set; }
    }
}
