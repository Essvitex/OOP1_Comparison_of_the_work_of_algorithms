using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FirstLab
{
    /// <summary>
    /// Разбиение строки по пробелам, формирование списка параметров команды
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Разбиение строки по пробелам, формирование списка параметров команды
        /// </summary>
        /// <param name="str">строка команды для парсинга</param>
        /// <returns>
        /// возвращает false если пустая строка, в таком случае завершается
        /// работа программы
        /// </returns>
        public static Command ParseComm(string str)
        {
            try
            {
                var currListComm =
                    str.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                if (currListComm.Length == 0)
                {
                    return null;
                }

                var param = new List<int>();

                for (var i = 1; i < currListComm.Length; i++)
                {
                    int currParam;
                    if (currListComm[i].Select(ch => !char.IsLetter(ch)).Any(flag => !flag) 
                        || !int.TryParse(currListComm[i], out currParam))
                    {
                        throw new InvalidDataException("символ '" + currListComm[i] + 
                                                       "', позиция " + i);
                    }
                    param.Add(currParam);
                }
                return new Command(currListComm[0], param);
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine("Параметр должен содержать только целые числа " + e.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("Ошибка при парсинге: {0}", x);
            }
            return null;
        }
    }
}
