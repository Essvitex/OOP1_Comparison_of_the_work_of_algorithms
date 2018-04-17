using System;
using System.Collections.Generic;
using System.IO;

namespace FirstLab.Commands
{
    /// <summary>
    /// Задает последовательность для обработки алгоритмами
    /// Параметры - последовательность целых чисел через пробел
    /// </summary>
    public class SeqCommand : ICommand
    {
        public string Name
        {
            get { return "sequence"; }
        }

        public string Help
        {
            get { return "Задает последовательность для обработки алгоритмами"; }
        }

        public string[] Synonyms
        {
            get { return new[] {"seq"}; }
        }

        public void Execute(List<int> param)
        {
            try
            {
                if (param.Count > 0)
                {
                    Data.DataSequence = param;
                    Console.WriteLine("Последовательность установлена");
                }
                else
                {
                    throw new InvalidDataException();
                }
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("В последователности должен быть хотя бы один элемент.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
