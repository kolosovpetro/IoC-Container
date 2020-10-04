using System;
using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Exceptions;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests
{
    [TestFixture]
    public class TypeAlreadyRegisteredExceptionTest
    {
        [Test]
        public void Type_Already_Registered_Exception_Test()
        {
            IBuilder builder = new Builder();
            builder.AddSingleton<ILogger, Logger>();

            Action act = () => builder.AddSingleton<ILogger, object>();
            act.Should().Throw<TypeAlreadyRegisteredException>()
                .WithMessage($"Type {typeof(ILogger)} is already registered");

            Action act2 = () => builder.AddSingletonInstance<ILogger, object>(new object());
            act2.Should().Throw<TypeAlreadyRegisteredException>()
                .WithMessage($"Type {typeof(ILogger)} is already registered");
        }
    }
}