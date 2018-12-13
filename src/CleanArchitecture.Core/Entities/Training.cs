using System;
using System.Collections.Generic;
using Hogstorp.Core.SharedKernel;

namespace Hogstorp.Core.Entities
{
    public class Training : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool Indoors { get; set; }
        public string Location { get; set; }
        public virtual ICollection<PlayerTraining> PlayersTrainings { get; set; }

    }
}
