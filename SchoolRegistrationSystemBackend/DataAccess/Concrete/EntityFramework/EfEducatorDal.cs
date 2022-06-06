using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Educator;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEducatorDal : EfEntityRepositoryBase<Educator, Context>, IEducatorDal
    {
        public List<OperationClaim> GetClaims(Educator educator)
        {
            using (var context = new Context())
            {
                var result = from operationClaim in context.OperationClaims
                             join educatorOperationClaim in context.EducatorOperationClaims

                             on operationClaim.id equals educatorOperationClaim.operationClaimId
                             //where educatorOperationClaim.educatorId == educator.educatorId
                             select new OperationClaim { id = operationClaim.id, name = operationClaim.name };
                return result.ToList();
            }
        }
        public override void Add(Educator educator)
        {
            using (var context = new Context())
            {
                var currentDepartment = context.Deparment.AsNoTracking().SingleOrDefault(e => e.deparmentId == educator.deparmentId);

                var addedEducator = new Educator
                {
                    email = educator.email,
                    firstname = educator.firstname,
                    lastname = educator.lastname,
                    passwordHash = educator.passwordHash,
                    passwordSalt = educator.passwordSalt,
                    educatorStatus = true,
                    title = "Educator",
                    deparmentId = educator.deparmentId,
                    deparment = currentDepartment.deparmentName,
                    phoneNumber = educator.phoneNumber,
                    educatorNumber = educator.educatorNumber,
                    username = educator.username
                };
                var entity = context.Entry(addedEducator);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
