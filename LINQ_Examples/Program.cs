using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // OrderBy Продемонстрировать запрос на получение значений
            // в отсортированном порядке

            #region OrderBy
            int[] nums = { 10, -19, 4, 7, 2, -5, 0 };

            // Значения по нарастающей
            var posNums = from n in nums
                          orderby n
                          select n;
            Console.Write($"Значения по нарастающей: ");
            foreach (var i in posNums)
                Console.Write(i + " ");
            Console.WriteLine();

            // Значения по убывающей
            posNums = from n in nums
                      orderby n descending
                      select n;
            Console.Write($"Значения по убывающей: ");
            foreach (var i in posNums)
                Console.Write(i + " ");
            Console.WriteLine();


            // Сортировка по нескольким критериям.
            // orderby элемент_А направление, элемент_B направление, элемент_С  направление, ...

            Account[] accounts = { new Account("Том", "Смит", "132CK", 100.23),
                                   new Account("Том", "Смит", "13CD", 10000.00),
                                   new Account("Ральф", "Джонс", "436CD", 1923.85),
                                   new Account("Ральф", "Джонс", "454MM", 987.132),
                                   new Account("Тед", "Краммер", "897CD", 3223.19),
                                   new Account("Ральф", "Джонс", "434CK", -123.32),
                                   new Account("Сара", "Смит", "543MM", 5017.40),
                                   new Account("Сара", "Смит", "547CD", 34995.79),
                                   new Account("Сара", "Смит", "843CK", 345.00),
                                   new Account("Альберт", "Смит", "445CK", -213.67),
                                   new Account("Бетти", "Краммер", "968MM", 5146.67),
                                   new Account("Карл", "Смит", "078CD", 15345.99),
                                   new Account("Дженни", "Джонс", "108CK", 10.98)
            };

            // Сформировать запрос на полечение сведений о
            // банковских счетах в отсортированном порядке.
            // Отсировать эти сведения сначала по имени, затем
            // по фамилии и, наконец, по остатку на счете.

            var accInfo = from acc in accounts
                          orderby acc.LastName, acc.FirsName, acc.Balance
                          select acc;
            Console.WriteLine("Счета в отсортированном порядке: ");

            string str = "";

            // Выполнить запрос и вывести его результаты.
            foreach (Account acc in accInfo) {
                if (str != acc.FirsName) {
                    Console.WriteLine();
                    str = acc.FirsName;
                }

                Console.WriteLine($"{acc.LastName}, {acc.FirsName}\t" +
                                  "Номер счета: {0}, баланс: {1,10:C}",
                                  acc.AccountNumber, acc.Balance);
            }

            Console.WriteLine();


            #endregion


            #region SELECT

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ SELECT");

            double[] dnums = { -10.0, 16.4, 12.125, 100.85, -2.2, 25.25, -3.5 };

            var sqrRoots = from n in dnums
                           where n > 0
                           select Math.Sqrt(n);

            Console.WriteLine("Квадратные корни положительных значений, \n" +
                                "округленные до двух десятичных цифр: ");

            foreach (double r in sqrRoots)
                Console.WriteLine($"{r:#.##}");




            // Возвратить часть значения переменной диапазона

            EmailAddress[] addrs =
            {
                new EmailAddress("Герберт", "herb@herbschildt.com"),
                new EmailAddress("Том", "tom@herbschildt.com"),
                new EmailAddress("Сара", "sara@herbschildt.com")
            };

            // Запрос на получение адресов электронной почты
            var eAddrs = from entry in addrs
                         select entry.Address;
            Console.WriteLine("Адреса электронной почты:");
            foreach (string s in eAddrs)
                Console.WriteLine(" " + s);

            Console.WriteLine();


            // Испльзовать запрос для получения последовательности объектов
            // типа EmailAddresses из списка объектов типа ContactInfo.

            ContactInfo[] contacts = {
                new ContactInfo("Герберт", "herb@herbschildt.com", "555-1010"),
                new ContactInfo("Том", "tom@herbschildt.com", "555-1101"),
                new ContactInfo("Сара", "sara@herbschildt.com","555-0110")
            };

            // Сформировать запрос на получение списка объектов типа EmailAddress.

            var emailList = from entry in contacts
                            select new EmailAddress(entry.Name, entry.Email);
            Console.WriteLine("Список адресов электронной почты: ");
            foreach (EmailAddress e in emailList)
                Console.WriteLine($"{e.Name}: {e.Address}");

            #endregion


            #region FROM

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ ДВОЙНЫХ ЗАПРОСОВ FROM");

            // Испльзовать два вложенных оператора from для составления списка
            // всех возможных сочетаний букв А, В и С с буквами X, Y и Z.

            char[] chars1 = { 'A', 'B', 'C' };
            char[] chars2 = { 'X', 'Y', 'Z' };

            // В первом операторе from организуется циклическое обращение
            // к массиву символов chrs1, а во втором операторе from - циклическое
            // обращение к массиву символов chrs2.
            var pairs = from ch1 in chars1
                        from ch2 in chars2
                        select new ChrPair(ch1, ch2);

            Console.WriteLine("Все сочетания букв ABC и XYZ: ");
            foreach (var p in pairs)
                Console.WriteLine($"{p.First} {p.Second}");

            #endregion

            #region GROUP

            string[] websites = {
                "hsNameA.com", "hsNameB.net","hsNameC.net",
                "hsNameD.com", "hsNameE.org", "hsNameF.org",
                "hsNameG.tv", "hsNameH.net", "hsNameI.tv"
            };

            // Сформировать запрос на получение списка веб-сайтов,
            // группируемых по имени домена самого верхнего уровня.

            var webAddrs = from addr in websites
                           where addr.LastIndexOf('.') != -1
                           orderby addr.Substring(addr.LastIndexOf('.')) descending
                           group addr by addr.Substring(addr.LastIndexOf('.'));

            // Выполнить запрос и вывести его результаты.
            foreach (IGrouping<string, string> sites in webAddrs) {
                Console.WriteLine("Веб-сайты, сгруппированные " +
                                    "по имени домена " + sites.Key
                    );

                foreach (string site in sites)
                    Console.WriteLine(" " + site);
                Console.WriteLine();
            }

            #endregion

            #region INTO

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ INTO");

            // Сформировать запрос на получение списка веб-сайтов, группируемых
            // по имени домена самого верхнего уровня, но выбрать только те группы,
            // которые состоят более чем и двух членов.
            // Здесь ws - это переменная диапазона для ряда групп,
            // возвращаемых при выполнении первой половины запроса.
            var webAddrs1 = from addr in websites
                            where addr.LastIndexOf('.') != -1
                            group addr by addr.Substring(addr.LastIndexOf('.'))
                            into ws
                            where ws.Count() > 2
                            select ws;

            Console.WriteLine("Домены самого верхнего уровня с белее чем двумя членами.\n");
            foreach (var sites in webAddrs1) {
                Console.WriteLine("Содержимое домена: " + sites.Key);
                foreach (var site in sites)
                    Console.WriteLine(" " + site);
                Console.WriteLine();
            }
                       

            #endregion

            #region LET
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ LET");

            string[] strs = {"alpha", "beta", "gamma"};

            var chrs = from _str in strs
                       let chrArray = _str.ToCharArray()
                       from ch in chrArray
                       orderby ch
                       select ch;

            Console.WriteLine("Отдельные символы, отсортированные по порядку:");
            foreach (char c in chrs)
                Console.Write(c + " ");
            Console.WriteLine("\n");
            

            var webAddrs2 = from addr in websites
                            let idx = addr.LastIndexOf('.')
                            where idx != -1
                            group addr by addr.Substring(idx)
                            into ws
                            where ws.Count() > 2
                            select ws;

            Console.WriteLine("Домены самого верхнего уровня с белее чем двумя членами.");
            foreach (var sites in webAddrs2)
            {
                Console.WriteLine("Содержимое домена: " + sites.Key);
                foreach (var site in sites)
                    Console.WriteLine(" " + site);
                Console.WriteLine();
            }


            #endregion

            #region JOIN
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ JOIN ON EQUALS");
            Console.WriteLine();

            Item[] items = {
                new Item("Кусачки", 1424),
                new Item("Тиски", 7892),
                new Item("Молоток", 8534),
                new Item("Пила", 6411)
            };

            InStockStatus[] statusList = {
                new InStockStatus(1424, true),
                new InStockStatus(7892, false),
                new InStockStatus(8534, true),
                new InStockStatus(6411, true)

            };

            // Запрос объединяет объекты классов Item и InStockStatus для составления списка
            // наименований товаров и их наличия на складе.
            var inStockList = from item in items
                              join entry in statusList
                              on item.ItemNumber equals entry.ItemNumber
                              select new Temp(item.Name, entry.InStock);

            Console.WriteLine("Товар\tНаличие");

            foreach (Temp t in inStockList)
                Console.WriteLine($"{t.Name}\t{t.InStock}");

            Console.WriteLine();

            #endregion

            #region АНОНИМНЫЕ ТИПЫ
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ АНОНИМНЫЕ ТИПЫ");
            Console.WriteLine();

            var inStockList1 = from item in items
                              join entry in statusList
                              on item.ItemNumber equals entry.ItemNumber
                              where entry.ItemNumber > 7000
                              select new { Name = item.Name, InStock = entry.InStock };

            Console.WriteLine("Товар\tНаличие");

            foreach (var t in inStockList1)
                Console.WriteLine($"{t.Name}\t{t.InStock}");

            Console.WriteLine();

            #endregion

            #region INTO and JOIN
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ПРИМЕР ИСПОЛЬЗОВАНИЕ INTO вместе с JOIN");
            Console.WriteLine();

            string[] travelTypes = {
                "Воздушный",
                "Морской",
                "Наземный",
                "Речной"
            };

            //Массив видов транспорта.
            Transport[] transports = {
                new Transport("велосипед", "Наземный"),
                new Transport("аэростат", "Воздушный"),
                new Transport("лодка", "Речной"),
                new Transport("самолет", "Воздушный"),
                new Transport("каноэ", "Речной"),
                new Transport("биплан", "Воздушный"),
                new Transport("автомашина", "Наземный"),
                new Transport("судно", "Морской"),
                new Transport("поезд", "Наземный")
            };

            // Сформировать запрос, в котором групповое объединение используется для составления списка
            // видов транспорта по соответствующим категориям.
            var byHow = from how in travelTypes
                        join trans in transports
                        on how equals trans.How
                        into lst
                        select new { How = how, Tlist = lst };
            // Выполнить запрос и вывести его результаты.
            
            foreach (var t in byHow) {
                Console.WriteLine($"К категории <{t.How} транспорт> относится:");

                
                foreach (var m in t.Tlist)
                    Console.WriteLine(" " + m.Name);

                Console.WriteLine();
            }

            #endregion





            #region TEST STRING


            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Работа со строками STRING");

            string var1 = " asd.123";
            string var2;
            int var3;
            if (var1.LastIndexOf('.') == 0) {
                Console.WriteLine("Равно нулю");
                var2 = var1.Substring(var1.LastIndexOf('.'));
                var3 = var1.LastIndexOf('.');
                Console.WriteLine($"var2 = {var2}; var3 = {var3}");

            } else {
                Console.WriteLine("Не равно нулю");
                var2 = var1.Substring(var1.LastIndexOf('.'));
                var3 = var1.LastIndexOf('.');
                Console.WriteLine($"var2 = {var2}; var3 = {var3}");
            }




            #endregion






            Console.ReadKey();
        }
    }
}
