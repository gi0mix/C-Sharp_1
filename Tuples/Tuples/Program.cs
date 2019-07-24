using System;

namespace Tuples
{
    struct Point
    {
        public int X;
        public int Y;

        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        public (int XPos, int YPos) Deconstruct() => (X, Y);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** working with tuples ***");

            (string, int, string) values = ("a", 5, "c");
            var values2 = ("a", 5, "c");

            Console.WriteLine($"V1 : {values}, V2 : {values2}");

            (string theString, int theNum, string theString2) valueWithName = ("PrimoElem", 324, "SecondoElem");

            Console.WriteLine($"V3: {valueWithName} \n\naccesso ai valori \n\tval1: {valueWithName.theString} val2: {valueWithName.theNum} val3:{valueWithName.theString2}");

            //Tuple can also be the return values of a method
            Console.WriteLine($"\nValue of the method: \t{TupleAsReturn()}");

            Point p = new Point(7, 5);
            var pointValues = p.Deconstruct();
            Console.WriteLine($"X is: {pointValues.XPos}");
            Console.WriteLine($"Y is: {pointValues.YPos}");
        }

        static (int a, string b, bool c) TupleAsReturn()
        {
            return (9, "Enjoy this", true);
        }
    }
}
