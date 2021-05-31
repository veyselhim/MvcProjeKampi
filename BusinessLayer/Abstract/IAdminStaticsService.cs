using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminStaticsService
    {
        int GetCategoryCount();

        int GetSoftwareHeadingCount();

        int GetWriterCountWhereLetterA();

        string GetMostTitlesCategoryName();

        int GetCategoryStatusDifference();
    }
}
