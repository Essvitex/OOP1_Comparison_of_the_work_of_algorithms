using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace FirstLab.Commands
{
    /// <summary>
    /// Запуск и измерение времени работы алгоритма на заданных данных
    /// </summary>
    public class TestCommand : ICommand
    {
        public string Name
        {
            get { return "test"; }
        }

        public string Help
        {
            get { return "Запуск сортировок и проверка времени их выполнения"; }
        }

        public string[] Synonyms
        {
            get { return new[] { "run", "start" }; }
        }

        public void Execute(List<int> param)
        {
            try
            {
                if (Data.QuantIterations > 0 && Data.DataSequence.Count > 0)
                {
                    // Список для хранения среднего времени работы каждого алгоритма
                    var times = new List<double>();
                    // Список всех реализованных сортировок
                    var allSorts = new CurrSort[]
                    {
                        Sorts.Bubble,
                        Sorts.Shell,
                        Sorts.Quick,
                        Sorts.DefaultSort
                    };


                    // Получение среднего арифметического времени работы алгоритма
                    // путем деления времени на кол-во итераций
                    for (var i = 0; i < 4; i++)
                    {
                        times.Add(CheckTime(allSorts[i]) / Data.QuantIterations);
                    }

                    var info =
                        string.Format("Итераций: {0}, Размер массива: {1}\n " +
                                      "Пузырек: {2}мс\n Шелл: {3}мс\n Быстрая сортировка: {4}мс\n Встроенная сортировка: {5}мс\n",
                                      Data.QuantIterations, Data.DataSequence.Count, times[0], times[1], 
                                      times[2], times[3]);

                    Console.WriteLine(info);
                }
                else
                {
                    throw new NoNullAllowedException();
                }
            }
            catch (NoNullAllowedException)
            {
                Console.WriteLine("Недопустимое кол-во итераций или " +
                                  "элементов тестовой последовательности, возможно вы их не задали.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Делегат для методов сортировки
        /// </summary>
        /// <param name="data">Набор чисел для проверки алгоритма</param>
        private delegate void CurrSort(int[] data);

        /// <summary>
        /// Получение общего времени работы алгоритма (для определения среднего времени работы)
        /// </summary>
        /// <param name="sort">Делегат необходимого метода</param>
        /// <returns>Общее время работы</returns>
        private double CheckTime(CurrSort sort)
        {
            var stopWatch = new Stopwatch();

            // Метод алгоритма вызывается необходимое кол-во раз
            // и засекается скорость работы алгоритма
            for (var i = 0; i < Data.QuantIterations; i++)
            {
                stopWatch.Start();
                sort(Data.DataSequence.ToArray());
                stopWatch.Stop();
            }

            return stopWatch.Elapsed.TotalMilliseconds;
        }
    }
}
