using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab_5
{
    // Класс начисления
    internal class Income
    {
        private int _id; // Уникальный идентификатор поступления
        private int _accountId; // Идентификатор счета, к которому относится поступление
        private int _currencyId; // Идентификатор валюты поступления
        private DateTime _date; // Дата поступления
        private double _amount; // Сумма поступления

        // Конструктор класса Income
        public Income(int id, int accountId, int currencyId, DateTime date, double amount)
        {
            _id = id;
            _accountId = accountId;
            _currencyId = currencyId;
            _date = date;
            _amount = amount;
        }

        // Свойства для доступа к данным
        public int ID { get { return _id; } set { _id = value; } }
        public int AccountId { get { return _accountId; } set { _accountId = value; } }
        public int CurrencyId { get { return _currencyId; } set { _currencyId = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public double Amount { get { return _amount; } set { _amount = value; } }

        // Метод для вывода информации о поступлении в строковом формате
        public override string ToString()
        {
            return $"ID: {_id}, ID счёта: {_accountId}, ID валюты: {_currencyId}, Дата: {_date.ToShortDateString()}, Поступление: {_amount}";
        }
    }
}
