using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class SingletonInstanceTest
    {
        [Test]
        public void Singleton_Instance_Test()
        {
            IBuilder builder = new Builder();
            builder.AddSingleton<IDateKeeper, DateKeeper>();
            var container = builder.Build();
            var dateKeeper1 = container.GetInstance<IDateKeeper>();
            var dateKeeper2 = container.GetInstance<IDateKeeper>();
            dateKeeper1.CurrentDate.Should().Be(dateKeeper2.CurrentDate);
            ReferenceEquals(dateKeeper1, dateKeeper2).Should().BeTrue();

        }
    }
}