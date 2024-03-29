namespace CF
{
    public class Program
    {
        public static void Main()
        {
            var frac1 = new CommonFraction(-1, 3);
            var frac2 = new CommonFraction(-1, 2);
            Console.WriteLine(frac1 - frac2);
        }
    }
}