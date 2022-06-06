using System;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete.Student
{
    public class StudentOperationClaim:IEntity
    {
        public int studentOperationClaimId { get; set; }

        public int studentId { get; set; }

        public int operationClaimId { get; set; }
    }
}
