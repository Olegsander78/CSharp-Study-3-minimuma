using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3minimuma
{


    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10
            int[] income = new int[12];
            int[] expenses = new int[12];
            int[] profit = new int[12];
            int[] year = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Random r = new Random();
            Console.WriteLine("Месяц   Доход, тыс. руб. Расход, тыс. руб.  Прибыль, тыс. руб.");
            for (int i = 0; i < 12; i++)
            {
                income[i] = r.Next(990, 1000) * 1000;
                expenses[i] = r.Next(990, 1000) * 1000;
                profit[i] = income[i] - expenses[i];

                Console.Write($"\n{i + 1,2}         {income[i].ToString("### ###"),9}       {expenses[i],9}           {profit[i],9} ");

            }

            Console.WriteLine();
            #region Предполагем что первые 3 значения и есть мин и упорядочиваем их.
            int monthPositivProfit = 0;
            int min = profit[0];
            int min2 = profit[1];
            int min3 = profit[2];
            if (min > min2)
            {
                min2 = profit[0];
                min = profit[1];
            }
            if (min > min3)
            {
                int tmp = min3;
                min3 = min;
                min = tmp;
            }
            if (min2 > min3)
            {
                int tmp = min3;
                min3 = min2;
                min2 = tmp;
            }
            #endregion
            #region Подсчет кол-ва месяцев с положительными значениями 
            for (int i = 0; i < profit.Length; i++)
            {
                if (profit[i] > 0) monthPositivProfit++;
            }
            #endregion
            #region поиск 3х минимальных значений в массиве
            for (int i = 3; i < 12; i++)
            {

                if (min > profit[i])
                {
                    min3 = min2;
                    min2 = min;
                    min = profit[i];
                    continue;
                }
                if (min2 > profit[i])
                {
                    min3 = min2;
                    min2 = profit[i];
                    continue;
                }
                if (min3 > profit[i])
                {
                    min3 = profit[i];
                    continue;
                }
            }
            #endregion

            Console.WriteLine($"\nКол-во месяцев с положительной прибылью: {monthPositivProfit}");
            Console.Write("Худшие месяцы по прибыли: ");
            #region Вывод месяцев соответствующих мин значениям, включая дубли минимумов
            for (int i = 0; i < profit.Length; i++)
            {
                if (profit[i] == min || profit[i] == min2 || profit[i] == min3)
                {
                    Console.Write($"{i + 1} ");
                }
            }
            #endregion
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Решение задачи через структуры.");
            MonthlyRep[] report = new MonthlyRep[12];
            string[] months = { "January", "February", "March", "April", "May", "June", 
                "July", "August", "September", "October", "November", "December" }; 
            
            report[0] = new MonthlyRep();
            report[0].Month = months[0];
            report[0].Income= r.Next(990, 1000) * 1000;
            report[0].Expenses= r.Next(990, 1000) * 1000;
            report[0].Profit = report[0].Income - report[0].Expenses;
            Console.WriteLine();
            for (int i = 0; i < report.Length; i++)
            {
                report[i] = new MonthlyRep();
                report[i].Month = months[i];
                report[i].Income = r.Next(900, 1000) * 1000;
                report[i].Expenses = r.Next(900, 1000) * 1000;
                report[i].Profit = report[i].Income - report[i].Expenses;
                
                Console.WriteLine($"{report[i].Month,9} {report[i].Income,9} {report[i].Expenses,9}  {report[i].Profit,9}");
            }
            monthPositivProfit = 0;
            
            for (int i = 0; i < report.Length; i++)
            {
                if (report[i].Profit >= 0) monthPositivProfit++;
            }
            Console.WriteLine($"\nКол-во месяцев с положительной прибылью: {monthPositivProfit}");

            #region Предполагаем что первые три месяца наименьшие по прибыли и выявляем мин и мах. 
            int smin = report[0].Profit;
            int smin2 = report[1].Profit;
            int smin3 = report[2].Profit;
            if (smin > smin2)
            {
                smin2 = report[0].Profit;
                smin = report[1].Profit;
            }
            if (smin > smin3)
            {
                int tmp = smin3;
                smin3 = smin;
                smin = tmp;
            }
            if (smin2 > smin3)
            {
                int tmp = smin3;
                smin3 = smin2;
                smin2 = tmp;
            }
            #endregion
            #region поиск 3х минимальных значений в массиве
            for (int i = 3; i < 12; i++)
            {

                if (smin > report[i].Profit)
                {
                    smin3 = smin2;
                    smin2 = smin;
                    smin = report[i].Profit;
                    continue;
                }
                if (smin2 > report[i].Profit)
                {
                    smin3 = smin2;
                    smin2 = report[i].Profit;
                    continue;
                }
                if (smin3 > report[i].Profit)
                {
                    smin3 = report[i].Profit;
                    continue;
                }
            }
            #endregion
            Console.Write("Худшие месяцы по прибыли: ");
            #region Вывод месяцев соответствующих мин значениям прибыли, включая дубли минимумов
            for (int i = 0; i < report.Length; i++)
            {
                if (report[i].Profit == smin || report[i].Profit == smin2 || report[i].Profit == smin3)
                {
                    Console.Write($"{report[i].Month} ");
                }
            }
            #endregion
            Console.ReadLine();

        }
    }
}
