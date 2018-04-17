using System.Collections.Generic;

namespace FirstLab.Commands
{
    interface ICommand
    {
        /// <summary>
        /// Название команды
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Информация о команде и ее использовании
        /// </summary>
        string Help { get; }

        /// <summary>
        /// Синонимы команды
        /// </summary>
        string[] Synonyms { get; }

        /// <summary>
        /// Исполнение команды
        /// </summary>
        /// <param name="param">Возможные параметры команды</param>
        void Execute(List<int> param);
    }
}
