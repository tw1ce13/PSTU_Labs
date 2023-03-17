using System;
namespace Laba_12
{

    public class Area : Place
    {
        protected double width;
        protected double longuitude;

        public Area()
        {
        }


        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if ((width > 90) || (width < -90))
                    width = 0;
                else
                    width = value;
            }
        }


        public double Longuitude
        {
            get
            {
                return longuitude;
            }
            set
            {
                if ((longuitude > 180) || (longuitude < -180))
                    width = 0;
                else
                    width = value;
            }
        }


        public Area(int desicion)
        {
            switch (desicion)
            {
                case 1:
                    string[] arr = new string[] { "Пермская область", "Ленинградская область", "Московская область", "Парижская область", "Римская область" };
                    Random rnd = new Random();
                    name = arr[rnd.Next(0, 5)];
                    id = rnd.Next(1, 20);
                    width = rnd.Next(-90, 91);
                    longuitude = rnd.Next(-180, 181);
                    break;
                case 2:
                    name = InputStr(1);
                    id = (int)Input(4);
                    width = Input(2);
                    longuitude = Input(3);
                    break;
            }
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
            double Library_Count = rnd.Next(8, 20);
            for (int i = 0; i < Library_Count; i++)
            {
                temp += rnd.Next(970, 3750);
            }
            Console.WriteLine("Кол-во книг во всех библиотеках = " + temp);
            return temp;
        }


        public override void Print()
        {
            Console.WriteLine("Название области: " + name);
            Console.WriteLine("Широта: " + width);
            Console.WriteLine("Долгота: " + longuitude);
        }


        public override Place RandomInit()
        {
            Area temp = new Area(1);
            return temp;
        }

    }
}

