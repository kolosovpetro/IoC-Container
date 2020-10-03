using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Enums;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class ContainerRegisterSingletonTest
    {
        [Test]
        public void Container_Register_Singleton_Test_Simple()
        {
            IContainer container = new Container();
            container.RegisterSingleton<ILogger, Logger>();
            
            var service = container.GetService<ILogger>();
            service.Contract.Should().Be(typeof(ILogger));
            service.Implementation.Should().Be(typeof(Logger));
            service.LifeTime.Should().Be(LifeTime.Singleton);

            var logger = service.GetInstance<ILogger>();
            logger.Log("test").Should().Be("This logger inserted new entry: test");
        }
        
        [Test]
        public void Container_Register_Singleton_Test()
        {
            IContainer container = new Container();
            container.RegisterSingleton<ILogger, Logger>();
            container.RegisterSingleton<ILoggerService, LoggerService>();
            var service = container.GetService<ILoggerService>();
            service.LifeTime.Should().Be(LifeTime.Singleton);
            
            
            var loggerService = service.GetInstance<ILoggerService>();
            loggerService.LogMessage("test").Should().Be("This logger inserted new entry: test");
        }
    }
}