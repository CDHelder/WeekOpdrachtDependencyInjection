using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Core.Entities
{
    public class Chicken : Bird
    {
        public override string Sound()
        {
            return "Cluck";
        }
    }
}
