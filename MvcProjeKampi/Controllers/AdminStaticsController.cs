using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class AdminStaticsController : Controller
    {
        private readonly IAdminStaticsService _adminStaticsService;

        public AdminStaticsController(IAdminStaticsService adminStaticsService)
        {
            _adminStaticsService = adminStaticsService;
        }


        public ActionResult GetCategories()
        {
            ViewBag.categoryCount = _adminStaticsService.GetCategoryCount();

            ViewBag.softwareCount = _adminStaticsService.GetSoftwareHeadingCount();

            ViewBag.mostTitlesCategoryName = _adminStaticsService.GetMostTitlesCategoryName();

            ViewBag.categoryStatusDiffrent = _adminStaticsService.GetCategoryStatusDifference();

            ViewBag.writerLetter = _adminStaticsService.GetWriterCountWhereLetterA();

            return View();
        }

    }
}