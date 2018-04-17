using System.Collections.Generic;

namespace FirstLab
{
    /// <summary>
    /// Хранение данных для проверки алгоритмов
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// Количество итераций измерения времени работы алгоритма для
        /// вычисления среднего времени.
        /// </summary>
        public static int QuantIterations { get; set; }

        /// <summary>
        /// Последовательность данных для проверки алгоритмов
        /// </summary>
        public static List<int> DataSequence { get; set; }
    }
}
