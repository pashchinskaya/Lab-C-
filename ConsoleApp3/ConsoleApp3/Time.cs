using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Time
    {
        // Поля
        private byte minutes;
        private byte hours;

        // Свойства
        // Проверка на ввод значения для часов
        public byte Hours
        {
            get { return hours; }
            set
            {
                if (value >= 0 && value < 24)
                    hours = value;
                else
                    throw new ArgumentOutOfRangeException("Введеные часы должны быть от 0 до 23");
            }
        }

        // Проверка на ввод значения для минут
        public byte Minutes
        {
            get { return minutes; }
            set
            {
                if (value >= 0 && value < 60)
                    minutes = value;
                else
                    throw new ArgumentOutOfRangeException("Введеные минуты должны быть от 0 до 60");
            }
        }

        // Конструктор
        public Time(byte hours, byte minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        // Перегрузка ToString()
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}";
        }

        // Метод для вычитания минут
        public Time SubtractMinutes(uint minutesToSubtract)
        {
            int totalMinutes = Hours * 60 + Minutes - (int)minutesToSubtract;
            if (totalMinutes < 0)
            {
                // Переход на предыдущие сутки
                totalMinutes += 24 * 60; // Добавляем 24 часа в минутах
            }

            byte newHours = (byte)(totalMinutes / 60);
            byte newMinutes = (byte)(totalMinutes % 60);
            return new Time(newHours, newMinutes);
        }

        // Унарная операция: обнуление часов и минут
        public static Time operator -(Time t)
        {
            return new Time(0, 0);
        }

        // Унарная операция: обнуление минут
        public Time ResetMinutes()
        {
            return new Time(Hours, 0);
        }

        // Операция приведения типа: неявная (byte)
        public static implicit operator byte(Time t)
        {
            return t.Hours; // Возвращаем только часы
        }

        // Операция приведения типа: явная (bool)
        public static explicit operator bool(Time t)
        {
            return t.Hours != 0 || t.Minutes != 0; // true, если часы или минуты не равны нулю
        }

        // Бинарная операция: ==
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Hours == t2.Hours && t1.Minutes == t2.Minutes;
        }

        // Бинарная операция: !=
        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2); // Используем перегрузку ==
        }

        // Переопределение Equals и GetHashCode для корректной работы с == и !=
        public override bool Equals(object obj)
        {
            if (obj is Time t)
            {
                return this == t;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Hours, Minutes).GetHashCode();
        }
    }
}
