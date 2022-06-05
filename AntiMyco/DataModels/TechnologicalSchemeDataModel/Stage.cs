using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class Stage
    {
        public Stage()
        {
            InverseIdNextStageNavigation = new HashSet<Stage>();
            MaterialBalances = new HashSet<MaterialBalance>();
            ProductionSchemes = new HashSet<ProductionScheme>();
        }

        public int Id { get; set; }
        public int IdStartOperation { get; set; }
        public int? IdNextStage { get; set; }
        public string Name { get; set; } = null!;

        public virtual Stage? IdNextStageNavigation { get; set; }
        public virtual Operation IdStartOperationNavigation { get; set; } = null!;
        public virtual ICollection<Stage> InverseIdNextStageNavigation { get; set; }
        public virtual ICollection<MaterialBalance> MaterialBalances { get; set; }
        public virtual ICollection<ProductionScheme> ProductionSchemes { get; set; }
    }
}
