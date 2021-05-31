using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        void Add(Heading heading);

        void Delete(Heading heading);

        void Update(Heading heading);

        List<Heading> GetAll();

        Heading GetById(int id);
    }
}
