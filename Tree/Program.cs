namespace Tree
{
    public class Program
    {
        public static void Main()
        {
            Tree tree = new Tree(10);
            var tmp = new Tree(20);
            tmp.addChild(new Tree(40));
            tmp.addChild(new Tree(40));
            tmp.addChild(new Tree(40));
            tmp.addChild(new Tree(40));
            tree.addChild(tmp);
            tree.addChild(new Tree(30));
            Console.WriteLine(tree);
        }
    }
}