using System.Collections.Generic;

namespace FirstLab
{
    /// <summary>
    /// Команда в удобном для исполнителя виде
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Название команды
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Параметры команды
        /// </summary>
        public List<int> Params { get; set; }

        public Command(string name, List<int> param)
        {
            Name = name;
            Params = param;
        }
    }
}
