using System;

namespace module5itog
{
    class Program
    {
        static void Main(string[] args)
        {
            (string Name, string LastName, byte Age, bool HasPet, string[] PetName, string[] Color) anketa;
            anketa = Anketa();
            Console.WriteLine();
            ShowUserInfo(anketa);


        }
        static (string Name, string LastName, byte Age, bool HasPet, string[] PetName, string[] Color) Anketa()
        {
            (string Name, string LastName, byte Age, bool HasPet, string[] PetName, string[] Color) anketa;
            Console.Write("Введите Ваше имя: ");
            anketa.Name = Console.ReadLine();
            Console.Write("Введите Вашу фамилию: ");
            anketa.LastName = Console.ReadLine();
            anketa.Age = 0;
            do
            {
                Console.Write("Введите Ваш возраст: ");
                string s = Console.ReadLine();
                if (!IsAllDigits(s))
                    Console.WriteLine("Это не число! Введите еще раз. ");
                else if (Int32.Parse(s) < 1)
                    Console.WriteLine("Число должно быть больше 0. ");
                else
                anketa.Age = byte.Parse(s);
            }
            while (anketa.Age < 1);
            
            Console.Write("Есть ли у Вас домашнее животное? (да/нет): ");
            string H;
            anketa.HasPet = true;
            do
            { 
                H = Console.ReadLine();

                if (H == "да" | H == "нет")
                {
                    if (H == "да")
                        anketa.HasPet = true;
                    else
                        anketa.HasPet = false;
                }
                else
                {
                    Console.Write("ответ может быть только да или нет. Введите еще раз: ");
                }
            }
            while (H != "да" & H != "нет");
            if (anketa.HasPet == true)
            {
                int i = 0;
                do
                {
                    Console.Write("Введите сколько у Вас домашних животных: ");
                    string s = Console.ReadLine();
                    if (!IsAllDigits(s))
                        Console.WriteLine("Это не число! Введите еще раз. ");
                    else if (Int32.Parse(s) < 1)
                        Console.WriteLine("Число должно быть больше 0. ");
                    else 
                        i = Int32.Parse(s);
                }
                while (i < 1);
                anketa.PetName = Pets(i);
            }
            else
                anketa.PetName = new string[] { "" };

            int j = 0;
            do
            {
                Console.Write("Сколько у Вас любимых цыетов? ");
                string s = Console.ReadLine();
                if (!IsAllDigits(s))
                    Console.WriteLine("Это не число! Введите еще раз. ");
                else if (Int32.Parse(s) < 1)
                    Console.WriteLine("Число должно быть больше 0. ");
                else
                    j = Int32.Parse(s);
            }
            while (j < 1);
            anketa.Color = Colors(j);
            var result = (anketa.Name, anketa.LastName, anketa.Age, anketa.HasPet, anketa.PetName, anketa.Color);
            return result;
            


        }
        static string[] Colors(int j)
        {
            var favcol = new string[j];
            for (j = 0; j < favcol.Length; j++)
            {
                Console.Write("Введите ваш любимый цвет №{0}: ", j + 1);
                favcol[j] = Console.ReadLine();
            }
            return favcol;
        }
        static string[] Pets (int i)
        {
            var petname = new string[i];
            for (i = 0; i < petname.Length; i++)
            {
                Console.Write("Введите кличку домашнего животного №{0}: ", i + 1);
                petname[i] = Console.ReadLine();
            }
            return petname;
        }
        static bool IsAllDigits(string s)
        {
            int index;
            if (s.Length == 0)
                return false;
            for (index = 0; index < s.Length - 1; index++) ;
            if (Char.IsDigit(s[index]) == false)
                return false;
            return true;
        }
        static void ShowUserInfo
             ((string Name, string LastName, byte Age, bool HasPet, string[] PetName, string[] Color) User)
        {
            Console.WriteLine("Имя и Фамилия пользователя: {0} {1}", User.Name, User.LastName);
            string years;
            if (User.Age % 10 > 4 || User.Age % 10 == 0 || User.Age > 10 && User.Age < 20)
                years = "лет";
            else if (User.Age % 10 != 1)
                years = "года";
            else
                years = "год";
            Console.WriteLine("Возраст: {0} {1}", User.Age, years);
            if (User.HasPet)
            {
                Console.WriteLine("Количество питомцев: {0}", User.PetName.Length);
                Console.WriteLine("их клички:");
                foreach (string nick in User.PetName)
                    Console.WriteLine("\t{0}", nick);
            }
            else
                Console.WriteLine("У пользователя нет питомцев.");
            Console.WriteLine("Любимые цвета:");
            foreach (string colors in User.Color)
                Console.WriteLine("\t{0}", colors);
        }
    }
}


