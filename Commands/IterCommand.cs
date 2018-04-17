using System;
using System.Collections.Generic;
using System.IO;

namespace FirstLab.Commands
{
    /// <summary>
    /// Задает кол-во итераций цикла определения среднего времени.
    /// Параметр - кол-во итераций.
    /// </summary>
    public class IterCommand : ICommand
    {
        public string Name
        {
            get { return "iterations"; }
        }

        public string Help
        {
            get { return "Задает кол-во итераций цикла определения среднего времени"; }
        }

        public string[] Synonyms
        {
            get { return new[] {"iter"}; }
        }

        public void Execute(List<int> param)
        {
            try
            {
                if (param.Count <= 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (param[0] > 0)
                {
                    Data.QuantIterations = param[0];
                    Console.WriteLine("Количество итераций: {0}", Data.QuantIterations);
                }
                else
                {
                    throw new InvalidDataException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Должен быть один параметр.");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Заданы некорректные данные, " +
                                  "параметр должен быть целочисленным и больше 0.");
            }
        }
    }
}
