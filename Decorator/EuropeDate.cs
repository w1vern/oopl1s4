using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class EuropeDate : IDate
    {
        public string method()
        {
            return DateTime.Now.ToString(new CultureInfo("es-ES", false));
        }
    }
}
