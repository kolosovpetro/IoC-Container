using System;
using InversionOfControl.Entities.Interfaces;

namespace InversionOfControl.Entities.Implementations
{
    public class DateKeeper : IDateKeeper
    {
        public DateTime CurrentDate => DateTime.Now;
    }
}