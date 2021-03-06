[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SellBook.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SellBook.App_Start.NinjectWebCommon), "Stop")]

namespace SellBook.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using SellBook_Data;
    using SellBook_Services.Interfaces;
    using SellBook_Services;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Services.Interfaces;
    using Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISellbookDbContext>().To<SellBookDbContex>().InRequestScope();
            kernel.Bind<IdentityDbContext<ApplicationUser>>().To<SellBookDbContex>().InRequestScope();
            kernel.Bind<IPublicationService>().To<PublicationService>();
            kernel.Bind<IRegionService>().To<RegionService>();
            kernel.Bind<ICityService>().To<CityService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ISubCategoryService>().To<SubCategoryService>();
            kernel.Bind<IImageService>().To<ImageService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IWorkPublicationDetailService>().To<WorkPublicationDetailService>();
            kernel.Bind<ISubSubCategoryService>().To<SubSubCategoryService>();
            kernel.Bind<IFavouritePublicationService>().To<FavouritePublicationService>();
            kernel.Bind<IPublicationDetailsService>().To<PublicationDetailsService>();
            kernel.Bind<IChatService>().To<ChatService>();
            kernel.Bind<IPublicationModelService>().To<PublicationModelService>();
    //        kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
    //        kernel.Bind<UserManager<ApplicationUser>>().ToSelf();
    //        kernel.Bind<IAuthenticationManager>().ToMethod(
    //c =>
    //    HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
        }        
    }
}
