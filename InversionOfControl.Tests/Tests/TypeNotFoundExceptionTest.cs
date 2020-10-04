using System;
using FluentAssertions;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Exceptions;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class TypeNotFoundExceptionTest
    {
        [Test]
        public void Type_Not_Found_Exception_Test()
        {
            IBuilder builder = new Builder();
            var container = builder.Build();

            Action act = () => container.GetInstance<ILogger>();

            act.Should().Throw<TypeNotRegisteredException>()
                .WithMessage($"Type {typeof(ILogger)} is not registered");
        }
    }
}