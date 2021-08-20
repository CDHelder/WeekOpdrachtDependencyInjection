using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Core.Entities
{
    public class Duck : Bird
    {
        public override string Sound()
        {
            return "Quack";
        }
    }
}
