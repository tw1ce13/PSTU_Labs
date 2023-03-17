using System;
using System.Xml.Linq;

namespace Laba_12
{
    public class Place : IComparable, IRandomInit, ICloneable
    {
        protected int id;
        public string name { get; set; }

        public Place()
        {
        }


        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    id = 0;
                else
                    id = value;
            }
        }


        public Place(string Name, int ID)
        {
            name = Name;
            id = ID;
        }


        public Place(int decision)
        {
            switch (decision)
            {
                case 1:
                    string[] arr = new string[] { "Букингемский дворец", "Диснейленд", "Биг-Бен", "Колизей", "Памуккале", "Лувр", "Манхэттен" };
                    Random rnd = new Random();
                    name = arr[rnd.Next(0, 7)];
                    id = rnd.Next(1, 100);
                    break;
                case 2:
                    name = InputStr(1);
                    id = (int)Input(4);
                    break;
            }
        }


        public string InputStr(int decision)
        {
            string value = "";
            switch (decision)
            {
                case 1:
                    while (value == "")
                    {
                        Console.WriteLine("Введите название: ");
                        value = Console.ReadLine();
                    }
                    break;
                case 2:
                    while (value == "")
                    {
                        Console.WriteLine("Введите название улицы: ");
                        value = Console.ReadLine();
                    }
                    break;
            }
            return value;
        }


        public double Input(int decision)
        {
            bool IsConverted = false;
            double value = 0;
            switch (decision)
            {
                case 1:
                    IsConverted = false;
                    while (!(IsConverted))
                    {
                        Console.Write("Введите бюджет мегаполиса >>> ");
                        IsConverted = double.TryParse(Console.ReadLine(), out value);
                    }
                    break;
                case 2:
                    IsConverted = false;
                    while (!(IsConverted))
                    {
                        value = 100;
                        while ((value < -90) || (value > 90))
                        {
                            Console.WriteLine("Введите широту {-90, 90} ");
                            IsConverted = double.TryParse(Console.ReadLine(), out value);
                        }
                    }
                    break;
                case 3:
                    IsConverted = false;
                    while (!(IsConverted))
                    {
                        value = 200;
                        while ((value < -180) || (value > 180))
                        {
                            Console.WriteLine("Введите долготу {-180, 180} ");
                            IsConverted = double.TryParse(Console.ReadLine(), out value);
                        }
                    }
                    break;
                case 4:
                    IsConverted = false;
                    while (!(IsConverted))
                    {
                        value = -1;
                        while (value < 0)
                        {
                            Console.WriteLine("Введите id > 0");
                            IsConverted = double.TryParse(Console.ReadLine(), out value);
                        }
                    }
                    break;
                case 5:
                    IsConverted = false;
                    while (!(IsConverted))
                    {
                        value = -1;
                        while (value < 0)
                        {
                            Console.WriteLine("Введите количество людей > 0");
                            IsConverted = double.TryParse(Console.ReadLine(), out value);
                        }
                    }
                    break;
                case 6:
                    IsConverted = false;
                    while (!(IsConverted))
                    {
                        value = -1;
                        while (value < 0)
                        {
                            Console.WriteLine("Введите номер дома > 0");
                            IsConverted = double.TryParse(Console.ReadLine(), out value);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Not Fount");
                    break;
            }
            return value;
        }


        public virtual int MenCounter()
        {
            Console.WriteLine("Население мужского пола = 1");
            return 1;
        }


        public virtual int GirlCounter()
        {
            Console.WriteLine("Население женского пола = 1");
            return 1;
        }


        public virtual int BookCounter()
        {
            int temp = 0;
            Random rnd = new Random();
            double Library_Count = 1;
            for (int i = 0; i < Library_Count; i++)
            {
                temp += 0;
            }
            Console.WriteLine("Кол-во книг во всех библиотеках = " + temp);
            return temp;
        }


        public virtual void Print()
        {
            Console.Write("id объекта: ");
            Console.WriteLine(id);
            Console.Write("Название: ");
            Console.WriteLine(name);
        }


        public override string ToString()
        {
            return "Название " + name + " id объекта " + id;
        }


        public virtual Place RandomInit()
        {
            Place temp = new Place(1);
            return temp;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this == null)
                return false;
            else
            {
                Place place = (Place)obj;
                return place.id == this.id;
            }
        }


        public int CompareTo(object obj)
        {
            Place temp = (Place)obj;
            if (temp != null && this != null)
            {
                if (this.Id > temp.Id)
                    return 1;
                else if (this.Id < temp.Id)
                    return -1;
            }
            return 0;
        }


        public Place FoundMax(Place[] array)
        {
            Array.Sort(array);
            Console.WriteLine(array[0].ToString());
            return array[0];
        }


        public object Clone()
        {
            return new Place("Клон " + this.name, this.id);
        }
    }
}

