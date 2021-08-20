using System;
using WeekOpdrachtDependencyInjection.Business.Interfaces;

namespace WeekOpdrachtDependencyInjection.Business
{
    public class CalculatePiService : ICalculatePiService
    {
        public double Add(int number)
        {
            return Math.PI + number;
        }

        public double Minus(int number)
        {
            return Math.PI - number;
        }
    }
}
