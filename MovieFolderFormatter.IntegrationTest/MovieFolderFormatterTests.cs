using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Autofac.Builder;
using System.Reflection;
using System;
using MovieFolderFormatter;

namespace MovieFolderFormatter.IntegrationTest
{
    [TestClass]
    public class MovieFolderFormatterTests
    {   
        private static readonly IMovieFolderFormatter Sut;
        static UnitTest1()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IMovieFolderFormatter).Assembly)
                .AsImplementedInterfaces();

            var container = builder.Build();

            Sut = container.Resolve<IMovieFolderFormatter>();
        }

        [TestMethod]
        public void Format_WithAnyTitle_ShouldNormalize()
        {
            // Arrange/Act.
            var actual = Sut.Format("Blade   Runner __  (1985) [abcde]");
        
            // Assert.
            Assert.AreEqual("Blade Runner [1985]", actual);
        }
    }
}
