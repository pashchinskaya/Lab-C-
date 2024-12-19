using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using System.IO;

namespace lab_5
{
    // Класс Logger для ведения журнала логирования
    internal class Logger
    {
        // Приватное поле для хранения пути к файлу журнала
        private string _logFilePath;

        // Конструктор класса Logger, принимающий путь к файлу журнала
        public Logger(string logFilePath)
        {
            // Инициализация поля _logFilePath значением параметра logFilePath
            _logFilePath = logFilePath;
        }

        // Метод для записи сообщения в файл журнала
        public void Log(string message)
        {
            // Формирование строки записи с текущей датой и временем и сообщением
            string logEntry = $"{DateTime.Now}: {message}";

            // Добавление записи в файл журнала, создавая новую строку после каждой записи
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }
    }

}
