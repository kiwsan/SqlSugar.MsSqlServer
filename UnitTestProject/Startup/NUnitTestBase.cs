using Autofac;
using Autofac.CrossCutting.IoC;
using AutoMapper.CrossCutting.Mapping;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Startup
{
    public class NUnitTestBase
    {

        protected IContainer _container;
        [SetUp]
        public void BaseSetUp()
        {

            _container = NativeInjectorBootStrapper.Registers();

            AutoMapperConfiguration.Init();

        } // Exception thrown!

        [TearDown]
        public void BaseTearDown()
        {

        }

    }
}
