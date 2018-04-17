using System;
using System.Collections.Generic;

namespace FirstLab.Commands
{
    /// <summary>
    /// Очистка консоли
    /// </summary>
    class Clear : ICommand
    {
    public string Name
    {
        get { return "clear"; }
    }

    public string Help
    {
        get { return "Очистить консоль"; }
    }

    public string[] Synonyms
    {
        get { return new[] {"clr", "clean"}; }
    }

    public void Execute(List<int> param)
    {
        Console.Clear();
    }
    }
}
