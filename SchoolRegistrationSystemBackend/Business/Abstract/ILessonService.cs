using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IDataResult<List<Lesson>> GetList();

        IResult Add(Lesson lesson);

        IResult Delete(Lesson lesson);

        IResult Update(Lesson lesson);
    }
}
