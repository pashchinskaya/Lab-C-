using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    // Интерфейс для дробей
    public interface IFraction
    {
        double GetValue(); // Метод для получения вещественного значения дроби
        void SetNumerator(int numerator);  // Метод для числителя
        void SetDenominator(int denominator); // Метод для знаменателя
    }

    // Класс Дробь
    internal class Fraction : ICloneable, IFraction
    {
        private int numerator; // Числитель дроби
        private int denominator; // Знаменатель дроби
        private double? cachedValue; // Кэшированное значение дроби для оптимизации
        // В данном случае double? означает, что переменная cachedValue может содержать либо значение типа double, либо null

        // Дробь
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть нулем.");
            }

            // Приведение дроби к стандартному виду
            if (denominator < 0)
            {
                this.numerator = -numerator;
                this.denominator = -denominator;
            }
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            //Reduce(); // Сокращаем дробь при создании
            cachedValue = null; // Сбрасываем кэш
        }

        // Переопределение метода ToString() для представления дроби в виде строки
        public override string ToString()
        {
            return $"{numerator}/{denominator}"; // Возвращаем строковое представление дроби в формате "числитель/знаменатель"
        }

        // Перегрузка сложения
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            if (f1.denominator == f2.denominator)
            {
                // Если знаменатели одинаковые, просто складываем числители
                int newNumerator = f1.numerator + f2.numerator;
                return new Fraction(newNumerator, f1.denominator);
            }
            else
            {
                // Если знаменатели разные, приводим к общему знаменателю
                int newNumerator = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
                int newDenominator = f1.denominator * f2.denominator;
                return new Fraction(newNumerator, newDenominator);
            }
        }

        // Перегрузка вычитания
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            if (f1.denominator == f2.denominator)
            {
                // Если знаменатели одинаковые, просто вычитаем числители
                int newNumerator = f1.numerator - f2.numerator;
                return new Fraction(newNumerator, f1.denominator);
            }
            else
            {
                // Если знаменатели разные, приводим к общему знаменателю
                int newNumerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
                int newDenominator = f1.denominator * f2.denominator;
                return new Fraction(newNumerator, newDenominator);
            }
        }

        // Перегрузка умножения
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int newNumerator = f1.numerator * f2.numerator;
            int newDenominator = f1.denominator * f2.denominator;
            return new Fraction(newNumerator, newDenominator); 
        }

        // Перегрузка деления
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.numerator == 0)  // Проверяем, является ли числитель второго дробного числа равным нулю
            {
                throw new DivideByZeroException("Деление на ноль.");
            }
            int newNumerator = f1.numerator * f2.denominator; // Вычисляем новый числитель: умножаем числитель первой дроби на знаменатель второй дроби
            int newDenominator = f1.denominator * f2.numerator; // Вычисляем новый знаменатель: умножаем знаменатель первой дроби на числитель второй дроби
            return new Fraction(newNumerator, newDenominator);
        }

        // Перегрузка операторов для сравнения
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if (ReferenceEquals(f1, f2)) return true; // Если оба ссылаются на один объект
            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null)) return false; // Если один из них null
            return f1.numerator == f2.numerator && f1.denominator == f2.denominator; // Сравнение по числителям и знаменателям
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }


        // Переопределение метода Equals для сравнения объектов типа Fraction
        public override bool Equals(object obj)
        {
            // Проверяем, является ли переданный объект другим экземпляром Fraction
            if (obj is Fraction other)
            {
                // Сравниваем числители и знаменатели текущего объекта и другого объекта
                return this.numerator == other.numerator && this.denominator == other.denominator;
            }
            // Если объект не является экземпляром Fraction, возвращаем false
            return false;
        }


        // Переопределение метода GetHashCode для генерации хэш-кода для объектов типа Fraction
        public override int GetHashCode()
        {
            unchecked // Позволяет избежать переполнения при вычислении хэш-кода
            {
                // Генерация хэш-кода на основе числителя и знаменателя
                // Используем 397 как произвольное простое число для уменьшения вероятности коллизий
                return (numerator * 397) ^ denominator; // Используем побитовый XOR для комбинирования значений
            }
        }


        // Метод для сравнения текущей дроби с другой дробью
        public int CompareTo(Fraction other)
        {
            // Если другой объект null, считаем, что текущий объект больше
            if (other == null) return 1;
            // Сравниваем дроби, приводя их к общему знаменателю
            return (this.numerator * other.denominator).CompareTo(other.numerator * this.denominator);
        }

        // Метод для клонирования текущего объекта Fraction
        public object Clone()
        {
            // Создаем новый экземпляр Fraction с теми же числителем и знаменателем
            return new Fraction(numerator, denominator);
        }

        // Метод для получения значения дроби в виде double
        public double GetValue()
        {
            // Проверяем, есть ли уже кэшированное значение
            if (!cachedValue.HasValue)
            {
                // Если нет, вычисляем значение и кэшируем его
                cachedValue = (double)numerator / denominator;
            }
            // Возвращаем кэшированное значение
            return cachedValue.Value;
        }

        // Метод для установки числителя дроби
        public void SetNumerator(int numerator)
        {
            this.numerator = numerator; // Обновляем числитель
            //Reduce(); // Сокращаем дробь при изменении
            cachedValue = null; // Сбрасываем кэш, так как значение изменилось
        }

        // Метод для установки знаменателя дроби
        public void SetDenominator(int denominator)
        {
            // Проверяем, что знаменатель не равен нулю
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть нулем."); // Генерируем исключение, если знаменатель нулевой
            }
            this.denominator = denominator; // Обновляем знаменатель
            //Reduce(); // Сокращаем дробь при изменении
            cachedValue = null; // Сбрасываем кэш, так как значение изменилось
        }


        /*
        private void Reduce()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            // Убедимся, что знаменатель положительный
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }
        

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        */
    }
}
