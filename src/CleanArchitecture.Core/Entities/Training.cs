using System;
using System.Collections.Generic;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Training : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool Indoors { get; set; }
        public string Location { get; set; }
        public virtual ICollection<PlayerTraining> PlayersTrainings { get; set; }

    }
}
