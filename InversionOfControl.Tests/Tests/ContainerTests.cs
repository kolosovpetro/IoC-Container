using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Enums;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;
using ILogger = InversionOfControl.Entities.Interfaces.ILogger;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void Container_Register_Singleton_Test()
        {
            IContainer container = new Container();
            container.RegisterSingleton<ILogger, Logger>();
            
            var service = container.GetService<ILogger>();
            service.Contract.Should().Be(typeof(ILogger));
            service.Implementation.Should().Be(typeof(Logger));
            service.LifeTime.Should().Be(LifeTime.Singleton);
            
            var logger = (ILogger) service.Instance;
            logger.Log("test").Should().Be("This logger inserted new entry: test");
        }
        
        [Test]
        public void Container_Register_Transient_Test()
        {
            IContainer container = new Container();
            container.RegisterTransient<ILogger, Logger>();
            
            var service = container.GetService<ILogger>();
            service.Contract.Should().Be(typeof(ILogger));
            service.Implementation.Should().Be(typeof(Logger));
            service.LifeTime.Should().Be(LifeTime.Transient);
            
            var logger = (ILogger) service.Instance;
            logger.Log("test").Should().Be("This logger inserted new entry: test");
        }

        [Test]
        public void Container_Register_Singleton_Instance_Test()
        {
            
        }
        
        [Test]
        public void Container_Register_Transient_Instance_Test()
        {
            
        }
    }
}