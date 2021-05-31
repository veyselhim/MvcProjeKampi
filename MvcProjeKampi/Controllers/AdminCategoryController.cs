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
    public class AdminCategoryController : Controller
    {
        private readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
       
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetAll();

            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResults = categoryValidator.Validate(category);


            if (validationResults.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("Index");
            }

            foreach (var item in validationResults.Errors)
            {
                    ModelState.AddModelError(item.PropertyName , item.ErrorMessage);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            categoryManager.Delete(categoryValue);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            return View(categoryValue);

        }


        [HttpPost]
        public ActionResult Update(Category category)
        {
            categoryManager.Update(category);

            return RedirectToAction("Index");

        }
    }
}