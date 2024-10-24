using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class DerivedClass : BaseClass
    {
        public double Length { get; set; } // Длина
        public double Width { get; set; } // Ширина

        // Конструктор, принимающий значения полей базового класса и дочерних полей
        public DerivedClass(bool f1, bool f2, double length, double width)
            : base(f1, f2)
        {
            Length = length;
            Width = width;
        }

        // Метод для вычисления периметра
        public double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }

        // Переопределение метода ToString() для дочернего класса
        public override string ToString()
        {
            return $"{base.ToString()}, Length = {Length}, Width = {Width}, Perimeter = {CalculatePerimeter()}";
        }
    }
}
