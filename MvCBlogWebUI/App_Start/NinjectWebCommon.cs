using DansBlog.Model.Partials;
using DansBlog.Presentation.Mappers;
using DansBlog.Repository.Interfaces;
using DansBlog.Repository.Repositories;
using DansBlog.Services.Archiving;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.Utilities;
using DansBlog.Services.Email;
using DansBlog.Services.Email.Interfaces;
using DansBlog.Services.Email.Model;
using DansBlog.Utilities;
using DansBlog.Utilities.DateTimes;
using DansBlog.Utilities.Interfaces;
using System.Configuration;
using DansBlog.Utilities.Numbers;
using DansBlog.Utilities.Xml;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DansBlog.Presentation.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(DansBlog.Presentation.App_Start.NinjectWebCommon), "Stop")]

namespace DansBlog.Presentation.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
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
            kernel.Bind<ICurrentTime>().To<CurrentTimeHelper>();
            kernel.Bind<IQuoteRepository<Quote>>().To<QuoteRepository>();
            kernel.Bind<IRandomNumberGenerator>().To<RandomNumberGenerator>();
            kernel.Bind<IXmlLoader>().To<XmlLoader>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            //Archiver
            kernel.Bind<IArchiver>().To<Archiver>();
            kernel.Bind<IDistinctMonthHelper>().To<DistinctMonthHelper>();
            kernel.Bind<IArchiveMapper>().To<ArchiveMapper>();
            string smtpServer = ConfigurationManager.AppSettings["Smtp_Server"];
            string targetEmail = ConfigurationManager.AppSettings["Smtp_TargetEmail"];

            var emailSettings = new EmailSettings(smtpServer, targetEmail);

            kernel.Bind<IEmailer>()
                          .To<Emailer>()
                          .WithConstructorArgument("emailSettings", emailSettings);
        }        
    }
}
