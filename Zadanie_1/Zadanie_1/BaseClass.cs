using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class BaseClass
    {
        public bool field1; // Первое логическое поле
        public bool field2; // Второе логическое поле

        // Конструктор, принимающий два логических значения
        public BaseClass(bool f1, bool f2)
        {
            field1 = f1;
            field2 = f2;
        }

        // Конструктор копирования
        public BaseClass(BaseClass other)
        {
            field1 = other.field1;
            field2 = other.field2;
        }

        // Метод, вычисляющий отрицания полей
        public void NegateFields()
        {
            field1 = !field1;
            field2 = !field2;
        }

        // Переопределение метода ToString() для формирования строки из полей класса
        public override string ToString()
        {
            return $"BaseClass: field1 = {field1}, field2 = {field2}";
        }
    }
}


