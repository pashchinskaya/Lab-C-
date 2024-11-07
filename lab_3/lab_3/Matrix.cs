using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class Matrix
    {   
        //1 задание
        private int[,] _matrix;

        // Конструктор для создания матрицы с заданными размерами и заполнением по столбцам
        public Matrix(int n, int m) 
        {
            ValidateDimensions(n, m);  //n - строки, m - столбцы
            _matrix = new int[n, m];  //_matrix - массив

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Введите элемент [{i},{j}]: ");
                    if (!int.TryParse(Console.ReadLine(), out _matrix[i, j]))
                    {
                        throw new FormatException("Неверный формат ввода.");
                    }
                }
            }
        }

        // Конструктор для создания матрицы n x n, заполненной случайными числами в возрастающем порядке
        public Matrix(int n)
        {
            ValidateDimensions(n, n);
            _matrix = new int[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                int startValue = rnd.Next(100); // Генерируем случайное число для первого элемента строки
                for (int j = 0; j < n; j++)
                {
                    _matrix[i, j] = startValue + j; // Заполняем строку возрастающими числами
                }
            }
        }

        // Конструктор для создания матрицы n x n с заданным шаблоном (спиральное заполнение)
        public Matrix(int n, bool isSpiral)
        {
            ValidateDimensions(n, n);
            _matrix = new int[n, n];

            int value = 1;
            int top = 0, bottom = n - 1, left = 0, right = n - 1;

            while (value <= n * n)
            {
                for (int i = left; i <= right; i++) // Заполняем верхнюю строку
                    _matrix[top, i] = value++;
                top++;

                for (int i = top; i <= bottom; i++) // Заполняем правый столбец
                    _matrix[i, right] = value++;
                right--;

                for (int i = right; i >= left; i--) // Заполняем нижнюю строку
                    _matrix[bottom, i] = value++;
                bottom--;

                for (int i = bottom; i >= top; i--) // Заполняем левый столбец
                    _matrix[i, left] = value++;
                left++;
            }
        }

        // Метод для проверки корректности размеров матрицы
        private void ValidateDimensions(int n, int m)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("Размеры матрицы должны быть положительными числами.");
            }
        }

        // Метод для вывода матрицы на экран
        public void PrintMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }



        //2 задание
        // Метод для проверки, можно ли отсортировать строки в строго возрастающем порядке
        public bool CanSortRows()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                // Создаем временный массив для текущей строки
                int[] n = new int[_matrix.GetLength(1)];
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    n[j] = _matrix[i, j];
                }

                // Сортируем временный массив
                Array.Sort(n);

                // Проверяем, что элементы строго возрастают
                for (int j = 0; j < n.Length - 1; j++)
                {
                    if (n[j] >= n[j + 1])
                    {
                        return false; // Если нашли элементы, которые не строго возрастают
                    }
                }
            }
            return true; // Все строки можно отсортировать в строго возрастающем порядке
        }

       
    }
}
