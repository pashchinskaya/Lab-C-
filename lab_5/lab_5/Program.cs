using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "LR5-var12.xls"; // Путь к файлу Excel
            Database database;

            // Запрос на создание нового лог-файла или добавление в существующий
            Console.WriteLine("Введите путь к лог-файлу (если хотите создать новый) или нажмите Enter для использования существующего:");
            string logFilePath = Console.ReadLine();

            // Если пользователь не ввел путь, используем файл по умолчанию
            if (string.IsNullOrWhiteSpace(logFilePath))
            {
                logFilePath = "log.txt"; // Путь к лог-файлу по умолчанию
            }

            Logger logger = new Logger(logFilePath);

            try
            {
                database = new Database(filePath); // Загрузка данных из файла
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}"); // Вывод ошибки при загрузке данных
                return; // Завершение программы в случае ошибки
            }

            // Основной цикл программы
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотр счетов");
                Console.WriteLine("2. Просмотр валют");
                Console.WriteLine("3. Просмотр курсов валют");
                Console.WriteLine("4. Просмотр поступлений");
                Console.WriteLine("5. Удаление элемента");
                Console.WriteLine("6. Корректировка элемента");
                Console.WriteLine("7. Добавление элемента");
                Console.WriteLine("8. Последняя дата открытия счета");
                Console.WriteLine("9. Информация о валютах и курсах");
                Console.WriteLine("10. Список счетов с валютами и суммами начислений");
                Console.WriteLine("11. Количество различных валют по начислениям с 24 по 30 декабря 2021 года");
                Console.WriteLine("12. Выход");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        database.DisplayAccounts();
                        logger.Log("Просмотр счетов.");
                        break;
                    case "2":
                        database.DisplayCurrencies();
                        logger.Log("Просмотр валют.");
                        break;
                    case "3":
                        database.DisplayCurrencyRates();
                        logger.Log("Просмотр курсов валют.");
                        break;
                    case "4":
                        database.DisplayIncomes();
                        logger.Log("Просмотр поступлений.");
                        break;
                    case "5":
                        Console.WriteLine("Выберите таблицу для удаления элемента:");
                        Console.WriteLine("1. Счета");
                        Console.WriteLine("2. Валюты");
                        Console.WriteLine("3. Курсы валют");
                        Console.WriteLine("4. Начисления");
                        string deleteChoice = Console.ReadLine();
                        Console.Write("Введите ID элемента для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            switch (deleteChoice)
                            {
                                case "1":
                                    database.RemoveAccount(deleteId);
                                    logger.Log($"Удален счет с ID {deleteId}.");
                                    break;
                                case "2":
                                    database.RemoveCurrency(deleteId);
                                    logger.Log($"Удалена валюта с ID {deleteId}.");
                                    break;
                                case "3":
                                    database.RemoveCurrencyRate(deleteId);
                                    logger.Log($"Удален курс валюты с ID {deleteId}.");
                                    break;
                                case "4":
                                    database.RemoveIncome(deleteId);
                                    logger.Log($"Удалено начисление с ID {deleteId}.");
                                    break;
                                default:
                                    Console.WriteLine("Некорректный выбор.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Выберите таблицу для корректировки элемента:");
                        Console.WriteLine("1. Счета");
                        Console.WriteLine("2. Валюты");
                        Console.WriteLine("3. Курсы валют");
                        Console.WriteLine("4. Начисления");
                        string updateChoice = Console.ReadLine();
                        if (updateChoice == "1")
                        {
                            Console.Write("Введите ID элемента для корректировки: ");
                            if (int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                Console.Write("Введите новое ФИО: ");
                                string newFio = Console.ReadLine();
                                Console.Write("Введите новую дату открытия (дд.мм.гггг): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newOpeningDate))
                                {
                                    database.UpdateAccount(updateId, newFio, newOpeningDate);
                                    logger.Log($"Корректировка счета: ID {updateId}, новое ФИО: {newFio}, новая дата открытия: {newOpeningDate.ToShortDateString()}.");
                                }
                                else
                                {
                                    Console.WriteLine("Некорректная дата.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        else if (updateChoice == "2")
                        {
                            Console.Write("Введите ID валюты для корректировки: ");
                            if (int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                Console.Write("Введите новый код валюты: ");
                                string newCode = Console.ReadLine();
                                Console.Write("Введите новое название валюты: ");
                                string newName = Console.ReadLine();
                                database.UpdateCurrency(updateId, newCode, newName);
                                logger.Log($"Корректировка валюты: ID {updateId}, новый код: {newCode}, новое название: {newName}.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        else if (updateChoice == "3")
                        {
                            Console.Write("Введите ID курса валюты для корректировки: ");
                            if (int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                Console.Write("Введите новый ID валюты: ");
                                if (int.TryParse(Console.ReadLine(), out int currencyId))
                                {
                                    Console.Write("Введите новую дату курса (дд.мм.гггг): ");
                                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                                    {
                                        Console.Write("Введите новый курс: ");
                                        if (double.TryParse(Console.ReadLine(), out double newRate))
                                        {
                                            database.UpdateCurrencyRate(updateId, currencyId, date, newRate);
                                            logger.Log($"Корректировка курса валюты: ID {updateId}, новый ID валюты: {currencyId}, новая дата: {date.ToShortDateString()}, новый курс: {newRate}.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректный курс.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректная дата.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ID валюты.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        else if (updateChoice == "4")
                        {
                            Console.Write("Введите ID начисления для корректировки: ");
                            if (int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                Console.Write("Введите новый ID счета: ");
                                if (int.TryParse(Console.ReadLine(), out int accountId))
                                {
                                    Console.Write("Введите новый ID валюты: ");
                                    if (int.TryParse(Console.ReadLine(), out int currencyId))
                                    {
                                        Console.Write("Введите новую дату начисления (дд.мм.гггг): ");
                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                                        {
                                            Console.Write("Введите новую сумму начисления: ");
                                            if (double.TryParse(Console.ReadLine(), out double newAmount))
                                            {
                                                database.UpdateIncome(updateId, accountId, currencyId, date, newAmount);
                                                logger.Log($"Корректировка начисления: ID {updateId}, новый ID счета: {accountId}, новый ID валюты: {currencyId}, новая дата: {date.ToShortDateString()}, новая сумма: {newAmount}.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректная сумма.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректная дата.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ID валюты.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ID счета.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("Выберите таблицу для добавления элемента:");
                        Console.WriteLine("1. Счета");
                        Console.WriteLine("2. Валюты");
                        Console.WriteLine("3. Курсы валют");
                        Console.WriteLine("4. Начисления");
                        string addChoice = Console.ReadLine();
                        if (addChoice == "1")
                        {
                            Console.Write("Введите ID нового счета: ");
                            if (int.TryParse(Console.ReadLine(), out int newId))
                            {
                                Console.Write("Введите ФИО владельца: ");
                                string fio = Console.ReadLine();
                                Console.Write("Введите дату открытия (дд.мм.гггг): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime openingDate))
                                {
                                    database.AddAccount(newId, fio, openingDate);
                                    logger.Log($"Добавлен новый счет: ID {newId}, ФИО: {fio}, дата открытия: {openingDate.ToShortDateString()}.");
                                }
                                else
                                {
                                    Console.WriteLine("Некорректная дата.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        else if (addChoice == "2")
                        {
                            Console.Write("Введите ID новой валюты: ");
                            if (int.TryParse(Console.ReadLine(), out int newId))
                            {
                                Console.Write("Введите код валюты: ");
                                string code = Console.ReadLine();
                                Console.Write("Введите название валюты: ");
                                string name = Console.ReadLine();
                                database.AddCurrency(newId, code, name);
                                logger.Log($"Добавлена новая валюта: ID {newId}, код: {code}, название: {name}.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        else if (addChoice == "3")
                        {
                            Console.Write("Введите ID нового курса валюты: ");
                            if (int.TryParse(Console.ReadLine(), out int newId))
                            {
                                Console.Write("Введите ID валюты: ");
                                if (int.TryParse(Console.ReadLine(), out int currencyId))
                                {
                                    Console.Write("Введите дату курса (дд.мм.гггг): ");
                                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                                    {
                                        Console.Write("Введите курс валюты: ");
                                        if (double.TryParse(Console.ReadLine(), out double rate))
                                        {
                                            database.AddCurrencyRate(newId, currencyId, date, rate);
                                            logger.Log($"Добавлен новый курс валюты: ID {newId}, ID валюты: {currencyId}, дата: {date.ToShortDateString()}, курс: {rate}.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректный курс.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректная дата.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ID валюты.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        else if (addChoice == "4")
                        {
                            Console.Write("Введите ID нового начисления: ");
                            if (int.TryParse(Console.ReadLine(), out int newId))
                            {
                                Console.Write("Введите ID счета: ");
                                if (int.TryParse(Console.ReadLine(), out int accountId))
                                {
                                    Console.Write("Введите ID валюты: ");
                                    if (int.TryParse(Console.ReadLine(), out int currencyId))
                                    {
                                        Console.Write("Введите дату начисления (дд.мм.гггг): ");
                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                                        {
                                            Console.Write("Введите сумму начисления: ");
                                            if (double.TryParse(Console.ReadLine(), out double amount))
                                            {
                                                database.AddIncome(newId, accountId, currencyId, date, amount);
                                                logger.Log($"Добавлено новое начисление: ID {newId}, ID счета: {accountId}, ID валюты: {currencyId}, дата: {date.ToShortDateString()}, сумма: {amount}.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректная сумма.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректная дата.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ID валюты.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ID счета.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ID.");
                            }
                        }
                        break;
                    case "8":
                        database.GetLastAccountOpeningDate();
                        logger.Log("Получена последняя дата открытия счета.");
                        return;
                    case "9":
                        database.DisplayCurrenciesAndRates();
                        logger.Log("Получена информация о валютах и курсах.");
                        break;
                    case "10":
                        database.DisplayAccountsWithIncomes();
                        logger.Log("Получен список счетов с валютами и суммами начислений.");
                        break;
                    case "11":
                        database.GetDistinctCurrencyCountForIncomes(new DateTime(2021, 12, 24), new DateTime(2021, 12, 30));
                        logger.Log("Получено количество различных валют по начислениям с 24 по 30 декабря 2021 года.");
                        break;
                    case "12":
                        Console.WriteLine("Выход из программы. Нажмите любую клавишу для завершения.");
                        Console.ReadKey(); // Ожидание нажатия клавиши
                        logger.Log("Выход из программы.");
                        Environment.Exit(0); // Завершение программы
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор, попробуйте снова.");
                        break;
                }
            }
        }

    }
}
