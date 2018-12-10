using System.Collections;
using System.Collections.Generic;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Player : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public virtual ICollection<PlayerTraining> PlayerTrainings{ get; set; }
    }
}
