using System;
using System.IO;
using System.Text;


namespace AddressBook
{
    class addressbook
    {
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }


        public addressbook() { }
        public void Writeaddressbook()
        { 
            using (StreamWriter sw = File.AppendText("addressbook.txt"))
            {
                sw.WriteLine(this.Firstname);
                sw.WriteLine(this.Phone);
                sw.WriteLine(this.Phone2);
            }      
        }
        public static void Addressbook(string name)
        {
            using (StreamReader sr = File.OpenText("addressbook.txt"))
            {

                string temp = null;
                while ((temp = sr.ReadLine()) != name && temp != null) ;
                if (temp == name)
                {
                    Console.WriteLine(String.Format("\nИмя: " + temp));
                    Console.WriteLine(String.Format("Телефон: \n" + sr.ReadLine()));
                    Console.WriteLine(String.Format("Телефон номер 2: \n" + sr.ReadLine()));
                }
                else Console.WriteLine("Такой человек не найден . .");
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-20} {1,-20} {2,-20} ", Firstname, Phone, Phone2);
        }

        public static char otvet; 
        public static string s; 
        static void Main(string[] args)
        {
            string file_name = "addressbook.txt";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("Запускаем простую записную книжку . .");
            if (System.IO.File.Exists(Convert.ToString(Path.GetFullPath(file_name))) == false)
            Console.WriteLine("Не найден файл addressbook.txt. . он будет создан автоматически . .");
            Console.WriteLine("Готово . .");
            string chislo = null;
            while (chislo != "3")
            {
                do
                {
                    Console.WriteLine("------------МЕНЮ------------");
                    Console.WriteLine(
                   " 1 - Добавить новую запись.\n" +
                   " 2 - Найти запись.\n" +
                   " 3 - выход.\n");
                    chislo = Console.ReadLine(); 
                    switch (chislo)
                    {
                        case "1":
                         
                          addressbook temp = new addressbook();
                          Console.WriteLine("Введите имя: ");
                          temp.Firstname = Console.ReadLine();
                          Console.WriteLine("Введите телефон: ");
                          temp.Phone = Console.ReadLine();
                          Console.WriteLine("Введите второй номер телефона: ");
                          temp.Phone2 = Console.ReadLine();
                          temp.Writeaddressbook();
                          Console.WriteLine("\n Запись добавлена!");
                           break;
                        case "2":
                            string n = null;
                            Console.WriteLine("Введите имя человека, которого желаете найти: ");
                            n = Console.ReadLine();
                            addressbook.Addressbook(n); 
                            break;
                        case "3":
                            Console.WriteLine("До встречи!");
                            Console.ReadKey(); return;
                    }
                    do
                    {
                        Console.WriteLine("\nПродолжаем? y/n");
                        s = Console.ReadLine(); 
                        try 
                        { 
                            otvet = char.Parse(s);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка при вводе!!! ");
                        }
                    }
                    while (otvet != 'y' && otvet != 'n'); Console.Clear();
                }
                while (otvet == 'y');
                if (otvet == 'n') 
                { 
                    Console.WriteLine("\n" + "До встречи!"); break;
                }
            }
            Console.ReadLine();
        }

    }

}