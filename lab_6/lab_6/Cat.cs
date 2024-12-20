using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    internal class Cat : ISoundable
    {
        private string name; // Имя кота

        // Конструктор класса, принимающий имя кота
        public Cat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя кота не может быть пустым.");
            }

            this.name = name;
        }

        // Метод для издания звука (мяукание)
        public void Meow()
        {
            Console.WriteLine($"{name}: мяу!");
        }

        // Реализация метода интерфейса ISoundable
        public void MakeSound()
        {
            Meow(); // Вызов метода мяуканья
        }


    }
}
