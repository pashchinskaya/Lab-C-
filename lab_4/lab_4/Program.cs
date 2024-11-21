using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Введите номер задания от 1 до 5: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:  // Задание 1
                    List<string> L1 = InputList("Введите элементы для списка L1 (через пробел): ");
                    List<string> L2 = InputList("Введите элементы для списка L2 (через пробел): ");

                    // Формируем список L, который содержит элементы из L1, которые не входят в L2
                    List<string> L = CreateList(L1, L2);

                    // Выводим результат
                    Console.WriteLine("Элементы из списка L1, которые не входят в список L2:");
                    foreach (var item in L)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 2:  // Задание 2
                    LinkedList<int> list = new LinkedList<int>();
                    // Ввод элементов списка с клавиатуры
                    InputElements(list);

                    // Проверка на наличие элементов в списке
                    if (list.Count == 0)
                    {
                        Console.WriteLine("Ошибка: список пуст.");
                        return;
                    }

                    // Ввод индексов i и j
                    int i, j;
                    Console.WriteLine("Введите индекс i (начало участка): ");
                    while (!int.TryParse(Console.ReadLine(), out i) || i < 0 || i >= list.Count)
                    {
                        Console.WriteLine("Некорректный ввод. Введите индекс i (0 <= i < " + list.Count + "): ");
                    }

                    Console.WriteLine("Введите индекс j (конец участка): ");
                    while (!int.TryParse(Console.ReadLine(), out j) || j <= i || j >= list.Count)
                    {
                        Console.WriteLine("Некорректный ввод. Введите индекс j (i < j < " + list.Count + "): ");
                    }

                    // Проверка симметричности участка списка
                    bool isSymmetric = CheckSymmetry(list, i, j);
                    Console.WriteLine($"Участок списка с индексов {i} по {j} " + (isSymmetric ? "симметричен." : "не симметричен."));
                    break;

                case 3:  // Задание 3
                         // Пример названий шоколадок
                    List<string> chocolateNames = new List<string>
                    {
                        "Шоколад Milka", "Шоколад Dove", "Шоколад Alpen Gold", "Шоколад Бабаевский", "Шоколад Mars"
                    };

                    // Пример предпочтений сладкоежек
                    List<HashSet<string>> preferences = new List<HashSet<string>>
                    {
                        new HashSet<string> { "Шоколад Milka", "Шоколад Dove" }, // Предпочтения 1-й сладкоежки
                        new HashSet<string> { "Шоколад Milka" }, // Предпочтения 2-й сладкоежки
                        new HashSet<string> { "Шоколад Milka", "Шоколад Dove", "Шоколад Бабаевский" }, // Предпочтения 3-й сладкоежки
                        new HashSet<string> { "Шоколад Milka", "Шоколад Mars" } // Предпочтения 4-й сладкоежки
                    };

                    // Определение шоколадок, которые нравятся всем, некоторым и никому
                    var result = GetChocolatePreferences(chocolateNames, preferences);

                    // Вывод результатов
                    Console.WriteLine("Шоколадки, которые нравятся всем:");
                    foreach (var chocolate in result.Item1)
                    {
                        Console.WriteLine(chocolate);
                    }

                    Console.WriteLine("\nШоколадки, которые нравятся некоторым:");
                    foreach (var chocolate in result.Item2)
                    {
                        Console.WriteLine(chocolate);
                    }

                    Console.WriteLine("\nШоколадки, которые никому не нравятся:");
                    foreach (var chocolate in result.Item3)
                    {
                        Console.WriteLine(chocolate);
                    }
                    break;

                case 4:  // Задание 4
                    string filePath = "text.txt"; // Путь к файлу
                    CreateFile(filePath); // Создаем файл и записываем в него текст
                    string text = ReadFile(filePath); // Читаем текст из файла
                    if (!string.IsNullOrEmpty(text)) // Проверяем, что текст не пустой
                    {
                        int missingLettersCount = CountMissingLetters(text); // Подсчитываем недостающие буквы
                        Console.WriteLine($"Количество букв русского алфавита, не встречающихся в тексте: {missingLettersCount}");
                    }
                    break;

                case 5:  // Задание 5
                    DateTime currentTime = GetCurrentTime(); // Получаем текущее время
                    PassengerManager passengerManager = new PassengerManager(); // Создаем экземпляр менеджера пассажиров

                    // Запрашиваем количество пассажиров
                    Console.WriteLine("Введите количество пассажиров (от 3 до 1000):");
                    int n;
                    while (!int.TryParse(Console.ReadLine(), out n) || n < 3 || n > 1000)
                    {
                        // Проверяем корректность введенного количества
                        Console.WriteLine("Некорректное значение. Пожалуйста, введите число от 10 до 1000.");
                    }

                    // Вводим данные о пассажирах
                    passengerManager.InputPassengerData(n);
                    // Получаем список пассажиров, которые должны освободить ячейки
                    List<Passenger> duePassengers = passengerManager.GetDuePassengers(currentTime);

                    // Выводим список пассажиров
                    Console.WriteLine("Пассажиры, которые должны освободить ячейки в ближайшие 2 часа:");
                    if (duePassengers.Any())
                    {
                        foreach (var passenger in duePassengers)
                        {
                            // Форматируем вывод времени освобождения
                            Console.WriteLine($"{passenger.LastName} - Время освобождения: {passenger.ReleaseTime:HH:mm}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Нет пассажиров, обязанных освободить ячейки в ближайшие 2 часа.");
                    }

                    // Сохраняем данные о пассажирах в файл
                    passengerManager.SaveDataToFile("passengers.xml");
                    break;
            }
        }

        // Задание 1
        // Метод для ввода списка с клавиатуры
        private static List<string> InputList(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            // Проверка на пустой ввод
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: список не может быть пустым.");
                return new List<string>(); // Возвращаем пустой список
            }

            // Разделяем ввод на элементы по пробелу и добавляем в список
            string[] elements = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>();

            foreach (var element in elements)
            {
                string trimmedElement = element.Trim();
                if (!string.IsNullOrWhiteSpace(trimmedElement))
                {
                    list.Add(trimmedElement);
                }
            }

            // Проверка на пустоту списка после обработки
            if (list.Count == 0)
            {
                Console.WriteLine("Ошибка: список не может быть пустым.");
            }

            return list;
        }

        // Метод для формирования списка L
        private static List<string> CreateList(List<string> L1, List<string> L2)
        {
            HashSet<string> uniqueElements = new HashSet<string>(L1);
            uniqueElements.ExceptWith(L2); // Удаляем элементы, найденные в L2

            return new List<string>(uniqueElements); // Возвращаем список уникальных элементов
        }


        // Задание 2
        // Метод для ввода элементов в список
        private static void InputElements(LinkedList<int> list)
        {
            Console.WriteLine("Введите элементы списка (нажмите Enter без ввода для завершения):");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) // Проверяем, пустой ли ввод
                    break;

                if (int.TryParse(input, out int number))
                {
                    list.AddLast(number);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                }
            }
        }

        // Метод для проверки симметричности участка списка
        private static bool CheckSymmetry(LinkedList<int> list, int i, int j)
        {
            LinkedListNode<int> startNode = GetNodeAtIndex(list, i);
            LinkedListNode<int> endNode = GetNodeAtIndex(list, j);

            while (startNode != endNode && startNode != null && endNode != null && startNode.Next != endNode)
            {
                if (startNode.Value != endNode.Value)
                {
                    return false; // Если значения не равны, участок не симметричен
                }

                startNode = startNode.Next; // Перемещаемся к следующему элементу
                endNode = endNode.Previous; // Перемещаемся к предыдущему элементу
            }

            return true; // Если все значения равны, участок симметричен
        }

        // Вспомогательный метод для получения узла по индексу
        private static LinkedListNode<int> GetNodeAtIndex(LinkedList<int> list, int index)
        {
            LinkedListNode<int> currentNode = list.First;
            for (int count = 0; count < index && currentNode != null; count++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        // Задание 3
        // Метод для определения предпочтений шоколадок
        private static (HashSet<string>, HashSet<string>, HashSet<string>) GetChocolatePreferences(
            List<string> chocolateNames,
            List<HashSet<string>> preferences)
        {
            HashSet<string> allLike = new HashSet<string>(chocolateNames); // Шоколадки, которые нравятся всем
            HashSet<string> someLike = new HashSet<string>(); // Шоколадки, которые нравятся некоторым
            HashSet<string> noneLike = new HashSet<string>(chocolateNames); // Шоколадки, которые никому не нравятся

            foreach (var preference in preferences)
            {
                // Убираем шоколадки, которые не нравятся всем
                allLike.IntersectWith(preference);
                // Добавляем шоколадки, которые нравятся хотя бы одному
                someLike.UnionWith(preference);
            }

            // Определяем шоколадки, которые никому не нравятся
            noneLike.ExceptWith(someLike);

            return (allLike, someLike, noneLike);
        }


        // Задание 4
        private static void CreateFile(string filePath)
        {
            try
            {
                Console.WriteLine("Введите текст на русском языке (без чисел и специальных символов, английские буквы игнорируются):");
                string input = Console.ReadLine(); // Читаем ввод пользователя
                ValidateInput(input); // Проверяем ввод на корректность

                File.WriteAllText(filePath, input); // Записываем текст в файл
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
            }
        }

        private static string ReadFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath); // Читаем текст из файла
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return string.Empty; // Возвращаем пустую строку в случае ошибки
            }
        }

        private static int CountMissingLetters(string text)
        {
            // Приводим текст к нижнему регистру и создаем HashSet для хранения уникальных букв
            HashSet<char> lettersInText = new HashSet<char>(text.ToLower().Where(c => IsRussianLetter(c)));

            // Русский алфавит
            HashSet<char> russianAlphabet = new HashSet<char>("абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray());

            // Находим недостающие буквы
            russianAlphabet.ExceptWith(lettersInText);
            return russianAlphabet.Count; // Возвращаем количество недостающих букв
        }

        private static bool IsRussianLetter(char c)
        {
            // Проверяем, является ли символ русской буквой
            return (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я');
        }

        private static void ValidateInput(string input)
        {
            // Проверяем, что ввод содержит только буквы и пробелы
            if (string.IsNullOrWhiteSpace(input) || input.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
            {
                throw new ArgumentException("Ввод должен содержать только буквы русского алфавита и пробелы.");
            }
        }


        // Задание 5
        private static DateTime GetCurrentTime()
        {
            DateTime currentTime;
            while (true)
            {
                Console.WriteLine("Введите текущее время в формате ЧЧ:ММ:");
                string input = Console.ReadLine();

                // Проверяем корректность формата времени
                if (DateTime.TryParse(input, out currentTime))
                {
                    return currentTime; // Возвращаем корректное время
                }

                // Сообщаем об ошибке ввода
                Console.WriteLine("Некорректный формат времени. Пожалуйста, используйте формат ЧЧ:ММ.");
            }
        }

    }
}
