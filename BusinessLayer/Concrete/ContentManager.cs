﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContentManager:IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public Content GetById(int id)
        {
           return _contentDal.GetById(x => x.ContentId == id);
        }
    }
}
