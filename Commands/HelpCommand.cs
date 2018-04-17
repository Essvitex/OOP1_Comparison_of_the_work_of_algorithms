using System;
using System.Collections.Generic;

namespace FirstLab.Commands
{
    /// <summary>
    /// Справочная информация о программе и ее командах
    /// </summary>
    public class HelpCommand : ICommand
    {
        public string Name
        {
            get { return "help"; }
        }

        public string Help
        {
            get { return "Помощь по программе"; }
        }

        public string[] Synonyms
        {
            get { return new[] {"?", "info"}; }
        }

        public void Execute(List<int> param)
        {
            Console.WriteLine("Данная программа позволяет определить" +
                              "скорость различных видов сортировок целых чисел.\n" +
                              "Список команд:");

            string lastCommName = null;
            foreach (var command in Processing.AllComm.Values)
            {
                if (command.Name != lastCommName)
                {
                    Console.WriteLine("{0} - {1}", command.Name, command.Help);

                    Console.WriteLine("\t\tСинонимы команды:");
                    foreach (var syn in command.Synonyms)
                    {
                        Console.WriteLine("\t\t\t{0}", syn);
                    }
                }
                lastCommName = command.Name;
            }
        }
    }
}
