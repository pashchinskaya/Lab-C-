using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    // Интерфейс для объектов, которые могут издавать звук
    public interface ISoundable
    {
        void MakeSound(); // Метод для издания звука
    }

    internal class Monkey : ISoundable
    {
        private string name; // Имя обезьяны

        // Конструктор класса, принимающий имя обезьяны
        public Monkey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя обезьяны не может быть пустым.");
            }

            this.name = name;
        }

        // Метод для издания звука
        public void MakeSound()
        {
            Console.WriteLine($"{name}: уа-уа!");
        }
    }
}
