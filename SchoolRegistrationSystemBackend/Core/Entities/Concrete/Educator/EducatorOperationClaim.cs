using System;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete.Educator
{
    public class EducatorOperationClaim:IEntity
    {
        public int educatorOperationClaimId { get; set; }

        public int educatorId { get; set; }

        public int operationClaimId { get; set; }
    }
}
