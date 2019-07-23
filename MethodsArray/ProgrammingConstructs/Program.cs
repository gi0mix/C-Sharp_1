using System;

namespace ProgrammingConstructs
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleArray();
            Console.WriteLine();

            ArrayInitialization();
            Console.WriteLine();

            ImplicitArrayInitialization();
            Console.WriteLine();

            MixedTypeArray();
            Console.WriteLine();

            Console.WriteLine("******* METHOD AND PARAMETER MODIFIERS *******");
            Console.WriteLine("Add by the easiest way... 12 + 13 = {0}", Add(12, 13));
            Console.WriteLine();

            int b;
            AddWithOut(12, 13, out b);
            Console.WriteLine("Add by with void method and OUT keyword way... 12 + 13 = {0}", b);
            Console.WriteLine();

            //Swapping strings
            Console.WriteLine("Easy swap with ref kewyword");
            
            string s1 = "Flip", s2 = "Flop";
            Console.WriteLine("Before swap s1 = {0}, \ts2 = {1}", s1, s2);
            SwapStrings(ref s1, ref s2);
            Console.WriteLine("Before swap s1 = {0}, \ts2 = {1}", s1, s2);
            Console.WriteLine();


            //modifying the content by returning the reference
            Console.WriteLine("Sample REF return to changes the content");

            string[] sArr = { "uno", "due", "tre" };
            ref var refOutput = ref SampleRefReturn(sArr, 2);
            Console.WriteLine("Before changes \t{0} \t {1} \t {2}",sArr[0], sArr[1], sArr[2]);
            refOutput = "new";
            Console.WriteLine("After changes \t{0} \t {1} \t {2}",sArr[0], sArr[1], sArr[2]);
            Console.WriteLine();

            //Methods that use params arrays implicitly
            Console.WriteLine("Sample REF return to changes the content");
            double average = CalculateAverage(3.2, 4.5, 5.5, 22, 34.4, 62);
            Console.WriteLine(average);

        }

        static void SimpleArray()
        {
            Console.WriteLine("=> Simple Array creation");
            int[] myInt = new int[3];
            myInt[0] = 100;
            myInt[1] = 200;
            myInt[2] = 300;

            foreach (int i in myInt)
                Console.WriteLine(i);
            Console.WriteLine();
        }

        static void ArrayInitialization()
        {
            Console.WriteLine("=> Array Initialization");

            string[] stringArray = new string[] { "un", "no", "Ciao" };             // Array Initialization     WITH        new keyword 
            Console.WriteLine("stringArray has {0} elements", stringArray.Length);

            bool[] boolArray = { true, false, false };                              // Array Initialization     WITHOUT     new keyword and size
            Console.WriteLine("boolArray has {0} elements", boolArray.Length);

            int[] intArray = new int[4] { 10, 20, 30, 40 };                         // Array Initialization     WITH        new keyword and size
            Console.WriteLine("intArray has {0} elements", intArray.Length);
            
 
        }

        static void ImplicitArrayInitialization()
        {
            Console.WriteLine("=> Implict Array Declaration");

            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a is a: {0}", a.ToString());

            var b = new[] {1.5, 2, 2.5, 1};
            Console.WriteLine("b is a: {0}", b.ToString());

        }

        static void MixedTypeArray()
        {
            Console.WriteLine("=> Mixed Type Array Initialization");

            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form & Void";

            foreach (object obj in myObjects)
                Console.WriteLine("Type: {0}, \t val: {1}", obj.GetType(), obj);
        }

        static int Add(int x, int y) => x + y;

        static void AddWithOut(int x, int y, out int ans)
        {
            ans = x + y;
        }

        public static void SwapStrings(ref string str1, ref string str2)
        {
            string tempStr = str1;
            str1 = str2;
            str2 = tempStr;
        }

        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }

        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} data", values.Length);

            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }
    }
}
