using System;
using System.Xml.Linq;

namespace Laba_12
{
    public class Megapolis : City
    {

        protected double budjet;


        public Megapolis()
        {
        }


        public Megapolis(int decision)
        {
            switch (decision)
            {
                case 1:
                    string[] arr = new string[] { "Москва", "Абу-Даби", "Дубаи", "Нью-Йорк", "Вашингтон", "Бразилиа", "Берлин" };
                    Random rnd = new Random();
                    name = arr[rnd.Next(0, 7)];
                    id = rnd.Next(1, 20); ;
                    budjet = rnd.Next(1000000, 100000000);
                    break;
                case 2:
                    name = InputStr(1);
                    id = (int)Input(4);
                    budjet = Input(1);
                    break;
            }
        }


        public double Budjet
        {
            get { return budjet; }
            set { if (value > 0) budjet = value; }
        }


        public Place BasePlace
        {
            get
            {
                return new Place(name, Id);
            }
        }


        public override int BookCounter()
        {
            int temp = 0;
            Random rnd = new Random();
            double Library_Count = rnd.Next(15, 40);
            for (int i = 0; i < Library_Count; i++)
            {
                temp += rnd.Next(1125, 43750);
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
            Console.WriteLine("Название мегаполиса: " + name);
            Console.WriteLine("Бюджет: " + budjet);
        }


        public override Place RandomInit()
        {
            Megapolis temp = new Megapolis(1);
            return temp;
        }
    }
}

