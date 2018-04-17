using System;
using System.IO;
/* Лабораторная работа №1: Сравнение работы алгоритмов.
 * Исполнители: Зотов Антон, Сергеев Виктор. Группа: ФО - 260002
 */
namespace FirstLab
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Если задан параметр - имя текстового файла, то открываем поток на чтение
            // из этого файла и прередаем его в конструктор.
            var reader = args.Length > 0 ? File.OpenText(args[0]) : Console.In;
            using (reader)
            {
                var robot = new Processing(reader, args.Length == 0);
                robot.Run();
            }
        }
    }
}
