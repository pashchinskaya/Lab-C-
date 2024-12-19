using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab_5
{
    // Класс курс валют
    internal class CurrencyRate
    {
        private int _id; // Уникальный идентификатор курса валюты
        private int _currencyId; // Идентификатор валюты
        private DateTime _date; // Дата курса
        private double _rate; // Значение курса

        // Конструктор класса CurrencyRate
        public CurrencyRate(int id, int currencyId, DateTime date, double rate)
        {
            _id = id;
            _currencyId = currencyId;
            _date = date;
            _rate = rate;
        }

        // Свойства для доступа к данным
        public int ID { get { return _id; } set { _id = value; } }
        public int CurrencyId { get { return _currencyId; } set { _currencyId = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public double Rate { get { return _rate; } set { _rate = value; } }

        // Метод для вывода информации о курсе валюты в строковом формате
        public override string ToString()
        {
            return $"ID: {_id}, ID валюты: {_currencyId}, Дата: {_date.ToShortDateString()}, Курс: {_rate}";
        }
    }
}
