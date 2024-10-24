using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод значений для базового класса
            Console.WriteLine("Введите значения для базового класса (true/false):");
            bool f1 = Convert.ToBoolean(Console.ReadLine());
            bool f2 = Convert.ToBoolean(Console.ReadLine());

            // Создание объекта базового класса
            BaseClass originalObject = new BaseClass(f1, f2);
            Console.WriteLine("Оригинальный объект:");
            Console.WriteLine(originalObject);

            // Создание копии базового объекта
            BaseClass copiedObject = new BaseClass(originalObject);
            Console.WriteLine("Скопированный объект:");
            Console.WriteLine(copiedObject);

            // Отрицание полей сопированного объекта
            copiedObject.NegateFields();
            Console.WriteLine("После отрицания скопированного объекта:");
            Console.WriteLine(copiedObject);

            // Ввод значений для дочернего класса
            Console.WriteLine("Введите значения для дочернего класса (true/false) и размеры (длина и ширина):");
            f1 = Convert.ToBoolean(Console.ReadLine());
            f2 = Convert.ToBoolean(Console.ReadLine());
            double length = Convert.ToDouble(Console.ReadLine());
            double width = Convert.ToDouble(Console.ReadLine());

            // Создание объекта дочернего класса
            DerivedClass derivedObject = new DerivedClass(f1, f2, length, width);
            Console.WriteLine("Дочерний класс:");
            Console.WriteLine(derivedObject);
        }
    }
}
