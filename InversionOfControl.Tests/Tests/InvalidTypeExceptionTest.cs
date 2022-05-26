using System;
using FluentAssertions;
using InversionOfControl.Entities.Implementations;
using InversionOfControl.Entities.Interfaces;
using InversionOfControl.Exceptions;
using InversionOfControl.Implementations;
using InversionOfControl.Interfaces;
using NUnit.Framework;

namespace InversionOfControl.Tests.Tests;

[TestFixture]
public class InvalidTypeExceptionTest
{
    [Test]
    public void Invalid_Type_Exception_Test()
    {
        IBuilder builder = new Builder();

        Action act1 = () => builder.AddSingleton<ILogger, string>();
        Action act2 = () => builder.AddTransient<ILogger, string>();

        act1.Should().Throw<InvalidTypeException>()
            .WithMessage($"Type {typeof(string)} is not {typeof(ILogger)}");

        act2.Should().Throw<InvalidTypeException>()
            .WithMessage($"Type {typeof(string)} is not {typeof(ILogger)}");
    }
}