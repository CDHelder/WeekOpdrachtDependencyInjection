using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Business.Interfaces
{
    public interface ICalculatePiService
    {
        public double Add(int number);
        public double Minus(int number);
    }
}
