using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager:IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public List<Writer> GetAll()
        {
           return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(x => x.WriterId == id);
        }
    }
}
