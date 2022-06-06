using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Deparment:IEntity
    {
        public int deparmentId { get; set; }

        public string deparmentName { get; set; }
    }
}
