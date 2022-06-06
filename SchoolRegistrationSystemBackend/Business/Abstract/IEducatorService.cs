using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Educator;

namespace Business.Abstract
{
    public interface IEducatorService
    {
        List<OperationClaim> GetClaims(Educator educator);

        Educator GetByMail(string email);

        Educator GetByUsername(string username);

        void Add(Educator educator);

        void Delete(Educator educator);

        void Update(Educator educator);
    }
}
