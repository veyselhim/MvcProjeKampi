﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        void Add(Contact contact);

        void Delete(Contact contact);

        void Update(Contact contact);

        List<Contact> GetAll();

        Contact GetById(int id);
    }
}
