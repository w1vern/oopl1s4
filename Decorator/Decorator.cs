using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Decorator : IDate
    {
        protected IDate date;
       
        public Decorator(IDate date)
        {
            this.date = date;
        }
        public abstract string method();
    }
}
