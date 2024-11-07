using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания от 1 до 8");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    //Задание 1
                    try
                    {
                        // Запрос размера матрицы от пользователя
                        Console.Write("Введите количество строк (n) для матрицы с вводом значений: ");
                        int rows = int.Parse(Console.ReadLine());
                        Console.Write("Введите количество столбцов (m) для матрицы с вводом значений: ");
                        int cols = int.Parse(Console.ReadLine());

                        // Создание матрицы с вводом значений
                        Console.WriteLine("Создание матрицы с вводом значений (n x m):");
                        Matrix userMatrix = new Matrix(rows, cols);
                        Console.WriteLine("Введенная матрица:");
                        userMatrix.PrintMatrix();

                        // Запрос размера для матрицы с случайными числами
                        Console.Write("Введите размер (n) для матрицы с случайными числами (n x n): ");
                        int randomSize = int.Parse(Console.ReadLine());

                        // Создание матрицы с случайными числами
                        Console.WriteLine("Создание матрицы с случайными числами (n x n):");
                        Matrix randomMatrix = new Matrix(randomSize);
                        Console.WriteLine("Случайная матрица:");
                        randomMatrix.PrintMatrix();

                        // Запрос размера для спиральной матрицы
                        Console.Write("Введите размер (n) для спиральной матрицы (n x n): ");

                        // Создание спиральной матрицы
                        Console.WriteLine("Создание спиральной матрицы (n x n):");
                        Matrix spiralMatrix = new Matrix(5, true);
                        Console.WriteLine("Спиральная матрица:");
                        spiralMatrix.PrintMatrix();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;

                case 2: //Задание 2
                    Console.Write("Введите количество строк: ");
                    int n;
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("Ошибка ввода! Пожалуйста, введите положительное целое число.");
                    }

                    Console.Write("Введите количество столбцов: ");
                    int m;
                    while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
                    {
                        Console.WriteLine("Ошибка ввода! Пожалуйста, введите положительное целое число.");
                    }

                    Matrix matrix = new Matrix(n, m);

                    Console.WriteLine("Введенный массив:");
                    matrix.PrintMatrix();

                    if (matrix.CanSortRows())
                    {
                        Console.WriteLine("Можно отсортировать каждую строку в строго возрастающем порядке.");
                    }
                    else
                    {
                        Console.WriteLine("Нельзя отсортировать каждую строку в строго возрастающем порядке.");
                    }
                    break;

                case 3: //Задание 3
                    Matrix_3 program = new Matrix_3(0, 0); // Создаем экземпляр класса для доступа к нестатическим методам
                    int rowsA, columnsA, rowsB, columnsB, rowsC, columnsC;
                    // Ввод размерности матрицы A
                    Console.WriteLine("Введите размерность матрицы A:");
                    rowsA = program.GetPositiveInteger("Количество строк: ");
                    columnsA = program.GetPositiveInteger("Количество столбцов: ");
                    // Ввод размерности матрицы B
                    Console.WriteLine("Введите размерность матрицы B:");
                    rowsB = program.GetPositiveInteger("Количество строк: ");
                    columnsB = program.GetPositiveInteger("Количество столбцов: ");
                    // Ввод размерности матрицы C
                    Console.WriteLine("Введите размерность матрицы C:");
                    rowsC = program.GetPositiveInteger("Количество строк: ");
                    columnsC = program.GetPositiveInteger("Количество столбцов: ");
                    // Проверка совместимости матриц для операции
                    if (columnsA != rowsB || rowsB != rowsC || rowsC != rowsA || columnsC != columnsB)
                    {
                        Console.WriteLine("Размерности матриц не позволяют выполнить заданное матричное выражение.");
                        return;
                    }
                    // Создание матриц A, B и C
                    Matrix_3 A = new Matrix_3(rowsA, columnsA);
                    Matrix_3 B = new Matrix_3(rowsB, columnsB);
                    Matrix_3 C = new Matrix_3(rowsC, columnsC);
                    // Заполнение матриц A, B и C
                    A.FillMatrix("A");
                    B.FillMatrix("B");
                    C.FillMatrix("C");
                    // Вычисление матричного выражения ((B(транспонированная) * A) - (4 * C)) + B
                    Matrix_3 result = ((B.Transpose() * A) - (C * 4)) + B;
                    // Вывод результата
                    Console.WriteLine("Результат матричного выражения:");
                    Console.WriteLine(result);
                    break;

                case 4: //Задание 4
                    string filePath = "data.bin"; // Путь к бинарному файлу
                    int count = 100; // Количество случайных чисел для записи

                    // Заполнение бинарного файла случайными данными
                    BinaryFileHandler.FillBinaryFile(filePath, count);

                    // Нахождение наибольшего значения модулей компонент с нечетными номерами
                    int maxOddIndexModule = BinaryFileHandler.FindMaxOddIndexModule(filePath);
                    Console.WriteLine($"Наибольшее значение модулей компонент с нечетными номерами: {maxOddIndexModule}");
                    break;

                case 5: //Задание 5
                    string filePath1 = "toys.xml"; // Путь к файлу

                    // Заполняем файл игрушками
                    BinaryFileHandler.FillToyFile(filePath1);

                    // Получаем названия игрушек для детей 4-5 лет
                    List<string> toysForAge = BinaryFileHandler.GetToysForAgeRange(filePath1, 4, 5);

                    // Выводим названия игрушек
                    Console.WriteLine("Игрушки для детей 4-5 лет:");
                    foreach (var toy in toysForAge)
                    {
                        Console.WriteLine(toy);
                    }
                    break;

                case 6: //Задание 6
                    string filePath2 = "numbers.txt"; // Путь к файлу
                    int numberOfElements;

                    // Запрашиваем у пользователя количество элементов
                    while (true)
                    {
                        Console.Write("Введите количество чисел для записи в файл (должно быть больше 1): ");
                        string input = Console.ReadLine();

                        // Проверяем, является ли введенное значение числом и больше ли оно 1
                        if (int.TryParse(input, out numberOfElements) && numberOfElements > 1)
                        {
                            break; // Выход из цикла, если ввод корректный
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: введите положительное число больше 1.");
                        }
                    }

                    // Заполняем файл случайными числами
                    BinaryFileHandler.FillFileWithRandomNumbers(filePath2, numberOfElements);
                    Console.WriteLine($"Файл '{filePath2}' заполнен {numberOfElements} случайными числами.");

                    // Выводим содержимое файла
                    BinaryFileHandler.PrintFileContents(filePath2);

                    // Вычисляем среднее арифметическое
                    double average = BinaryFileHandler.CalculateAverage(filePath2);
                    Console.WriteLine($"Среднее арифметическое элементов файла: {average}");
                    break;

                case 7: //Задание 7

                    string filePath3 = "numbers1.txt"; // Путь к файлу

                    int numberOfLines = 0;
                    int numbersPerLine = 0;

                    // Запрашиваем у пользователя количество строк с проверкой ввода
                    while (true)
                    {
                        Console.Write("Введите количество строк (положительное число больше 0): ");
                        if (int.TryParse(Console.ReadLine(), out numberOfLines) && numberOfLines > 0)
                        {
                            break; // Ввод корректен, выходим из цикла
                        }
                        Console.WriteLine("Ошибка: введите положительное целое число больше 0.");
                    }

                    // Запрашиваем у пользователя количество чисел в строке с проверкой ввода
                    while (true)
                    {
                        Console.Write("Введите количество чисел в строке (положительное число больше 0): ");
                        if (int.TryParse(Console.ReadLine(), out numbersPerLine) && numbersPerLine > 0)
                        {
                            break; // Ввод корректен, выходим из цикла
                        }
                        Console.WriteLine("Ошибка: введите положительное целое число больше 0.");
                    }

                    // Заполняем файл случайными числами
                    BinaryFileHandler.FillFileWithRandomNumbers(filePath3, numberOfLines, numbersPerLine);
                    Console.WriteLine("Файл успешно заполнен случайными числами.");

                    // Выводим содержимое файла в консоль
                    BinaryFileHandler.PrintFileContents(filePath3);

                    // Вычисляем произведение нечётных чисел
                    long product = BinaryFileHandler.CalculateProductOfOddNumbers(filePath3);
                    Console.WriteLine($"Произведение нечётных чисел: {product}");
                    break;

                case 8: //Задание 8
                    string sourceFilePath = "source.txt"; // Путь к исходному файлу
                    string destinationFilePath = "destination.txt"; // Путь к файлу назначения

                    int numberOfLines1;

                    // Запрос количества строк у пользователя с проверкой
                    do
                    {
                        Console.Write("Введите количество строк для генерации (положительное число больше 0): ");
                    } while (!int.TryParse(Console.ReadLine(), out numberOfLines1) || numberOfLines1 <= 0);

                    // Заполнение исходного файла случайными данными
                    BinaryFileHandler.FillFileWithRandomData(sourceFilePath, numberOfLines1);

                    // Чтение и вывод содержимого исходного файла в консоль
                    Console.WriteLine("Содержимое исходного файла (source.txt):");
                    Console.WriteLine(File.ReadAllText(sourceFilePath));

                    // Копирование строк без букв в другой файл
                    BinaryFileHandler.CopyLinesWithoutLetters(sourceFilePath, destinationFilePath);

                    // Чтение и вывод содержимого файла назначения в консоль
                    Console.WriteLine("Содержимое файла назначения (строки без букв из destination.txt):");
                    Console.WriteLine(File.ReadAllText(destinationFilePath));
                    break;
            }
            
            
        }
    }
}
