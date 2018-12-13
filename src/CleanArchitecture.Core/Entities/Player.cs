using System.Collections.Generic;
using Hogstorp.Core.SharedKernel;

namespace Hogstorp.Core.Entities
{
    public class Player : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public virtual ICollection<PlayerTraining> PlayerTrainings{ get; set; }
    }
}
