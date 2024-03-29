using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class FirstPartDecorator : Decorator
    {
        private string _str;
        public FirstPartDecorator(IDate date, string str) : base(date)
        {
            _str = str;
        }

        public override string method()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_str);
            sb.Append(this.date.method());
            return sb.ToString();
        }
    }
}
