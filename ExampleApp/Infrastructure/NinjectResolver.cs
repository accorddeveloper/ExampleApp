using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using ExampleApp.Models;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Ninject.Web.Common;
using System.Linq;
using System.Web;

namespace ExampleApp.Infrastructure
{
    public class NinjectResolver : System.Web.Http.Dependencies.IDependencyResolver,
        System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this (new StandardKernel()) { }

        public NinjectResolver(IKernel ninjectKernel)
        {
            kernel = ninjectKernel;
            AddBindings(kernel);
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            // do nothing
        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
            kernel.Bind<IRepository>().To<Repository>().InRequestScope();
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            return kernel;
        }
    }
}