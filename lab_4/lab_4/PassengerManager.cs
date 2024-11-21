using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab_4
{
    // Класс для управления пассажирами
    public class PassengerManager
    {
        private SortedList<string, Passenger> passengers = new SortedList<string, Passenger>(); // Список пассажиров
        private HashSet<string> lastNames = new HashSet<string>(); // Для проверки уникальности фамилий

        // Метод для ввода данных о пассажирах
        public void InputPassengerData(int count)
        {
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Введите данные о пассажире {i + 1} в формате '<Фамилия> <Время освобождения ячейки (ЧЧ:ММ)>' :");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(' '); // Разделяем ввод на части

                    // Проверяем корректность введенных данных
                    if (IsValidInput(parts))
                    {
                        // Преобразуем время освобождения в DateTime
                        var releaseTime = DateTime.Today.Add(TimeSpan.Parse(parts[1]));
                        // Добавляем пассажира в список
                        if (!passengers.ContainsKey(parts[0])) // Проверяем уникальность фамилии
                        {
                            passengers.Add(parts[0], new Passenger { LastName = parts[0], ReleaseTime = releaseTime });
                            lastNames.Add(parts[0]); // Добавляем фамилию в множество для проверки уникальности
                            break; // Выходим из цикла, если ввод корректен
                        }
                        else
                        {
                            Console.WriteLine("Пассажир с такой фамилией уже существует. Пожалуйста, введите другую фамилию.");
                        }
                    }

                    // Сообщаем об ошибке ввода
                    Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
                }
            }
        }

        // Метод для проверки корректности ввода
        private bool IsValidInput(string[] parts)
        {
            return parts.Length == 2 && // Должно быть ровно 2 части
                   !string.IsNullOrWhiteSpace(parts[0]) && // Фамилия не должна быть пустой
                   Regex.IsMatch(parts[0], @"^[A-Za-zА-Яа-яЁё\s-]{1,20}$") && // Проверка фамилии с помощью регулярного выражения
                   TimeSpan.TryParse(parts[1], out _); // Проверка корректности времени
        }

        // Метод для получения списка пассажиров, которые должны освободить ячейки в ближайшие 2 часа
        public List<Passenger> GetDuePassengers(DateTime currentTime)
        {
            DateTime twoHoursLater = currentTime.AddHours(2); // Время через 2 часа
            // Фильтруем и сортируем пассажиров по времени освобождения
            return passengers.Values
                .Where(p => p.ReleaseTime > currentTime && p.ReleaseTime <= twoHoursLater)
                .OrderBy(p => p.ReleaseTime)
                .ToList();
        }

        // Метод для сохранения данных о пассажирах в XML-файл
        public void SaveDataToFile(string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>)); // Создаем сериализатор для списка пассажиров
                using (FileStream fs = new FileStream(fileName, FileMode.Create)) // Открываем файл для записи
                {
                    serializer.Serialize(fs, passengers.Values.ToList()); // Сериализуем данные и записываем в файл
                }
                Console.WriteLine($"Данные о пассажирах сохранены в файл '{fileName}'.");
            }
            catch (Exception ex)
            {
                // Обработка ошибок при сохранении
                Console.WriteLine($"Ошибка при сохранении данных в файл: {ex.Message}");
            }
        }
    }
}