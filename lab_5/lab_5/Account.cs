using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab_5
{
    // Класс счета
    internal class Account
    {
        private int _id; // Уникальный идентификатор счета
        private string _fio; // ФИО владельца счета
        private DateTime _openingDate; // Дата открытия счета

        // Конструктор класса Account
        public Account(int id, string fio, DateTime openingDate)
        {
            _id = id;
            _fio = fio;
            _openingDate = openingDate;
        }

        // Свойства для доступа к данным
        public int ID { get { return _id; } set { _id = value; } }
        public string FIO { get { return _fio; } set { _fio = value; } }
        public DateTime OpeningDate { get { return _openingDate; } set { _openingDate = value; } }

        // Метод для вывода информации о счете в строковом формате
        public override string ToString()
        {
            return $"ID: {_id}, ФИО: {_fio}, Дата открытия: {_openingDate.ToShortDateString()}";
        }
    }
}
