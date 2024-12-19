using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab_5
{
    // Класс Валюты
    internal class Currency
    {
        private int _id; // Уникальный идентификатор валюты
        private string _code; // Код валюты (например, USD)
        private string _name; // Наименование валюты (например, Доллар США)

        // Конструктор класса Currency
        public Currency(int id, string code, string name)
        {
            _id = id;
            _code = code;
            _name = name;
        }

        // Свойства для доступа к данным
        public int ID { get { return _id; } set { _id = value; } }
        public string Code { get { return _code; } set { _code = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        // Метод для вывода информации о валюте в строковом формате
        public override string ToString()
        {
            return $"ID: {_id}, Код: {_code}, Наименование: {_name}";
        }
    }
}
