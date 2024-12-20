using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    internal class SoundTester
    {
        // Метод, принимающий набор объектов, которые могут издавать звук, и вызывающий их звуки
        public static void MakeThemSound(List<ISoundable> soundables)
        {
            foreach (var soundable in soundables)
            {
                soundable.MakeSound(); // Вызываем издание звука для каждого объекта
            }
        }
    }
}
