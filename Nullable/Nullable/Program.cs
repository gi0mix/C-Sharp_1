using System;

namespace Nullable
{
    class DatabaseReader
    {
        //Nullable data field
        public int? numericValue = null;
        public bool? boolValue = true;

        public int? GetIntFromDB()
        {
            return numericValue;
        }

        public bool? GetBoolFromDB()
        {
            return boolValue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //"Value types" canno be set to Null
            //   bool MyBool = null;
            //   int myInt = null;
            //This trigger a Compilation ERROR
            string myString = null; //That's legal, 'cause strings is a "Reference Type"

            Console.WriteLine("***** Try Nullable Prints *****");
            DatabaseReader DB = new DatabaseReader();

            int? i = DB.GetIntFromDB();

            if (i.HasValue)
                Console.WriteLine("Value of i: {0}", i.Value);
            else
                Console.WriteLine("Value of i is undefined");

            bool? b = DB.GetBoolFromDB();
            if (b != null)
                Console.WriteLine("Value of b is {0}", b.Value);
            else
                Console.WriteLine("Value is Undefined");

            int myData = DB.GetIntFromDB() ?? 100;
            Console.WriteLine($"MyData value: {myData}");

            TesterMethod(null);
        }

        static void LocalNullableVariables()
        {
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullables = new int?[10];
        }

        static void TesterMethod(string[] args) => Console.WriteLine($"You sent me {args?.Length ?? 0} arguments");
    }
}
