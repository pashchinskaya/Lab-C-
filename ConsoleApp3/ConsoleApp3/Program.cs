using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Задание 2");
                //Вывод часов
                byte hours = GetByteInput("Введите часы (0-23): ", 0, 23);
                //Вывод минут
                byte minutes = GetByteInput("Введите минуты (0-59): ", 0, 59);

                // Создание объекта Time
                Time time = new Time(hours, minutes);
                Console.WriteLine("Исходное время: " + time.ToString());

                // Ввод минут для вычитания
                uint minutesToSubtract = GetUIntInput("Введите количество минут для вычитания: ");

                // Вычитание минут
                Time newTime = time.SubtractMinutes(minutesToSubtract);
                Console.WriteLine($"Время после вычитания: {newTime.ToString()}");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }


        Console.WriteLine("Задание 3");
        // Вывод часов
        byte hours1 = GetByteInput("Введите часы (0-23): ", 0, 23);

        // Вывод минут
        byte minutes1 = GetByteInput("Введите минуты (0-59): ", 0, 59);

        // Создаем объект Time на основе пользовательского ввода
        Time time1 = new Time(hours1, minutes1);
        Time time2 = new Time(hours1, minutes1); // Создаем второй объект с теми же данными
        Time time3 = new Time(hours1, minutes1); // Третий объект 

        // Тестируем унарные операции
        Console.WriteLine("Исходное время time1: " + time1);
        Time resetTime = -time1; // Обнуление часов и минут
        Console.WriteLine("Обнуленное время: " + resetTime);

        Time resetMinutesTime = time1.ResetMinutes(); // Обнуление минут
        Console.WriteLine("Время с обнуленными минутами: " + resetMinutesTime);

        // Тестируем операции приведения типа
        byte hours2 = time1; // Неявное приведение к byte
        Console.WriteLine("Часы time1: " + hours2);

        bool isNotZero = (bool)time1; // Явное приведение к bool
        Console.WriteLine("time1 не равно нулю: " + isNotZero);

        // Тестируем бинарные операции
        bool areEqual = time1 == time2; // Сравнение на равенство
        Console.WriteLine("time1 равно time2: " + areEqual);

        bool areNotEqual = time1 != time3; // Сравнение на неравенство
        Console.WriteLine("time1 не равно time3: " + areNotEqual);

        }

        // Метод для получения корректного значения byte
        private static byte GetByteInput(string message, byte minValue, byte maxValue)
        {
            while (true)
            {
                Console.Write(message);
                if (byte.TryParse(Console.ReadLine(), out byte result) && result >= minValue && result <= maxValue)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Некорректный ввод. Пожалуйста, введите число от {minValue} до {maxValue}.");
                }
            }
        }

        // Метод для получения корректного значения uint
        private static uint GetUIntInput(string message)
        {
            while(true)
            {
                Console.Write(message);
                if (uint.TryParse(Console.ReadLine(), out uint result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите неотрицательное целое число.");
                }
            }
        }
    }
}
