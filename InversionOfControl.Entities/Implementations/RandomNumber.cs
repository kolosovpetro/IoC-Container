using System;
using InversionOfControl.Entities.Interfaces;

namespace InversionOfControl.Entities.Implementations;

public class RandomNumber : IRandomNumber
{
    private readonly int _randomNumber;

    public RandomNumber()
    {
        var random = new Random();
        _randomNumber = random.Next();
    }

    public int GetRandomNumber()
    {
        return _randomNumber;
    }
}