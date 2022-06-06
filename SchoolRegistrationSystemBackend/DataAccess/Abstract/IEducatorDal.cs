using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Educator;

namespace DataAccess.Abstract
{
    public interface IEducatorDal:IEntityRepository<Educator>
    {
        List<OperationClaim> GetClaims(Educator educator);
    }
}
