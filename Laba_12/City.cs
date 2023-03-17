using System;
using System.Xml.Linq;

namespace Laba_12
{
    public class City : Place
    {
        protected int peopleCount;

        public City()
        {
        }


        public int PeopleCount
        {
            get
            {
                return peopleCount;
            }
            set
            {
                if (peopleCount < 0)
                    peopleCount = 0;
                else
                    peopleCount = value;
            }
        }


        public Place BasePlace
        {
            get
            {
                return new Place(name, Id);
            }
        }


        public City(int desicion)
        {
            switch (desicion)
            {
                case 1:
                    string[] arr = new string[] { "Пермь", "Казань", "Лиссабон", "Париж", "Рим", "Лос-Анджелес", "Рио-Де-Жанейро" };
                    Random rnd = new Random();
                    name = arr[rnd.Next(0, 7)];
                    id = rnd.Next(1, 20);
                    peopleCount = rnd.Next(150000, 15000000);
                    break;
                case 2:
                    name = InputStr(1);
                    id = (int)Input(4);
                    peopleCount = (int)Input(5);
                    break;
            }
        }


        public override int BookCounter()
        {
            int temp = 0;
            Random rnd = new Random();
            double Library_Count = rnd.Next(8, 20);
            for (int i = 0; i < Library_Count; i++)
            {
                temp += rnd.Next(970, 3750);
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


        public static City operator +(City city1, City city2)
        {
            City temp = new City();
            temp.peopleCount = city1.peopleCount + city2.peopleCount;
            return temp;
        }


        public void Show_People()
        {
            Console.Write("Население: ");
            Console.WriteLine(peopleCount);
        }


        public override void Print()
        {
            base.Print();
            Console.Write("Название города: ");
            Console.WriteLine(name);
            Console.Write("Количество жителей в городе = ");
            Console.WriteLine(peopleCount);

        }


        public override Place RandomInit()
        {
            City temp = new City(1);
            return temp;
        }
    }

}