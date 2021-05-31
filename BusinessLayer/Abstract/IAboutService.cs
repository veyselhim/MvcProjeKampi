using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        void Add(About about);

        void Delete(About about);

        void Update(About about);

        List<About> GetAll();

        About GetById(int id);
    }
}
