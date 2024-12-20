using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Задание 1 \n2. Задание 2");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Создаем кота по имени "Барсик"
                    Cat barsik = new Cat("Барсик");

                    Console.WriteLine("Барсик мяукает 1 раз: ");
                    // Кот мяукает один раз
                    barsik.MakeSound();

                    Console.WriteLine("Барсик мяукает 3 раза: ");
                    // Кот мяукает еще три раза
                    for (int i = 0; i < 3; i++)
                    {
                        barsik.MakeSound();
                    }

                    // Словарь для подсчета звуков по имени животного
                    Dictionary<string, AnimalInfo> soundCountDictionary = new Dictionary<string, AnimalInfo>();

                    // Запрашиваем у пользователя количество животных
                    int numberOfAnimals;
                    while (true)
                    {
                        Console.WriteLine("Введите количество животных, которые вы хотите добавить (положительное целое число): ");
                        if (int.TryParse(Console.ReadLine(), out numberOfAnimals) && numberOfAnimals > 0)
                        {
                            break; // Ввод корректен, выходим из цикла
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Пожалуйста, введите положительное целое число.");
                        }
                    }

                    // Цикл для добавления каждого животного
                    for (int i = 0; i < numberOfAnimals; i++)
                    {
                        string animalType;
                        while (true)
                        {
                            Console.WriteLine("Введите тип животного (кот или обезьяна): ");
                            animalType = Console.ReadLine().ToLower();
                            if (animalType == "кот" || animalType == "обезьяна")
                            {
                                break; // Ввод корректен, выходим из цикла
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Неверный тип животного. Пожалуйста, введите 'кот' или 'обезьяна'.");
                            }
                        }

                        string name;
                        while (true)
                        {
                            Console.WriteLine("Введите имя животного: ");
                            name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                break; // Ввод корректен, выходим из цикла
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Имя животного не может быть пустым.");
                            }
                        }

                        int soundCount;
                        while (true)
                        {
                            Console.WriteLine("Введите количество звуков, которые должно издать животное (положительное целое число): ");
                            if (int.TryParse(Console.ReadLine(), out soundCount) && soundCount > 0)
                            {
                                break; // Ввод корректен, выходим из цикла
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Пожалуйста, введите положительное целое число.");
                            }
                        }

                        // Создаем экземпляр животного в зависимости от типа
                        ISoundable animal = null;
                        if (animalType == "кот")
                        {
                            animal = new Cat(name); // Создаем кота
                        }
                        else if (animalType == "обезьяна")
                        {
                            animal = new Monkey(name); // Создаем обезьяну
                        }

                        // Издаем звук заданное количество раз
                        for (int j = 0; j < soundCount; j++)
                        {
                            animal.MakeSound(); // Вызываем метод издания звука
                        }

                        // Обновляем количество звуков в словаре
                        if (soundCountDictionary.ContainsKey(name))
                        {
                            var current = soundCountDictionary[name];
                            current.SoundCount += soundCount; // Увеличиваем счетчик звуков
                        }
                        else
                        {
                            // Если животное новое, добавляем его в словарь
                            soundCountDictionary[name] = new AnimalInfo(name, animalType, soundCount);
                        }
                    }

                    // Выводим количество звуков, изданных каждым животным
                    Console.WriteLine("\nИтоги:");
                    foreach (var entry in soundCountDictionary)
                    {
                        string animalName = entry.Key; // Имя животного
                        int totalSounds = entry.Value.SoundCount; // Общее количество звуков
                        string animalType = entry.Value.Type; // Тип животного

                        // Формируем вывод в зависимости от типа животного
                        if (animalType == "кот")
                        {
                            Console.WriteLine($"{animalName} мяукал(а) {totalSounds} раз(а).");
                        }
                        else if (animalType == "обезьяна")
                        {
                            Console.WriteLine($"{animalName} издавала звуки {totalSounds} раз(а).");
                        }
                    }
                    break;

                case "2":

                    // Создание дробей
                    Fraction f1 = new Fraction(1, 3);
                    Fraction f2 = new Fraction(2, 3);
                    Fraction f3 = new Fraction(1, 2);
                    Fraction f4 = new Fraction(-5, 1);

                    // Примеры операций
                    Console.WriteLine($"{f1} + {f2} = {f1 + f2}"); // Сложение
                    Console.WriteLine($"{f1} - {f2} = {f1 - f2}"); // Вычитание
                    Console.WriteLine($"{f1} * {f2} = {f1 * f2}"); // Умножение
                    Console.WriteLine($"{f1} / {f2} = {f1 / f2}"); // Деление

                    // Операция с добавленной дробью -5
                    Fraction result1 = (f1 + f2) / f3 + f4; 
                    Console.WriteLine($"({f1} + {f2}) / {f3} + {f4} = {result1}");

                    Fraction result = null; // Переменная для хранения результата
                    
                    // Бесконечный цикл для повторного ввода
                    while (true)
                    {
                        try
                        {
                            // Ввод первой дроби
                            Console.WriteLine("Введите числитель первой дроби:");
                            int numerator1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите знаменатель первой дроби:");
                            int denominator1 = int.Parse(Console.ReadLine());
                            Fraction inputF1 = new Fraction(numerator1, denominator1);

                            // Ввод второй дроби
                            Console.WriteLine("Введите числитель второй дроби:");
                            int numerator2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите знаменатель второй дроби:");
                            int denominator2 = int.Parse(Console.ReadLine());
                            Fraction inputF2 = new Fraction(numerator2, denominator2);

                            // Ввод операции
                            Console.WriteLine("Введите операцию (+, -, *, /):");
                            string operation = Console.ReadLine();

                            // Выполнение операции
                            switch (operation)
                            {
                                case "+":
                                    result = inputF1 + inputF2;
                                    break;
                                case "-":
                                    result = inputF1 - inputF2;
                                    break;
                                case "*":
                                    result = inputF1 * inputF2;
                                    break;
                                case "/":
                                    result = inputF1 / inputF2;
                                    break;
                                default:
                                    Console.WriteLine("Неизвестная операция.");
                                    continue;
                            }

                            // Вывод результата
                            Console.WriteLine($"{inputF1} {operation} {inputF2} = {result}");

                            // Сравнение дробей
                            if (inputF1 == inputF2)
                            {
                                Console.WriteLine($"{inputF1} равно {inputF2}");
                            }
                            else
                            {
                                Console.WriteLine($"{inputF1} не равно {inputF2}");
                            }

                            // Вывод вещественного представления дроби
                            Console.WriteLine($"Вещественное представление первой дроби: {inputF1.GetValue()}");
                            Console.WriteLine($"Вещественное представление второй дроби: {inputF2.GetValue()}");
                            Console.WriteLine($"Вещественное представление результата: {result.GetValue()}");

                            // Бесконечный цикл для дальнейших операций
                            while (true)
                            {
                                Console.WriteLine("Введите числитель новой дроби:");
                                int numerator3 = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите знаменатель новой дроби:");
                                int denominator3 = int.Parse(Console.ReadLine());
                                Fraction newFraction = new Fraction(numerator3, denominator3);

                                Console.WriteLine("Введите операцию с предыдущим результатом (+, -, *, /):");
                                string nextOperation = Console.ReadLine();

                                switch (nextOperation)
                                {
                                    case "+":
                                        result = result + newFraction;
                                        break;
                                    case "-":
                                        result = result - newFraction;
                                        break;
                                    case "*":
                                        result = result * newFraction;
                                        break;
                                    case "/":
                                        result = result / newFraction;
                                        break;
                                    default:
                                        Console.WriteLine("Неизвестная операция.");
                                        continue;
                                }

                                // Вывод результата
                                Console.WriteLine($"Результат: {result}");

                                // Сравнение новой дроби с результатом
                                if (result == newFraction)
                                {
                                    Console.WriteLine($"{result} равно {newFraction}");
                                }
                                else
                                {
                                    Console.WriteLine($"{result} не равно {newFraction}");
                                }

                                // Вывод вещественного представления результата
                                Console.WriteLine($"Вещественное представление результата: {result.GetValue()}");
                                Console.WriteLine($"Вещественное представление новой дроби: {newFraction.GetValue()}");

                                // Запрос на продолжение или выход
                                Console.WriteLine("Хотите ввести еще дробь? (да/нет):");
                                if (Console.ReadLine().ToLower() != "да")
                                {
                                    break; // Выход из внутреннего цикла
                                }
                            }

                            // Запрос на продолжение или выход
                            Console.WriteLine("Хотите ввести новый пример? (да/нет):");
                            if (Console.ReadLine().ToLower() != "да")
                            {
                                break; // Выход из внешнего цикла
                            }

                        }

                        catch (Exception ex)
                        {
                            // Обработка ошибок
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                    }
                    break;
            }
        }
    }
}
