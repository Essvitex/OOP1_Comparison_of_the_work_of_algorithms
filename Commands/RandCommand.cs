using System;
using System.Collections.Generic;
using System.IO;

namespace FirstLab.Commands
{
    /// <summary>
    ///  Добавление последовательности случайных чисел для проверки алгоритмов
    /// Параметры, первый из которых может указывать кол-во случайных чисел,
    /// если список пуст то генерируется 1000 случ. чисел.
    /// </summary>
    public class RandCommand : ICommand
    {
        public string Name
        {
            get { return "random"; }
        }

        public string Help
        {
            get { return "Генерирует последовательность случайных чисел."; }
        }

        public string[] Synonyms
        {
            get { return new[] { "rand", "generate" }; }
        }

        public void Execute(List<int> param)
        {
            try
            {
                // Кол-во случайных чисел
                // Если кол-во случайных чисел в списке не указано то будет 1000
                var currParam = 1000;

                // Создание объекта для генерации случайных чисел
                Random rnd = new Random();

                Data.DataSequence = new List<int>();

                // Если существует параметр, который обоначает кол-во чисел в массиве то
                //  используем его
                if (param.Count > 0)
                {
                    if (param[0] <= 0)
                    {
                        throw new InvalidDataException();
                    }
                    currParam = param[0];
                }

                for (var i = 0; i < currParam; i++)
                {
                    // Получить случайное число (в диапазоне от -10 до 10)
                    Data.DataSequence.Add(rnd.Next(-10, 10));
                }
                Console.WriteLine("Последовательность установлена");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Заданы некорректные данные, " +
                                  "параметр должен быть целочисленным и больше 0.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
