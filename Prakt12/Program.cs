using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prakt12
{
    class Program
    {
        static string[] arr = new string[File.ReadAllLines(@"D:\Студент\2 курс\ИС-22\Prakt12\Jackaby.txt").Length];
        static void Main(string[] args)
        {
            string name, surname;
            StreamWriter sw = new StreamWriter("user.txt", true);
            sw.Write(DateTime.Now);
            Console.Write("Введите имя: ");
            name = Convert.ToString(Console.ReadLine());
            sw.Write("\tИмя - " + name);
            Console.Write("Введите фамилию: ");
            surname = Convert.ToString(Console.ReadLine());
            sw.WriteLine("\tФамилия - " + surname);
            sw.Close();
            
            ReadTextAsync();
        choice:
            Console.WriteLine("Для вывода обычного текста нажмите 1, для вывода асинхронного текста нажмите 2, для выхода нажмите любую другую кнопку");
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine($" --- нажатая кнопка");
            if (cki.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Вы выбрали стандартный текст");
                string path = @"D:\Студент\2 курс\ИС-22\Prakt12\Jackaby.txt";
                string[] readText = File.ReadAllLines(path, Encoding.Default);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
                goto choice;
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Вы выбрали асинхронный текст");
                GenerateText();
                string path1 = @"D:\Студент\2 курс\ИС-22\Prakt12\Async.txt";
                string[] readTextAsync = File.ReadAllLines(path1, Encoding.UTF8);
                foreach (string s in readTextAsync)
                {
                    Console.WriteLine(s);
                }
                goto choice;
            }
        }
        static async void ReadTextAsync()
        {
            await Task.Run(() => ReadText());
        }
        static void ReadText()
        {
            string path = @"D:\Студент\2 курс\ИС-22\Prakt12\Jackaby.txt";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sr.ReadLine();
            }
            sr.Close();
        }
        static void GenerateText() //генерирует txt файл с рандомными строками из оригинала
        {
            string path = @"D:\Студент\2 курс\ИС-22\Prakt12\Jackaby.txt";
            string path2 = @"D:\Студент\2 курс\ИС-22\Prakt12\Async.txt";
            if (File.Exists("rndText.txt")) //
            {
                File.Delete("rndText.txt");
            }
            var random = new Random();
            string[] readText = File.ReadAllLines(path, Encoding.Default);
            for (int i = 0; i < File.ReadAllLines(@"D:\Студент\2 курс\ИС-22\Prakt12\Jackaby.txt").Length; i++)
            {
                readText[i] = readText[random.Next(1, 1185)];
            }
            File.WriteAllLines(path2, readText);
        }
    }
}
