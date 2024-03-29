using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class LastPartDecorator : Decorator
    {
        private string _str;
        public LastPartDecorator(IDate date, string str) : base(date)
        {
            _str = str;
        }

        public override string method()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.date.method());
            sb.Append(_str);
            return sb.ToString();
        }
    }
}
