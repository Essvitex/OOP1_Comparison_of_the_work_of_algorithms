using System.Collections.Generic;

namespace FirstLab.Commands
{
    /// <summary>
    /// Завершение работы программы
    /// </summary>
    class ExitCommand : ICommand
    {
        public string Name
        {
            get { return "exit"; }
        }

        public string Help
        {
            get { return "Выход из программы"; }
        }

        public string[] Synonyms
        {
            get { return new[] {"ext", "out"}; }
        }

        Processing app;
        public ExitCommand(Processing app)
        {
            this.app = app;
        }

        public void Execute(List<int> param)
        {
            app.Stop();
        }
    }
}
