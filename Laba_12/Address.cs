namespace Laba_12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Address : City
    {
        protected string streetName;
        protected int numbHome;

        public Address()
        {

        }


        public Address(int desicion) : base(desicion)
        {
            switch (desicion)
            {
                case 1:
                    string[] arr = new string[] { "Мира", "Ленина", "Попова", "Бейкерстрит", "Пушкина" };
                    Random rnd = new Random();
                    streetName = arr[rnd.Next(0, 5)];
                    numbHome = rnd.Next(0, 90);
                    peopleCount = rnd.Next(5, 25);
                    break;
                case 2:
                    streetName = InputStr(2);
                    numbHome = (int)Input(6);
                    peopleCount = (int)Input(5);
                    break;
            }
        }


        public string Street
        {
            get
            {
                return streetName;
            }
            set
            {
                streetName = value;
            }
        }


        public int NumbHome
        {
            get
            {
                return numbHome;
            }
            set
            {
                if (value < 0)
                    numbHome = 0;
                else
                    numbHome = value;
            }
        }


        public override int BookCounter()
        {
            int temp = 0;
            Random rnd = new Random();
            double Library_Count = rnd.Next(1, 3);
            for (int i = 0; i < Library_Count; i++)
            {
                temp += rnd.Next(10, 800);
            }
            Console.WriteLine("Кол-во книг во всех библиотеках = " + temp);
            return temp;
        }


        public override int MenCounter()
        {
            Console.WriteLine("Население мужского пола = " + peopleCount * 37 / 100);
            return peopleCount * 37 / 100;
        }


        public override int GirlCounter()
        {
            Console.WriteLine("Население женского пола = " + peopleCount * 63 / 100);
            return peopleCount * 63 / 100;
        }


        public override void Print()
        {
            base.Print();
            Console.Write("Улица " + streetName);
            Console.WriteLine("  д. " + numbHome);
        }


        public override Place RandomInit()
        {
            Address temp = new Address(1);
            return temp;
        }


        public override string ToString()
        {
            return base.ToString() + " Адрес " + streetName + " " + numbHome;
        }
    }





