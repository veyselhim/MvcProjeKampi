using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategories()
        {
            var result = categoryManager.GetAll();

            return View(result);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Category category)
        {

            CategoryValidator categoryValidator =  new CategoryValidator();

            ValidationResult validationResults = categoryValidator.Validate(category);

            if (validationResults.IsValid)  // kurallardan geçerse ekleme işlemi yap.
            {
                categoryManager.Add(category);
                return RedirectToAction("GetCategories");
            }

            foreach (var result in validationResults.Errors)   // validationResultları gezdik.
            {
                ModelState.AddModelError(result.PropertyName , result.ErrorMessage); // property ismini ve error mesajı yazıldı.
            }


            return View(); // ekleme işlemini gerçekleştirdikten sonra sayfayı GetCategories'e yönlendir.

        }



    }
}