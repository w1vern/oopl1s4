
using Decorator;

namespace Decorator
{
    public class Program
    {
        public static void Main()
        {
            IDate date = new AmericanDate();
            date = new FirstPartDecorator(date, "\naboba1\n");
            date = new LastPartDecorator(date, "\naboba2\n");
            date = new EuropeDate();
            Console.WriteLine(date.method());
        }
    }
}
