using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Королёв", "Макаров", "Иванова" };
            string[] posts = { "Директор", "Управляющий", "Менеджер" };
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine();
                Console.WriteLine("1 - добавить досье");
                Console.WriteLine("2 - показать все досье");
                Console.WriteLine("3 - удалить досье");
                Console.WriteLine("4 - поиск по фамилии");
                Console.WriteLine("5 - выход\n");
                Console.Write("Введите пункт меню: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddFile(ref names, ref posts);
                        break;
                    case "2":
                        ShowFiles(ref names, ref posts);
                        break;
                    case "3":
                        DeleteFile(ref names, ref posts);
                        break;
                    case "4":
                        FindFile(ref names, ref posts);
                        break;
                    case "5":
                        isWork = false;
                        break;
                }
            }

            Console.WriteLine("Вы вышли из программы.");
            Console.ReadKey();
        }

        public static void AddFile(ref string[] names, ref string[] posts)
        {
            string[] tempNames = new string[names.Length + 1];
            string[] tempPosts = new string[posts.Length + 1];

            for (int i = 0; i < names.Length; i++)
            {
                tempNames[i] = names[i];
                tempPosts[i] = posts[i];
            }

            names = tempNames;
            posts = tempPosts;
            Console.Write("\nНапишите фамилию нового сотрудника: ");
            names[names.Length - 1] = Console.ReadLine();
            Console.Write("Напишите должность нового сотрудника: ");
            posts[posts.Length - 1] = Console.ReadLine();
            Console.WriteLine("Сотрудник добавлен в базу!");
            Console.WriteLine();
        }

        public static void ShowFiles(ref string[] names, ref string[] posts)
        {
            Console.WriteLine();
            Console.WriteLine("Список всех досье:");

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != "" && posts[i] != "")
                {
                    Console.WriteLine((i + 1) + ". " + names[i] + " - " + posts[i]);
                }
            }

            Console.WriteLine();
        }

        public static void DeleteFile(ref string[] names, ref string[] posts)
        {
            int inputIndexArray;
            string[] tempNames = new string[names.Length - 1];
            string[] tempPosts = new string[posts.Length - 1];

            ShowFiles(ref names, ref posts);
            Console.Write("Введите номер досье, который хотите удалить: ");
            inputIndexArray = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < inputIndexArray - 1; i++)
            {
                tempNames[i] = names[i];
                tempPosts[i] = posts[i];
            }

            for (int i = inputIndexArray; i < posts.Length; i++)
            {
                tempNames[i - 1] = names[i];
                tempPosts[i - 1] = posts[i];
            }

            names = tempNames;
            posts = tempPosts;
            Console.WriteLine("Досье удалено!");
        }

        public static void FindFile(ref string[] names, ref string[] posts)
        {
            string inputSecondName;
            bool secondNameIsFind = false;
            Console.Write("\nЧтобы найти досье, введите фамилию: ");
            inputSecondName = Console.ReadLine();

            for (int i = 0; i < names.Length; i++)
            {
                if (inputSecondName.ToLower() == names[i].ToLower())
                {
                    //indexArray = i;
                    Console.WriteLine("\nВаше досье: ");
                    Console.WriteLine((i + 1) + ". " + names[i] + " - " + posts[i]);
                    secondNameIsFind = true;
                }
            }
            if (secondNameIsFind == false)
            {
                Console.WriteLine("Такого досье нет!");
            }
        }
    }
}