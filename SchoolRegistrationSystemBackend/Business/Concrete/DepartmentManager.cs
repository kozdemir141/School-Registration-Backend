using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDeparmentDal _departmentDal;

        public DepartmentManager(IDeparmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public IResult Delete(Deparment deparment)
        {
            _departmentDal.Delete(deparment);
            return new SuccessResult();
        }

        public IDataResult<Deparment> GetById(int id)
        {
            return new SuccessDataResult<Deparment>(_departmentDal.Get(d => d.deparmentId == id));
        }

        public IDataResult<List<Deparment>> GetList()
        {
            return new SuccessDataResult<List<Deparment>>(_departmentDal.GetList().ToList());
        }

        public IResult Update(Deparment deparment)
        {
            _departmentDal.Update(deparment);
            return new SuccessResult();
        }
    }
}
