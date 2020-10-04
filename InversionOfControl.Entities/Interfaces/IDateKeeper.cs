using System;

namespace InversionOfControl.Entities.Interfaces
{
    public interface IDateKeeper
    {
        DateTime CurrentDate { get; }
    }
}