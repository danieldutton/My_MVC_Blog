using System.Configuration;
using DansBlog.DataAccess;
using DansBlog.DataAccess.Interfaces;
using DansBlog.Model.Domain;
using DansBlog.Presentation.Mappers;
using DansBlog.Repository;
using DansBlog.Repository.Interfaces;
using DansBlog.Services.Archiving;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.Utilities;
using DansBlog.Services.Email;
using DansBlog.Services.Email.Interfaces;
using DansBlog.Services.Email.Model;
using DansBlog.Utilities.DateTimes;
using DansBlog.Utilities.Interfaces;
using DansBlog.Utilities.Numbers;
using DansBlog.Utilities.Xml;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DansBlog.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DansBlog.App_Start.NinjectWebCommon), "Stop")]

namespace DansBlog.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IViewMapper>().To<ViewMapper>();

            //Time
            kernel.Bind<ICurrentDateTime>().To<CurrentTimeHelper>();
            kernel.Bind<IQuoteRepository<Quote>>().To<QuoteRepository>();
            kernel.Bind<IRandomNumberGenerator>().To<RandomNumberGenerator>();
            kernel.Bind<IXDocumentLoader>().To<XDocumentLoader>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            //Archiver
            kernel.Bind<IArchiver>().To<Archiver>();
            kernel.Bind<IDistinctMonthHelper>().To<DistinctMonthHelper>();
            kernel.Bind<IArchiveMapper>().To<ArchiveMapper>();
            //Data Context
            kernel.Bind<IDbContext>().To<BlogDbContext>();

            string smtpServer = ConfigurationManager.AppSettings["Smtp_Server"];
            string targetEmail = ConfigurationManager.AppSettings["Smtp_TargetEmail"];

            var emailSettings = new EmailSettings(smtpServer, targetEmail);

            kernel.Bind<IEmailer>()
                          .To<Emailer>()
                          .WithConstructorArgument("emailSettings", emailSettings);
        }        
    }
}
