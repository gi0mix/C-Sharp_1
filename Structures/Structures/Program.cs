using System;

namespace Structures
{
    enum EmpType
    {
        Manager,
        Grunt,
        Contractor,
        VicePresident
    }

    struct Point
    {
        public int x, y;

        //Custom Builder
        public Point(int XPos, int YPos)
        {
            x = XPos;
            y = YPos;
        }

        public void Increment()
        {
            x++; y++;
        }

        public void Decrement()
        {
            x--; y--;
        }

        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", x, y);
        }
    }

    class ShapeInfo
    {
        public string InfoString;
        public ShapeInfo(string info)
        {
            InfoString = info;
        }
    }

    struct Rectangle
    {
        public ShapeInfo RectInfo;
        public int RectTop, RectLeft, RectBottom, RectRight;
        
        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            RectInfo = new ShapeInfo(info);
            RectTop = top;  RectRight = right;
            RectLeft = left; RectBottom = bottom;
        }

        public void Display()
        {
            Console.WriteLine("String = {0}, \tTop = {1}, \tBottom = {2}, \tRight = {3}, \tLeft = {4}", RectInfo.InfoString, RectTop, RectBottom, RectRight, RectLeft);
        }
    }

    class Person
    {
        public string personName;
        public int personAge;

        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person() { }

        public void Display()
        {
            Console.WriteLine("Person \n\t Name: {0},\tAge: {1}", personName, personAge);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Practicing Enum ");
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            Console.WriteLine("Emp is a {0}", emp.ToString());

            //Scovare il valore di un certo membro di enum
            Console.WriteLine("{0} = {1}", emp.ToString(), (byte)emp);

            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;
            EmpType e2 = EmpType.Contractor;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.WriteLine("=> Structure exersices");
            Point myPoint;
                myPoint.x = 349;
                myPoint.y = 78;
            myPoint.Display();

            myPoint.Increment();
            myPoint.Display();

            Console.WriteLine("Settin up a new default point, with x = 0, y= 0");
            Point p2 = new Point();

            p2.Display();

            Console.WriteLine();
            Console.WriteLine("=> setting a Rectangle Struct with a reference to a class named ShapeInfo");

            Rectangle r1 = new Rectangle("First Rectangle", 12, 43, 12, 43);
            Console.WriteLine("Assigning r1 to r2");

            Rectangle r2 = r1;

            Console.WriteLine("\nChanging r2 values");
            r2.RectInfo.InfoString = ("That's a brand new info");
            r2.RectBottom = 18;

            Console.WriteLine("Printing both: \n");

            r1.Display();
            r2.Display();

            Console.WriteLine("**** Person Classes****\n");
            Person fred = new Person("Fred", 12);
            fred.Display();

            Console.WriteLine("\nPrima della modifica");
            SendAPersonByValue(fred);
            Console.WriteLine("Dopo la modifica");
            fred.Display();

            Console.WriteLine("\nUsando ref l'oggetto viene cambiato");
            Person mel = new Person("Mel", 32);
            Console.WriteLine("\nPrima della modifica");
            mel.Display();
            SendAPersonByValue(ref mel);
            mel.Display();
        }

        static void SendAPersonByValue(Person p)
        {
            p.personAge = 99;

            p = new Person("Nikki", 99); //Questa persona viene effettivamente creata, ma il suo riferimento non viene inviato indietro al metodo, mentre il campo del paramentro viene invece modificato
        }

        static void SendAPersonByValue(ref Person p)
        {
            p.personAge = 99;

            p = new Person("Rafael", 49);
        }

        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("No, manager");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("Not enough money");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("Must be joking");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("Sure, sir");
                    break;
            }
            Console.WriteLine();

        }

        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Info about {0}", e.GetType());
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members", enumData.Length);

            for(int i = 0; i < enumData.Length; i++)
                Console.WriteLine("Name: {0}, \t Value: {0:D}", enumData.GetValue(i));
            Console.WriteLine();
        }

    }
}
