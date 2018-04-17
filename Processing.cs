using System;
using System.IO;
using System.Collections.Generic;
using FirstLab.Commands;

namespace FirstLab
{
    /// <summary>
    /// Класс для обработки команды и ее поиска
    /// </summary>
    class Processing
    {
        /// <summary>
        /// Словарь всех возможных команд с синонимами, реализующих интерфейс ICommand
        /// </summary>
        public static Dictionary<string, ICommand> AllComm { get;  private set; }

        /// <summary>
        /// Флаг останавливает программу при значении false
        /// </summary>
        private bool isRunning = true;

        /// <summary>
        /// Использование консоли либо текстового файла
        /// для получения команд
        /// </summary>
        private bool Interactive { get; set; }

        private TextReader Reader { get; set; }

        /// <summary>
        /// Список всех экземпляров классов команд
        /// </summary>
        public List<ICommand> Commands { get; set; }

        public Processing(TextReader reader, bool interactive)
        {
            try
            {
                AllComm = new Dictionary<string, ICommand>();
                Commands = new List<ICommand>
                {
                    {new ExitCommand(this)},
                    {new HelpCommand()},
                    {new TestCommand()},
                    {new RandCommand()},
                    {new SeqCommand()},
                    {new IterCommand()},
                    {new Clear()}
                };

                Interactive = interactive;
                Reader = reader;

                if (!Interactive && Reader.ReadToEnd().Length < 3)
                    throw new InvalidDataException();
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Пустой файл.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// Добавление команд вместе с их синонимами в словарь команд
        /// </summary>
        public void AddCommands()
        {
            foreach (var currComm in Commands)
            {
                AllComm.Add(currComm.Name, currComm);
                foreach (var synonym in currComm.Synonyms)
                {
                    AllComm.Add(synonym, currComm);
                }
            }
        }

        /// <summary>
        /// Осановка программы
        /// </summary>
        public void Stop()
        {
            isRunning = false;
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        public void Run()
        {
            AddCommands();

            while (isRunning)
            {
                string currStr;

                if (Interactive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("> ");
                    currStr = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    if ((currStr = Reader.ReadLine()) != null)
                    {
                        currStr.Replace("\n", "");
                    }
                    else
                    {
                        Stop();
                    }
                }

                var comParam = Parser.ParseComm(currStr);

                ICommand currComm = null;
                if (comParam != null)
                {
                    currComm = FindCommand(comParam.Name);
                }

                if (currComm != null)
                {
                    currComm.Execute(comParam.Params);
                }
            }
        }

        /// <summary>
        /// Поиск команды в словаре среди имени и его синонимов
        /// </summary>
        /// <param name="currCommand">Имя команды, заданное пользователем</param>
        /// <returns>Возвращает экземпляр класса команды</returns>
        private ICommand FindCommand(string currCommand)
        {
            currCommand = currCommand.ToLower();
            try
            {
                // Проверка наличия в словаре по имени
                if (AllComm.ContainsKey(currCommand))
                {
                    return AllComm[currCommand];
                }
                throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Команда '{0}' не найдена", currCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
