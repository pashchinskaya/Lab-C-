using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab_5
{
    internal class Database
    {
        private List<Account> _accounts; // Список счетов
        private List<Currency> _currencies; // Список валют
        private List<CurrencyRate> _currencyRates; // Список курсов валют
        private List<Income> _incomes; // Список поступлений
        private Workbook _workbook; // Объект Workbook для работы с Excel
        private string _filePath; // Путь к файлу

        // Конструктор класса Database
        public Database(string filePath)
        {
            _filePath = filePath;
            _workbook = new Workbook(filePath); // Создание объекта Workbook для работы с Excel
            LoadData(filePath); // Загрузка данных из Excel
        }

        // Метод для загрузки данных из Excel
        private void LoadData(string filePath)
        {
            LoadAccounts(_workbook.Worksheets[0]); // Загрузка счетов из первого листа
            LoadCurrencies(_workbook.Worksheets[2]); // Загрузка валют из третьего листа
            LoadCurrencyRates(_workbook.Worksheets[1]); // Загрузка курсов валют из второго листа
            LoadIncomes(_workbook.Worksheets[3]); // Загрузка поступлений из четвертого листа
        }

        // Метод для загрузки счетов
        private void LoadAccounts(Worksheet worksheet)
        {
            _accounts = new List<Account>(); // Инициализация списка счетов
            for (int i = 1; i <= worksheet.Cells.MaxDataRow; i++) // Проход по всем строкам
            {
                int id = int.Parse(worksheet.Cells[i, 0].StringValue); // Чтение ID
                string fio = worksheet.Cells[i, 1].StringValue; // Чтение ФИО
                DateTime openingDate = DateTime.Parse(worksheet.Cells[i, 2].StringValue); // Чтение даты открытия
                _accounts.Add(new Account(id, fio, openingDate)); // Добавление счета в список
            }
        }

        // Метод для загрузки валют
        private void LoadCurrencies(Worksheet worksheet)
        {
            _currencies = new List<Currency>(); // Инициализация списка валют
            for (int i = 1; i <= worksheet.Cells.MaxDataRow; i++) // Проход по всем строкам
            {
                int id = int.Parse(worksheet.Cells[i, 0].StringValue); // Чтение ID
                string code = worksheet.Cells[i, 1].StringValue; // Чтение кода валюты
                string name = worksheet.Cells[i, 2].StringValue; // Чтение наименования валюты
                _currencies.Add(new Currency(id, code, name)); // Добавление валюты в список
            }
        }

        // Метод для загрузки курсов валют
        private void LoadCurrencyRates(Worksheet worksheet)
        {
            _currencyRates = new List<CurrencyRate>(); // Инициализация списка курсов валют
            for (int i = 1; i <= worksheet.Cells.MaxDataRow; i++) // Проход по всем строкам
            {
                int id = int.Parse(worksheet.Cells[i, 0].StringValue); // Чтение ID
                int currencyId = int.Parse(worksheet.Cells[i, 1].StringValue); // Чтение ID валюты
                DateTime date = DateTime.Parse(worksheet.Cells[i, 2].StringValue); // Чтение даты курса
                double rate = double.Parse(worksheet.Cells[i, 3].StringValue); // Чтение значения курса
                _currencyRates.Add(new CurrencyRate(id, currencyId, date, rate)); // Добавление курса в список
            }
        }

        // Метод для загрузки поступлений
        private void LoadIncomes(Worksheet worksheet)
        {
            _incomes = new List<Income>(); // Инициализация списка поступлений
            for (int i = 1; i <= worksheet.Cells.MaxDataRow; i++) // Проход по всем строкам
            {
                int id = int.Parse(worksheet.Cells[i, 0].StringValue); // Чтение ID
                int accountId = int.Parse(worksheet.Cells[i, 1].StringValue); // Чтение ID счета
                int currencyId = int.Parse(worksheet.Cells[i, 2].StringValue); // Чтение ID валюты
                DateTime date = DateTime.Parse(worksheet.Cells[i, 3].StringValue); // Чтение даты поступления
                double amount = double.Parse(worksheet.Cells[i, 4].StringValue); // Чтение суммы поступления
                _incomes.Add(new Income(id, accountId, currencyId, date, amount)); // Добавление поступления в список
            }
        }

        // СЧЕТА

        // Метод для удаления счета по ID
        public void RemoveAccount(int id)
        {
            var account = _accounts.Find(a => a.ID == id);
            if (account != null)
            {
                _accounts.Remove(account);
                Console.WriteLine($"Счет с ID {id} удален.");
                UpdateExcelWithAccounts(); // Обновление данных в Excel
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Счет с ID {id} не найден.");
            }
        }

        // Метод для корректировки счета по ID
        public void UpdateAccount(int id, string newFio, DateTime newOpeningDate)
        {
            var account = _accounts.Find(a => a.ID == id);
            if (account != null)
            {
                // В данном случае мы просто создадим новый объект
                _accounts.Remove(account);
                _accounts.Add(new Account(id, newFio, newOpeningDate));
                Console.WriteLine($"Счет с ID {id} обновлен.");
                UpdateExcelWithAccounts(); // Обновление данных в Excel
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Счет с ID {id} не найден.");
            }
        }

        // Метод для добавления нового счета
        public void AddAccount(int id, string fio, DateTime openingDate)
        {
            var account = new Account(id, fio, openingDate);
            _accounts.Add(account);
            Console.WriteLine($"Счет с ID {id} добавлен.");
            UpdateExcelWithAccounts(); // Обновление данных в Excel
            SaveWorkbook();
        }

        // Метод для обновления данных для счета
        private void UpdateExcelWithAccounts()
        {
            var worksheet = _workbook.Worksheets[0]; // Счета на первом листе
            worksheet.Cells.Clear(); // Очистка существующих данных

            // Запись заголовков
            worksheet.Cells[0, 0].PutValue("ID");
            worksheet.Cells[0, 1].PutValue("ФИО");
            worksheet.Cells[0, 2].PutValue("Дата открытия");

            for (int i = 0; i < _accounts.Count; i++)
            {
                var account = _accounts[i];
                worksheet.Cells[i + 1, 0].PutValue(account.ID); // ID
                worksheet.Cells[i + 1, 1].PutValue(account.FIO); // ФИО

                // Проверка на корректность даты
                if (account.OpeningDate != DateTime.MinValue)
                {
                    worksheet.Cells[i + 1, 2].PutValue(account.OpeningDate); // Дата открытия
                }
                else
                {
                    Console.WriteLine($"Некорректная дата для счета с ID {account.ID}. Пропускаем.");
                }
            }
        }



        // ВАЛЮТЫ

        public void RemoveCurrency(int id)
        {
            var currency = _currencies.Find(c => c.ID == id);
            if (currency != null)
            {
                _currencies.Remove(currency);
                Console.WriteLine($"Валюта с ID {id} удалена.");
                UpdateExcelWithCurrencies();
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Валюта с ID {id} не найдена.");
            }
        }

        public void UpdateCurrency(int id, string code, string name)
        {
            var currency = _currencies.Find(c => c.ID == id);
            if (currency != null)
            {
                _currencies.Remove(currency);
                _currencies.Add(new Currency(id, code, name));
                Console.WriteLine($"Валюта с ID {id} обновлена.");
                UpdateExcelWithCurrencies();
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Валюта с ID {id} не найдена.");
            }
        }

        public void AddCurrency(int id, string code, string name)
        {
            var currency = new Currency(id, code, name);
            _currencies.Add(currency);
            Console.WriteLine($"Валюта с ID {id} добавлена.");
            UpdateExcelWithCurrencies();
            SaveWorkbook();
        }

        // Метод для обновлений данных валют
        private void UpdateExcelWithCurrencies()
        {
            var worksheet = _workbook.Worksheets[2]; // Валюты на третьем листе
            worksheet.Cells.Clear(); // Очистка существующих данных

            // Запись заголовков
            worksheet.Cells[0, 0].PutValue("ID");
            worksheet.Cells[0, 1].PutValue("Код валюты");
            worksheet.Cells[0, 2].PutValue("Наименование валюты");

            for (int i = 0; i < _currencies.Count; i++)
            {
                var currency = _currencies[i];
                worksheet.Cells[i + 1, 0].PutValue(currency.ID); // ID
                worksheet.Cells[i + 1, 1].PutValue(currency.Code); // Код валюты
                worksheet.Cells[i + 1, 2].PutValue(currency.Name); // Наименование валюты
            }
        }



        // КУРС ВАЛЮТ

        public void RemoveCurrencyRate(int id)
        {
            var rate = _currencyRates.Find(r => r.ID == id);
            if (rate != null)
            {
                _currencyRates.Remove(rate);
                Console.WriteLine($"Курс валюты с ID {id} удален.");
                UpdateExcelWithCurrencyRates();
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Курс валюты с ID {id} не найден.");
            }
        }

        public void UpdateCurrencyRate(int id, int currencyId, DateTime date, double rate)
        {
            var rate1 = _currencyRates.Find(r => r.ID == id);
            if (rate1 != null)
            {
                _currencyRates.Remove(rate1);
                _currencyRates.Add(new CurrencyRate(id, currencyId, date, rate));
                Console.WriteLine($"Курс валюты с ID {id} обновлен.");
                UpdateExcelWithCurrencyRates();
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Курс валюты с ID {id} не найден.");
            }
        }

        public void AddCurrencyRate(int id, int currencyId, DateTime date, double rate)
        {
            var currencyRate = new CurrencyRate(id, currencyId, date, rate);
            _currencyRates.Add(currencyRate);
            Console.WriteLine($"Курс валюты с ID {id} добавлен.");
            UpdateExcelWithCurrencyRates();
            SaveWorkbook();
        }

        // Метод для обновления курса валют
        private void UpdateExcelWithCurrencyRates()
        {
            var worksheet = _workbook.Worksheets[1]; // Курсы валют на втором листе
            worksheet.Cells.Clear(); // Очистка существующих данных

            // Запись заголовков
            worksheet.Cells[0, 0].PutValue("ID");
            worksheet.Cells[0, 1].PutValue("ID валюты");
            worksheet.Cells[0, 2].PutValue("Дата курса");
            worksheet.Cells[0, 3].PutValue("Курс");

            for (int i = 0; i < _currencyRates.Count; i++)
            {
                var rate = _currencyRates[i];
                worksheet.Cells[i + 1, 0].PutValue(rate.ID); // ID
                worksheet.Cells[i + 1, 1].PutValue(rate.CurrencyId); // ID валюты

                // Проверка на корректность даты
                if (rate.Date != DateTime.MinValue)
                {
                    worksheet.Cells[i + 1, 2].PutValue(rate.Date); // Дата курса
                }
                else
                {
                    Console.WriteLine($"Некорректная дата для курса с ID {rate.ID}. Пропускаем.");
                }

                worksheet.Cells[i + 1, 3].PutValue(rate.Rate); // Курс
            }
        }



        // НАЧИСЛЕНИЯ

        public void RemoveIncome(int id)
        {
            var income = _incomes.Find(i => i.ID == id);
            if (income != null)
            {
                _incomes.Remove(income);
                Console.WriteLine($"Начисление с ID {id} удалено.");
                UpdateExcelWithIncomes();
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Начисление с ID {id} не найдено.");
            }
        }

        public void UpdateIncome(int id, int accountId, int currencyId, DateTime date, double amount)
        {
            var income = _incomes.Find(i => i.ID == id);
            if (income != null)
            {
                _incomes.Remove(income);
                _incomes.Add(new Income(id, accountId, currencyId, date, amount));
                Console.WriteLine($"Начисление с ID {id} обновлено.");
                UpdateExcelWithIncomes();
                SaveWorkbook();
            }
            else
            {
                Console.WriteLine($"Начисление с ID {id} не найдено.");
            }
        }

        public void AddIncome(int id, int accountId, int currencyId, DateTime date, double amount)
        {
            var income = new Income(id, accountId, currencyId, date, amount);
            _incomes.Add(income);
            Console.WriteLine($"Начисление с ID {id} добавлено.");
            UpdateExcelWithIncomes();
            SaveWorkbook();
        }

        // МЕтод для обновления начислений
        private void UpdateExcelWithIncomes()
        {
            var worksheet = _workbook.Worksheets[3]; // Поступления на четвертом листе
            worksheet.Cells.Clear(); // Очистка существующих данных

            // Запись заголовков
            worksheet.Cells[0, 0].PutValue("ID");
            worksheet.Cells[0, 1].PutValue("ID счета");
            worksheet.Cells[0, 2].PutValue("ID валюты");
            worksheet.Cells[0, 3].PutValue("Дата поступления");
            worksheet.Cells[0, 4].PutValue("Сумма");

            for (int i = 0; i < _incomes.Count; i++)
            {
                var income = _incomes[i];
                worksheet.Cells[i + 1, 0].PutValue(income.ID); // ID
                worksheet.Cells[i + 1, 1].PutValue(income.AccountId); // ID счета
                worksheet.Cells[i + 1, 2].PutValue(income.CurrencyId); // ID валюты

                // Проверка на корректность даты
                if (income.Date != DateTime.MinValue)
                {
                    worksheet.Cells[i + 1, 3].PutValue(income.Date); // Дата поступления
                }
                else
                {
                    Console.WriteLine($"Некорректная дата для поступления с ID {income.ID}. Пропускаем.");
                }

                worksheet.Cells[i + 1, 4].PutValue(income.Amount); // Сумма
            }
        }


        // Метод для сохранения изменений
        private void SaveWorkbook()
        {
            try
            {
                _workbook.Save(_filePath);
                Console.WriteLine("Изменения успешно сохранены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        // Метод для отображения списка счетов
        public void DisplayAccounts()
        {
            foreach (var account in _accounts)
            {
                Console.WriteLine(account); // Вывод информации о каждом счете
            }
        }

        // Метод для отображения списка валют
        public void DisplayCurrencies()
        {
            foreach (var currency in _currencies)
            {
                Console.WriteLine(currency); // Вывод информации о каждой валюте
            }
        }

        // Метод для отображения списка курсов валют
        public void DisplayCurrencyRates()
        {
            foreach (var rate in _currencyRates)
            {
                Console.WriteLine(rate); // Вывод информации о каждом курсе валюты
            }
        }

        // Метод для отображения списка поступлений
        public void DisplayIncomes()
        {
            foreach (var income in _incomes)
            {
                Console.WriteLine(income); // Вывод информации о каждом поступлении
            }
        }

        // ЗАПРОСЫ

        // 1. Запрос на получение последней даты открытия счета
        public DateTime GetLastAccountOpeningDate()
        {
            if (_accounts.Count == 0)
            {
                Console.WriteLine("Счета не найдены.");
                return DateTime.MinValue;
            }

            DateTime lastDate = _accounts.Max(a => a.OpeningDate);
            Console.WriteLine($"Последняя дата открытия счета: {lastDate.ToShortDateString()}");
            return lastDate;
        }

        // 2. Запрос на получение информации о валютах и курсах
        public void DisplayCurrenciesAndRates()
        {
            foreach (var currency in _currencies)
            {
                var rates = _currencyRates.Where(r => r.CurrencyId == currency.ID).ToList();
                Console.WriteLine($"Валюта: {currency.Name} (Код: {currency.Code})");
                foreach (var rate in rates)
                {
                    Console.WriteLine($"  Дата: {rate.Date.ToShortDateString()}, Курс: {rate.Rate}");
                }
            }
        }

        // 3. Запрос на получение списка счетов, валют и сумм начислений
        public void DisplayAccountsWithIncomes()
        {
            var incomeGroups = from income in _incomes
                               join account in _accounts on income.AccountId equals account.ID
                               join currency in _currencies on income.CurrencyId equals currency.ID
                               select new
                               {
                                   AccountOwner = account.FIO,
                                   Currency = currency.Name,
                                   Amount = income.Amount
                               };

            foreach (var item in incomeGroups)
            {
                Console.WriteLine($"Владелец счета: {item.AccountOwner}, Валюта: {item.Currency}, Сумма: {item.Amount}");
            }
        }

        // 4. Запрос на получение количества различных валют, по которым были начисления с 24 по 30 декабря 2021 года
        public int GetDistinctCurrencyCountForIncomes(DateTime startDate, DateTime endDate)
        {
            var distinctCurrencies = _incomes
                .Where(i => i.Date >= startDate && i.Date <= endDate)
                .Select(i => i.CurrencyId)
                .Distinct()
                .Count();

            Console.WriteLine($"Количество различных валют, по которым были начисления с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}: {distinctCurrencies}");
            return distinctCurrencies;
        }

    }
}
