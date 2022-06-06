using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<List<Deparment>> GetList();

        IDataResult<Deparment> GetById(int id);

        IResult Update(Deparment deparment);

        IResult Delete(Deparment deparment);
    }
}
