using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Stage
    {
        public Stage()
        {
            MaterialBalances = new HashSet<MaterialBalance>();
            OperationLists = new HashSet<OperationList>();
            StageLists = new HashSet<StageList>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MaterialBalance> MaterialBalances { get; set; }
        public virtual ICollection<OperationList> OperationLists { get; set; }
        public virtual ICollection<StageList> StageLists { get; set; }
    }
}
