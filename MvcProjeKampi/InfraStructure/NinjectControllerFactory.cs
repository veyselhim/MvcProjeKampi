using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Ninject;

namespace MvcProjeKampi.InfraStructure
{
    public class NinjectControllerFactory : DefaultControllerFactory    
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal" ,new EfCategoryDal());
            _ninjectKernel.Bind<IAdminStaticsService>().To<AdminStaticsManager>()
                .WithConstructorArgument("categoryDal", new EfCategoryDal())
                .WithConstructorArgument("headingDal", new EfHeadingDal())
                .WithConstructorArgument("writerDal", new EfWriterDal());

        }                                                                                                    

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null :(IController) _ninjectKernel.Get(controllerType);
        }
    }
}