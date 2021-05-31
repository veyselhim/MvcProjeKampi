using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class AdminStaticsManager:IAdminStaticsService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IHeadingDal _headingDal;
        private readonly IWriterDal _writerDal;

        public AdminStaticsManager(ICategoryDal categoryDal, IHeadingDal headingDal, IWriterDal writerDal)
        {
            _categoryDal = categoryDal;
            _headingDal = headingDal;
            _writerDal = writerDal;
        }

        public int GetCategoryCount()
        {
           return _categoryDal.GetAll().Count();
        }

        public int GetSoftwareHeadingCount()
        {
            return _headingDal.Get(x => x.CategoryId == 16).Count();

        }

        public int GetWriterCountWhereLetterA()
        {
            var count = _writerDal.Get(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();

            return count;
        }

        public string GetMostTitlesCategoryName()
        {
           var count = _categoryDal.GetAll().Where(x => x.CategoryId == (_headingDal.GetAll().GroupBy(h => h.CategoryId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
           return count;
        }

        public int GetCategoryStatusDifference()
        {
            return CategoryStatusDifference();
        }



        private int CategoryStatusDifference()
        {
            var trueCount = _categoryDal.GetAll().Count(x => x.CategoryStatus);
            var falseCount = _categoryDal.GetAll().Count(x => x.CategoryStatus == false);

            int result = trueCount - falseCount;
            return result;
        }
    }
}
