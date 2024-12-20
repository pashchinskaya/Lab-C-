using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    // Класс для хранения информации о животном
    internal class AnimalInfo
    {
        public string Name { get; set; } // Имя животного
        public string Type { get; set; } // Тип животного (кот или обезьяна)
        public int SoundCount { get; set; } // Количество звуков, изданных животным

        // Конструктор для инициализации информации о животном
        public AnimalInfo(string name, string type, int soundCount)
        {
            Name = name;
            Type = type;
            SoundCount = soundCount;
        }
    }
}
