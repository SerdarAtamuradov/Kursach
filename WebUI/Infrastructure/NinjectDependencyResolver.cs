using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            /*Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { Name = "Язык программиования C# 5.0 и платформа .NET 4.5", Author = "Троелсен Э.", Price = 50},
                new Book { Name = "C# и платформа .NET 4.5 для профессионалов", Author = "Карли Уотсон и др.", Price = 55},
                new Book { Name = "Асинхронное программиование в C# 5.0", Author = "Дэвис А.", Price = 38},
            });*/
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}