using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        void Add(Content content);

        void Delete(Content content);

        void Update(Content content);

        List<Content> GetAll();

        Content GetById(int id);
    }
}
