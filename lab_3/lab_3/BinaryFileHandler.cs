using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace lab_3
{
    public static class BinaryFileHandler
    {   

        
        //4 задание
        // Метод для заполнения бинарного файла случайными данными
        public static void FillBinaryFile(string filePath, int count)
        {
            try
            {
                Random random = new Random();

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    for (int i = 0; i < count; i++)
                    {
                        // Генерация случайного числа
                        int randomNumber = random.Next(-1000, 1000);
                        // Запись числа в бинарный файл
                        writer.Write(randomNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при заполнении файла: {ex.Message}");
            }
        }

        // Метод для нахождения наибольшего значения модулей компонент с нечетными номерами
        public static int FindMaxOddIndexModule(string filePath)
        {
            int maxModule = int.MinValue; // Начальное значение для максимума
            int index = 1; // Индекс для отслеживания номера компонента

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        int number = reader.ReadInt32(); // Чтение числа из бинарного файла

                        // Проверяем, является ли индекс нечетным
                        if (index % 2 != 0)
                        {
                            int module = Math.Abs(number); // Вычисляем модуль числа
                            if (module > maxModule)
                            {
                                maxModule = module; // Обновляем максимум
                            }
                        }

                        index++; // Увеличиваем индекс
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден. Убедитесь, что файл существует.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return maxModule; // Возвращаем найденный максимум
        }




        //5 задание
        [Serializable] // Указываем, что структура может быть сериализована
        public struct Toy
        {
            public string Name; // Название игрушки
            public decimal Price; // Стоимость игрушки
            public int AgeFrom; // Возраст с
            public int AgeTo; // Возраст до
        }

        // Метод для заполнения исходного файла с игрушками
        public static void FillToyFile(string filePath)
        {
            List<Toy> toys = new List<Toy>
        {
            new Toy { Name = "Мягкая игрушка", Price = 500, AgeFrom = 2, AgeTo = 5 },
            new Toy { Name = "Конструктор", Price = 1200, AgeFrom = 4, AgeTo = 8 },
            new Toy { Name = "Кубики", Price = 300, AgeFrom = 1, AgeTo = 3 },
            new Toy { Name = "Настольная игра", Price = 800, AgeFrom = 6, AgeTo = 12 },
            new Toy { Name = "Пазл", Price = 400, AgeFrom = 4, AgeTo = 5 }
        };

            // Сериализация списка игрушек в XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, toys);
            }
        }

        // Метод для получения названий игрушек для детей 4-5 лет
        public static List<string> GetToysForAgeRange(string filePath, int ageFrom, int ageTo)
        {
            List<Toy> toys;

            // Десериализация списка игрушек из XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                toys = (List<Toy>)serializer.Deserialize(stream);
            }

            // Получаем названия игрушек для заданного возрастного диапазона
            List<string> toyNames = new List<string>();
            foreach (var toy in toys)
            {
                if (toy.AgeFrom <= ageTo && toy.AgeTo >= ageFrom)
                {
                    toyNames.Add(toy.Name);
                }
            }

            return toyNames;
        }




        //6 задание
        private static Random random = new Random();

        // Метод для заполнения файла случайными целыми числами
        public static void FillFileWithRandomNumbers(string filePath, int numberOfElements)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < numberOfElements; i++)
                {
                    int randomNumber = random.Next(1, 101); // Генерируем случайное число от 1 до 100
                    writer.WriteLine(randomNumber); // Записываем число в файл
                }
            }
        }

        // Метод для вычисления среднего арифметического элементов файла
        public static double CalculateAverage(string filePath)
        {
            double sum = 0;
            int count = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number)) // Пробуем преобразовать строку в число
                    {
                        sum += number; // Добавляем число к сумме
                        count++; // Увеличиваем счётчик
                    }
                }
            }

            return count > 0 ? sum / count : 0; // Возвращаем среднее, если есть элементы
        }

        // Метод для вывода содержимого файла
        public static void PrintFileContents(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.WriteLine("Содержимое файла:");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line); // Выводим каждую строку файла
                }
            }
        }




        //7 задание
        // Метод для заполнения файла случайными целыми числами
        public static void FillFileWithRandomNumbers(string filePath, int numberOfLines, int numbersPerLine)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    for (int j = 0; j < numbersPerLine; j++)
                    {
                        int randomNumber = random.Next(1, 100); // Случайное число от 1 до 99
                        writer.Write(randomNumber);
                        if (j < numbersPerLine - 1)
                        {
                            writer.Write(" "); // Разделитель между числами
                        }
                    }
                    writer.WriteLine(); // Переход на следующую строку
                }
            }
        }

        // Метод для вычисления произведения нечётных элементов из файла
        public static long CalculateProductOfOddNumbers(string filePath)
        {
            long product = 1;
            bool hasOddNumbers = false; // Флаг для проверки наличия нечётных чисел

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(' '); // Разделяем строку на числа
                    foreach (string numberString in numbers)
                    {
                        if (int.TryParse(numberString, out int number) && number % 2 != 0) // Проверка на нечётность
                        {
                            product *= number; // Умножаем на нечётное число
                            hasOddNumbers = true; // Устанавливаем флаг, если нечётное число найдено
                        }
                    }
                }
            }

            // Если нечётные числа не найдены, возвращаем 0
            return hasOddNumbers ? product : 0;
        }




        //8 задание
        // Метод для заполнения файла случайными данными
        public static void FillFileWithRandomData(string filePath, int numberOfLines)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                // Случайный выбор типа строки: 0 - только буквы, 1 - только цифры, 2 - буквы и цифры
                int stringType = random.Next(0, 3);
                sb.AppendLine(GenerateRandomString(5, stringType));
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        // Метод для генерации случайной строки
        private static string GenerateRandomString(int length, int stringType)
        {
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                char randomChar;

                if (stringType == 0) // Только буквы (английские)
                {
                    randomChar = (char)random.Next('A', 'Z' + 1);
                }
                else if (stringType == 1) // Только цифры
                {
                    randomChar = (char)random.Next('0', '9' + 1);
                }
                else // Буквы (английские) и цифры
                {
                    if (random.Next(0, 2) == 0) // Случайно выбираем буква или цифра
                    {
                        randomChar = (char)random.Next('A', 'Z' + 1);
                    }
                    else
                    {
                        randomChar = (char)random.Next('0', '9' + 1);
                    }
                }

                result.Append(randomChar);
            }

            return result.ToString();
        }

        // Метод для копирования строк без букв в другой файл
        public static void CopyLinesWithoutLetters(string sourceFilePath, string destinationFilePath)
        {
            string[] lines = File.ReadAllLines(sourceFilePath);
            using (StreamWriter writer = new StreamWriter(destinationFilePath))
            {
                foreach (string line in lines)
                {
                    // Проверка, есть ли в строке буквы
                    if (!ContainsLetters(line))
                    {
                        writer.WriteLine(line); // Запись строки в новый файл, если в ней нет букв
                    }
                }
            }
        }

        // Метод для проверки наличия букв в строке
        private static bool ContainsLetters(string line)
        {
            foreach (char c in line)
            {
                if (char.IsLetter(c)) // Проверяем, является ли символ буквой
                {
                    return true; // Если нашли букву, возвращаем true
                }
            }
            return false; // Если букв нет, возвращаем false
        }


    }
}
