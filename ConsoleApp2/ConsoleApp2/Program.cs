using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine("Выберите задание: \n1.2 - Сумма знаков (кнопка 1) \n1.4 - Есть ли позитив (кнопка 2)");
            Console.WriteLine("1.6 - Большая буква (кнопка 3) \n1.8 - Делитель (кнопка 4) \n1.10 - Многократный вызов (кнопка 5)");
            Console.WriteLine("2.2 - Безопасное деление (кнопка 6) \n2.4 - Строка сравнения (кнопка 7) \n2.6 - Тройная сумма (кнопка 8)");
            Console.WriteLine("2.8 - Возраст (кнопка 9) \n2.10 - Вывод дней недели (кнопка 10) \n3.2 - Числа наоборот (кнопка 11)");
            Console.WriteLine("3.4 - Степень числа (кнопка 12) \n3.6 - Одинаковость (кнопка 13) \n3.8 - Левый треугольник (кнопка 14)");
            Console.WriteLine("3.10 - Угадайка (кнопка 15) \n4.2 - Поиск последнего значения (кнопка 16) \n4.4 - Добавление в массив (кнопка 17)");
            Console.WriteLine("4.6 - Реверс (кнопка 18) \n4.8 - Объединение (кнопка 19) \n4.10 - Удалить негатив (кнопка 20)");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Задание 1.2 \nВведите число:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    int result = p.sumLastNums(x);
                    Console.WriteLine($"Результат: {result}");
                    break;
                case 2:
                    Console.WriteLine("Задание 1.4 \nВведите число: ");
                    int x4 = Convert.ToInt32(Console.ReadLine());
                    bool result4 = p.isPositive(x4);
                    Console.WriteLine($"Результат: {result4}");
                    break;
                case 3:
                    Console.WriteLine("Задание 1.6 \nВведите букву: строчную или заглавную");
                    string input = Console.ReadLine();
                    char x6 = input[0];
                    bool result6 = p.isUpperCase(x6);
                    Console.WriteLine("Результат: " + result6.ToString());
                    break;
                case 4:
                    Console.WriteLine("Задание 1.8 \nВведите 2 числа: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
                    bool result8 = p.isDivisor(a, b);
                    Console.WriteLine($"Результат: {result8}");
                    break;
                case 5:
                    Console.WriteLine("Задание 1.10 \nВведите первое число: ");
                    int sum = 0;
                    int a10 = int.Parse(Console.ReadLine());
                    sum = a10 % 10;

                    for (int i = 1; i < 5; i++)
                    {
                        Console.WriteLine("Введите следующее число:");
                        int b10 = int.Parse(Console.ReadLine());
                        sum = p.lastNumSum(sum, b10);
                        Console.WriteLine($"Текущая сумма: {sum}");
                    }

                    Console.WriteLine($"Итого: {sum}");
                    break;
                case 6:
                    Console.WriteLine("Задание 2.2 \nВведите первое число, затем нажмите enter и введите второе число: ");
                    int x2 = Convert.ToInt32(Console.ReadLine());
                    int y2 = Convert.ToInt32(Console.ReadLine());
                    double Result2 = p.safeDiv(x2, y2);
                    Console.WriteLine($"Результат: {Result2}");
                    break;
                case 7:
                    Console.WriteLine("Задание 2.4 \nВведите первое число, затем нажмите enter и введите второе число: ");
                    int X4 = Convert.ToInt32(Console.ReadLine());
                    int Y4 = Convert.ToInt32(Console.ReadLine());
                    string Result4 = p.makeDecision(X4, Y4);
                    Console.WriteLine($"Результат: {Result4}");
                    break;
                case 8:
                    Console.WriteLine("Задание 2.6 \n Введите 3 числа по порядку через enter");
                    int X6 = Convert.ToInt32(Console.ReadLine());
                    int Y6 = Convert.ToInt32(Console.ReadLine());
                    int Z6 = Convert.ToInt32(Console.ReadLine());
                    bool Result6 = p.sum3(X6, Y6, Z6);
                    Console.WriteLine($"Результат: {Result6}");
                    break;
                case 9:
                    Console.WriteLine("Задание 2.8 \n Введите число: ");
                    int X8 = int.Parse(Console.ReadLine());
                    string Result8 = p.age(X8);
                    Console.WriteLine($"Результат: {Result8}");
                    break;
                case 10:
                    Console.WriteLine("Задание 2.10 \nВведите день недели с маленькой буквы: ");
                    string X10 = Console.ReadLine();
                    Console.WriteLine("Результат:");
                    p.printDays(X10);
                    break;
                case 11:
                    Console.WriteLine("Задание 3.2 \nВведите число:");
                    int X32 = int.Parse(Console.ReadLine());
                    string resulT2 = p.reverseListNums(X32);
                    Console.WriteLine($"Результат: {resulT2}");
                    break;
                case 12:
                    Console.WriteLine("Задание 3.4 \nВведите x:");
                    int X34 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите y:");
                    int Y34 = int.Parse(Console.ReadLine());
                    int resulT4 = p.pow(X34, Y34);
                    Console.WriteLine($"Результат: {resulT4}");
                    break;
                case 13:
                    Console.WriteLine("Задание 3.6 \nВведите число: ");
                    int X36 = int.Parse(Console.ReadLine());
                    bool resulT6 = p.equalNum(X36);
                    Console.WriteLine($"Результат: {resulT6}");
                    break;
                case 14:
                    Console.WriteLine("Задание 3.8 \nВведите высоту треугольника:");
                    int X38 = int.Parse(Console.ReadLine());
                    p.leftTriangle(X38);
                    break;
                case 15:
                    Console.WriteLine("Задание 3.10");
                    p.guessGame();
                    break;
                case 16:
                    //запрос ввода массива
                    Console.WriteLine("Задание 4.2 \nВведите элементы массива, разделенные пробелом:");
                    string input1 = Console.ReadLine();
                    string[] inputArray = input1.Split(' ');
                    int[] arr = Array.ConvertAll(inputArray, int.Parse);
                    //запрос ввода значения для поиска
                    Console.WriteLine("Введите значение для поиска:");
                    int X42 = int.Parse(Console.ReadLine());
                    //вызов метода и вывод результата
                    int index = p.findLast(arr, X42);
                    Console.WriteLine($"Индекс последнего вхождения {X42}: {index}");
                    break;
                case 17:
                    Console.Write("Задание 4.4 \nВведите количество элементов в массиве: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    int[] arrr = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"Введите элемент {i + 1}: ");
                        arrr[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.Write("Введите значение для добавления: ");
                    int X44 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите позицию для добавления: ");
                    int pos = Convert.ToInt32(Console.ReadLine());
                    int[] ResulT4 = p.add(arrr, X44, pos);
                    Console.WriteLine("Результирующий массив: ");
                    for (int i = 0; i < ResulT4.Length; i++)
                    {
                        Console.Write($"{ResulT4[i]} ");
                    }
                    break;
                case 18:
                    Console.Write("Задание 4.6 \nВведите количество элементов в массиве: ");
                    int nn = Convert.ToInt32(Console.ReadLine());
                    int[] arr3 = new int[nn];
                    for (int i = 0; i < nn; i++)
                    {
                        Console.Write($"Введите элемент {i + 1}: ");
                        arr3[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Оригинальный массив: ");
                    for (int i = 0; i < arr3.Length; i++)
                    {
                        Console.Write($"{arr3[i]} ");
                    }
                    p.reverse(arr3);
                    Console.WriteLine("\nМассив в обратном порядке: ");
                    for (int i = 0; i < arr3.Length; i++)
                    {
                        Console.Write($"{arr3[i]} ");
                    }
                    break;
                case 19:
                    Console.Write("Задание 4.8 \nВведите количество элементов в первом массиве: ");
                    int n1 = Convert.ToInt32(Console.ReadLine());
                    int[] arr1 = new int[n1];
                    for (int i = 0; i < n1; i++)
                    {
                        Console.Write($"Введите элемент {i + 1} первого массива: ");
                        arr1[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.Write("Введите количество элементов во втором массиве: ");
                    int n2 = Convert.ToInt32(Console.ReadLine());
                    int[] arr2 = new int[n2];
                    for (int i = 0; i < n2; i++)
                    {
                        Console.Write($"Введите элемент {i + 1} второго массива: ");
                        arr2[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Первый массив: ");
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        Console.Write($"{arr1[i]} ");
                    }
                    Console.WriteLine("\nВторой массив: ");
                    for (int i = 0; i < arr2.Length; i++)
                    {
                        Console.Write($"{arr2[i]} ");
                    }
                    int[] ResulT8 = p.concat(arr1, arr2);
                    Console.WriteLine("\nОбъединенный массив: ");
                    for (int i = 0; i < ResulT8.Length; i++)
                    {
                        Console.Write($"{ResulT8[i]} ");
                    }
                    break;
                case 20:
                    Console.Write("Задание 4.10 \nВведите количество элементов в массиве: ");
                    int n10 = Convert.ToInt32(Console.ReadLine());

                    int[] arr10 = new int[n10];
                    for (int i = 0; i < n10; i++)
                    {
                        Console.Write($"Введите элемент {i + 1} массива: ");
                        arr10[i] = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("Исходный массив: ");
                    for (int i = 0; i < arr10.Length; i++)
                    {
                        Console.Write($"{arr10[i]} ");
                    }

                    int[] ResulT10 = p.deleteNegative(arr10);

                    Console.WriteLine("\nМассив без отрицательных элементов: ");
                    for (int i = 0; i < ResulT10.Length; i++)
                    {
                        Console.Write($"{ResulT10[i]} ");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор задания");
                    break;
            }

        }

        public int sumLastNums(int x)
        {
            int lastDigit = x % 10;
            int remainNumber = x / 10;
            int secondLastDigit = remainNumber % 10;
            return lastDigit + secondLastDigit;

        }

        public bool isPositive(int x)
        {
            if (x > 0)
            { 
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isUpperCase(char x)
        {
            return x >= 'A' && x <= 'Z';
        }

        public bool isDivisor(int a, int b)
        {
            if ((a % b == 0) || (b % a == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int lastNumSum(int a, int b)
        {
            return (a % 10) + (b % 10);
        }

        public double safeDiv (int x, int y)
        {
            if (y == 0)
            {
                return 0;
            }
            else
            {
                return (double)x / y;
            }
        }

        public String makeDecision(int x, int y)
        {
            if (x > y)
            {
                return $" {x} > {y}";
            }
            else if (x < y)
            {
                return $" {x} < {y}";
            }
            else
            {
                return $" {x} = {y}";
            }
        }

        public bool sum3(int x, int y, int z)
        {
            if (x + y == z || x + z == y || y + z == x)
            { return true; }
            else { return false; }
        }

        public String age(int x)
        {
            if (x % 10 == 1 && x % 100 != 11)
            {
                return $"{x} год";
            }
            else if (x % 10 >= 2 && x % 10 <= 4 && (x % 100 < 12 || x % 100 > 14))
            {
                return $"{x} года";
            }
            else
            {
                return $"{x} лет";
            }
        }

        public void printDays (String x)
        {
            string[] days = { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" };

            switch (x)
            {
                case "понедельник":
                    for (int i = 0; i < days.Length; i++)
                    {
                        Console.WriteLine(days[i]);
                    }
                    break;
                case "вторник":
                    for (int i = 1; i < days.Length; i++)
                    {
                        Console.WriteLine(days[i]);
                    }
                    break;
                case "среда":
                    for (int i = 2; i < days.Length; i++)
                    {
                        Console.WriteLine(days[i]);
                    }
                    break;
                case "четверг":
                    for (int i = 3; i < days.Length; i++)
                    {
                        Console.WriteLine(days[i]);
                    }
                    break;
                case "пятница":
                    for (int i = 4; i < days.Length; i++)
                    {
                        Console.WriteLine(days[i]);
                    }
                    break;
                case "суббота":
                    for (int i = 5; i < days.Length; i++)
                    {
                        Console.WriteLine(days[i]);
                    }
                    break;
                case "воскресенье":
                    Console.WriteLine(x);
                    break;
                default:
                    Console.WriteLine("это не день недели");
                    break;
            }

        }

        public String reverseListNums (int x)
        {
            string result = "";
            for (int i = x; i >= 0; i--)
            {
                result += i + " ";
            }
            return result.Trim();

        }

        public int pow (int x, int y)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            return result;
        }

        public bool equalNum(int x)
        {
            if (x < 0)
            {
                x = -x; //обработка отрицательного числа
            }

            int firstDigit = x % 10;
            x /= 10;

            while (x > 0)
            {
                if (x % 10 != firstDigit)
                {
                    return false; //если хотя бы одна цифра не совпадает, возвращаем false
                }
                x /= 10;
            }

            return true;
        }

        public void leftTriangle (int x)
        {
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(); //переход на новую строку после каждой строки
            }
        }

        public void guessGame ()
        {
            Random random = new Random();
            int secretNumber = random.Next(10); //случайное число от 0 до 9
            int attempts = 0;
            Console.WriteLine("Введите число от 0 до 9:");
            while (true)
            {
                int guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess == secretNumber)
                {
                    Console.WriteLine("Вы угадали!");
                    Console.WriteLine($"Вы отгадали число за {attempts} попыток");
                    break; //прерываем цикл после угадывания
                }
                else
                {
                    Console.WriteLine("Вы не угадали, введите число от 0 до 9:");
                }
            }
        }

        public int findLast(int[] arr, int x)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == x)
                {
                    return i; //возвращаем индекс последнего вхождения
                }
            }
            return -1;
        }

        public int[] add(int[] arr, int x, int pos)
        {
            int[] newArr = new int[arr.Length + 1];
            for (int i = 0; i < pos; i++)
            {
                newArr[i] = arr[i];
            }
            newArr[pos] = x;
            for (int i = pos + 1; i < newArr.Length; i++)
            {
                newArr[i] = arr[i - 1];
            }
            return newArr;
        }

        public void reverse(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }

        public int[] concat(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            Array.Copy(arr1, 0, result, 0, arr1.Length);
            Array.Copy(arr2, 0, result, arr1.Length, arr2.Length);
            return result;
        }

        public int[] deleteNegative(int[] arr)
        {
            int count = 0;
            foreach (int element in arr)
            {
                if (element >= 0)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;
            foreach (int element in arr)
            {
                if (element >= 0)
                {
                    result[index] = element;
                    index++;
                }
            }

            return result;
        }
    }
}
