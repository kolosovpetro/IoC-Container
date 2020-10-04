using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class TransientInstanceTest
    {
        [Test]
        public void Transient_Instance_Test()
        {
            IBuilder builder = new Builder();
            builder.AddTransient<IRandomNumber, RandomNumber>();
            var container = builder.Build();
            var random1 = container.GetInstance<IRandomNumber>();
            var random2 = container.GetInstance<IRandomNumber>();
            random1.GetRandomNumber().Should().NotBe(random2.GetRandomNumber());
            ReferenceEquals(random1, random2).Should().BeFalse();
        }
    }
}