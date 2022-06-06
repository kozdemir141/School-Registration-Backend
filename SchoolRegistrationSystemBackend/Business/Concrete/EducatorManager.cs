using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Educator;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class EducatorManager:IEducatorService
    {
        IEducatorDal _educatorDal;

        public EducatorManager(IEducatorDal educatorDal)
        {
            _educatorDal = educatorDal;
        }

        public void Add(Educator educator)
        {
            _educatorDal.Add(educator);
        }

        public void Delete(Educator educator)
        {
            _educatorDal.Delete(educator);
        }

        public Educator GetByMail(string email)
        {
            return _educatorDal.Get(e => e.email == email);
        }

        public Educator GetByUsername(string username)
        {
            return _educatorDal.Get(e => e.username == username);
        }

        public List<OperationClaim> GetClaims(Educator educator)
        {
            return _educatorDal.GetClaims(educator);
        }

        public void Update(Educator educator)
        {
            _educatorDal.Update(educator);
        }
    }
}
