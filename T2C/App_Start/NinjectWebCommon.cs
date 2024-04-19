using System;
using System.Web;
using CC.Core.Mapping;
using CC.Mapping.AutoMapper;
using CellService;
using DataPersistance.Core;
using DataPersistance.EntityFramework;
using DataPersistance.EntityFramework.Repositories;
using Domain.Core;
using Domain.T2C;
using Domain.T2C.Interface;
using Domain.T2C.Repository;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using T2C;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace T2C
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            //Domain
            kernel.Bind<ICell>().To<Cell>();
            kernel.Bind<IImagen>().To<Imagen>();
            kernel.Bind<IUser>().To<UserCell>();


            //Repositorio
            kernel.Bind(typeof(IRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<IContext>().To<CoreDbContext>();

            //Repositorio Celular
            kernel.Bind<ICellRepository>().To<CellRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>(); 
            kernel.Bind<IImagenRepository>().To<ImagenRepository>();

            //Servicio
            kernel.Bind(typeof(IMapper)).To(typeof(AutoMapperAdapter));

            //Servicio de la Agencia 
            kernel.Bind(typeof(IService)).To(typeof(Service));

        }        
    }
}
