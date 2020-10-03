using FluentAssertions;
using InversionOfControl.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ILogger = InversionOfControl.Entities.Interfaces.ILogger;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void Container_Test()
        {
            IContainer container = null;
            container.RegisterSingleton<ILogger, Logger>();
            var loggerService = container.GetService<ILogger>();
            var logger = loggerService.Resolve<ILogger>();
            logger.Log("test").Should().Be("This logger inserted new entry: test");
        }
    }
}