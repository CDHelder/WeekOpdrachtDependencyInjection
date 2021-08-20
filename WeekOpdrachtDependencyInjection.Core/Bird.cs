using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Core.Entities
{
    public abstract class Bird
    {
        public virtual string Sound()
        {
            return "Sound";
        }
    }
}
