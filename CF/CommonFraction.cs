using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF
{
    public class CommonFraction
    {
        private CommonFraction(uint num, uint den)
        {
            if (den == 0)
                throw new Exception("division by zero");
            _numerator = num;
            _denumerator = den;
            _sign = false;
            reduceFraction();
        }
        private CommonFraction(uint num, uint den, bool sign)
        {
            if (den == 0)
                throw new Exception("division by zero");
            _numerator = num;
            _denumerator = den;
            _sign = sign;
            reduceFraction();
        }
        public CommonFraction(int num, int den)
        {
            if (den == 0)
                throw new Exception("division by zero");
            _sign = (num < 0) ^ (den < 0);
            _numerator = (uint)Math.Abs(num);
            _denumerator = (uint)Math.Abs(den);
            reduceFraction();
        }

        public static bool operator ==(CommonFraction frac_1, CommonFraction frac_2)
        {
            return (frac_1._numerator == frac_2._numerator)
            && (frac_1._denumerator == frac_2._denumerator)
            && (frac_1._sign == frac_2._sign);
        }
        public static bool operator !=(CommonFraction frac_1, CommonFraction frac_2)
        {
            return !(frac_1 == frac_2);
        }
        public static bool operator >(CommonFraction frac_1, CommonFraction frac_2)
        {
            if (frac_1._sign != frac_2._sign)
                return frac_2._sign;
            uint nok = NOK(frac_2._denumerator, frac_1._denumerator);
            return (nok / frac_1._denumerator * frac_1._numerator > nok / frac_2._denumerator * frac_2._numerator);
        }
        public static bool operator <(CommonFraction frac_1, CommonFraction frac_2)
        {
            if (frac_1._sign != frac_2._sign)
                return frac_1._sign;
            uint nok = NOK(frac_2._denumerator, frac_1._denumerator);
            return (nok / frac_1._denumerator * frac_1._numerator < nok / frac_2._denumerator * frac_2._numerator);
        }
        public static bool operator >=(CommonFraction frac_1, CommonFraction frac_2)
        {
            return !(frac_1 < frac_2);
        }
        public static bool operator <=(CommonFraction frac_1, CommonFraction frac_2)
        {
            return !(frac_1 > frac_2);
        }

        public static CommonFraction operator -(CommonFraction frac)
        {
            return new CommonFraction(frac._numerator, frac._denumerator, !frac._sign);
        }
        public static CommonFraction operator +(CommonFraction frac_1, CommonFraction frac_2)
        {
            uint nok = NOK(frac_1._denumerator, frac_2._denumerator);
            uint term1 = frac_1._numerator * nok / frac_1._denumerator;
            int sterm1 = (1 - Convert.ToInt32(frac_1._sign) * 2) * (int)term1;
            uint term2 = frac_2._numerator * nok / frac_2._denumerator;
            int sterm2 = (1 - Convert.ToInt32(frac_2._sign) * 2) * (int)term2;
            return new CommonFraction((uint)Math.Abs(sterm1 + sterm2),
             nok,
             sterm1 + sterm2 < 0);
        }
        public static CommonFraction operator -(CommonFraction frac_1, CommonFraction frac_2)
        {
            return frac_1 + (-frac_2);
        }
        public static CommonFraction operator *(CommonFraction frac_1, CommonFraction frac_2)
        {
            return new CommonFraction(frac_1._numerator * frac_2._numerator, frac_1._denumerator * frac_2._denumerator, frac_1._sign ^ frac_2._sign);
        }
        public static CommonFraction operator /(CommonFraction frac_1, CommonFraction frac_2)
        {
            return frac_1 * (new CommonFraction(frac_2._denumerator, frac_2._numerator, frac_2._sign));
        }

        public static CommonFraction operator *(int k, CommonFraction frac)
        {
            return new CommonFraction(frac._numerator * (uint)k, frac._denumerator, (k < 0) ^ frac._sign);
        }

        public override string ToString()
        {
            if (_numerator == 0)
                return "0";
            uint sign = Convert.ToUInt32(_sign);
            uint sizeNum = (uint)Math.Log10(_numerator) + 1;
            uint sizeDen = (uint)Math.Log10(_denumerator) + 1;
            string result = "";
            if (_sign)
                result += '-';
            while (result.Length < sign + sizeNum)
                result += (char)(((_numerator / (int)Math.Pow(10, sizeNum + sign - result.Length - 1)) % 10) + 48);
            if (_denumerator == 1)
                return result;
            result += '/';
            while (result.Length < sign + sizeDen + sizeNum + 1)
                result += (char)(((_denumerator / (int)Math.Pow(10, sizeDen + sizeNum + sign - result.Length)) % 10) + 48);
            return result;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            return this == (CommonFraction)obj;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void reduceFraction()
        {
            uint nod = NOD(_numerator, _denumerator);
            _numerator /= nod;
            _denumerator /= nod;
        }
        private static uint NOD(uint num_1, uint num_2)
        {
            if (num_1 > num_2)
                swap(ref num_1, ref num_2);
            while (num_2 != 0)
            {
                num_1 %= num_2;
                swap(ref num_1, ref num_2);
            }
            return num_1;
        }
        private static uint NOK(uint num_1, uint num_2)
        {
            return num_1 * num_2 / NOD(num_1, num_2);
        }
        private static void swap(ref uint num_1, ref uint num_2)
        {
            uint tmp = num_1;
            num_1 = num_2;
            num_2 = tmp;
        }
        private uint _numerator;
        private uint _denumerator;
        private bool _sign;
    }
}
