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
    public class ContactManager:IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void Update(Contact contact)
        {
           _contactDal.Update(contact);
        }

        public List<Contact> GetAll()
        {
           return _contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
           return _contactDal.GetById(x => x.ContactId == id);
        }
    }
}
