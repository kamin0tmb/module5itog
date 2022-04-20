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
            string name;
            do
            {
                Console.Write("Введите Ваше имя: ");
                name = Console.ReadLine();
            }
            while (!IsAllLetters(name));
            anketa.Name = name;
            string lastname;
            do
            {
                Console.Write("Введите Вашу фамилию: ");
                lastname = Console.ReadLine();
            }
            while (!IsAllLetters(lastname));
            anketa.LastName = lastname;
            int age;
            do
            {
                Console.Write("Введите Ваш возраст: ");
                age = Check();
            }
            while (age < 1);
            anketa.Age = Convert.ToByte(age);
            Console.Write("Есть ли у Вас домашнее животное? (да/нет): ");
            string havepet;
            anketa.HasPet = true;
            do
            {
                havepet = Console.ReadLine();

                if (havepet == "да" | havepet == "нет")
                {
                    if (havepet == "да")
                        anketa.HasPet = true;
                    else
                        anketa.HasPet = false;
                }
                else
                {
                    Console.Write("ответ может быть только да или нет. Введите еще раз: ");
                }
            }
            while (havepet != "да" & havepet != "нет");
            if (anketa.HasPet == true)
            {
                int npet;
                do
                {
                    Console.Write("Введите сколько у Вас домашних животных: ");
                    npet = Check();
                }
                while (npet < 1);
                anketa.PetName = Pets(npet);
            }
            else
                anketa.PetName = new string[] { "" };

            int ncolor;
            do
            {
                Console.Write("Сколько у Вас любимых цветов? ");
                ncolor = Check();
            }
            while (ncolor < 1);
            anketa.Color = Colors(ncolor);
            return anketa;



        }
        static string[] Colors(int i)
        {
            var favcol = new string[i];
            for (i = 0; i < favcol.Length; i++)
            {
                do
                {
                    Console.Write("Введите ваш любимый цвет №{0}: ", i + 1);
                    favcol[i] = Console.ReadLine();
                }
                while (!IsAllLetters(favcol[i]));
            }
            return favcol;
        }
        static string[] Pets(int i)
        {
            var petname = new string[i];
            for (i = 0; i < petname.Length; i++)
            {
                do
                {
                    Console.Write("Введите кличку домашнего животного №{0}: ", i + 1);
                    petname[i] = Console.ReadLine();
                }
                while (!IsAllLetters(petname[i]));
            }
            return petname;
        }
        static bool IsAllLetters(string s)
        {
            int i;
            if (s.Length == 0)
            {
                Console.WriteLine("Поле не может быть пустым. Введите значение.");
                return false;
            }
            for (i = 0; i < s.Length; i++)
            if (!Char.IsLetter(s[i]) && s[i] != ' ' && s[i] != '-')
            {
                Console.WriteLine("Допустимо введение только букв.");
                return false;
            }
            return true;
        }
            static bool IsAllDigits(string s)
        {
            int i;
            if (s.Length == 0)
            {
                Console.WriteLine("Поле не может быть пустым. Введите значение.");
                return false;
            }
            for (i = 0; i < s.Length; i++)
            if (Char.IsDigit(s[i]) == false)
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
        static int Check()
        {
            int i = 0;
            string s = Console.ReadLine();
            if (!IsAllDigits(s))
                Console.WriteLine("Необходимо ввести положительное число! Введите еще раз. ");
            else if (Int32.Parse(s) < 1)
                Console.WriteLine("Число должно быть больше 0. ");
            else
                i = Int32.Parse(s);
            return i;
        }
    }
}
