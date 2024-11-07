using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class Matrix_3
    {
        private int[,] data; // Двумерный массив для хранения элементов матрицы
        private int rows;     // Количество строк
        private int columns;  // Количество столбцов
                              // Конструктор для создания матрицы заданного размера
        public Matrix_3(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            data = new int[rows, columns]; // Инициализация массива
        }
        // Метод для заполнения матрицы элементами
        public void FillMatrix(string matrixName)
        {
            Console.WriteLine($"Заполнение матрицы {matrixName}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    while (true)
                    {
                        Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                        if (int.TryParse(Console.ReadLine(), out data[i, j]))
                            break; // Выход из цикла, если ввод корректен
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    }
                }
            }
        }
        // Перегрузка оператора вычитания матриц
        public static Matrix_3 operator -(Matrix_3 m1, Matrix_3 m2)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
                throw new InvalidOperationException("Невозможно вычесть матрицы с несовместимыми размерами.");

            Matrix_3 result = new Matrix_3(m1.rows, m1.columns);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    result.data[i, j] = m1.data[i, j] - m2.data[i, j];
                }
            }
            return result;
        }
        // Перегрузка оператора сложения матриц
        public static Matrix_3 operator +(Matrix_3 m1, Matrix_3 m2)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
                throw new InvalidOperationException("Невозможно сложить матрицы с несовместимыми размерами.");
            Matrix_3 result = new Matrix_3(m1.rows, m1.columns);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.columns; j++)
                {
                    result.data[i, j] = m1.data[i, j] + m2.data[i, j];
                }
            }
            return result;
        }

        // Перегрузка оператора умножения матриц
        public static Matrix_3 operator *(Matrix_3 m1, Matrix_3 m2)
        {
            if (m1.columns != m2.rows)
                throw new InvalidOperationException("Невозможно умножить матрицы с несовместимыми размерами.");
            Matrix_3 result = new Matrix_3(m1.rows, m2.columns);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m2.columns; j++)
                {
                    result.data[i, j] = 0;
                    for (int k = 0; k < m1.columns; k++)
                    {
                        result.data[i, j] += m1.data[i, k] * m2.data[k, j];
                    }
                }
            }
            return result;
        }

        // Перегрузка оператора умножения на скаляр
        public static Matrix_3 operator *(Matrix_3 m, int scalar)
        {
            Matrix_3 result = new Matrix_3(m.rows, m.columns);
            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    result.data[i, j] = m.data[i, j] * scalar;
                }
            }
            return result;
        }

        // Метод для транспонирования матрицы
        public Matrix_3 Transpose()
        {
            Matrix_3 transposed = new Matrix_3(columns, rows); // Создание транспонированной матрицы
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    transposed.data[j, i] = data[i, j]; // Перестановка индексов
                }
            }
            return transposed;
        }

        // Переопределение метода ToString для отображения матрицы
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += data[i, j] + "\t"; // Форматирование для табличного отображения
                }
                result += "\n"; // Переход на новую строку
            }
            return result;
        }

        // Метод для получения положительного целого числа
        public int GetPositiveInteger(string message)
        {
            int number;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                    return number; // Возвращаем число, если ввод корректен
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
            }
        }
        
    }
}
