using System;

namespace FirstLab
{
    ///<summary>
    ///Алгоритмы сортировки
    ///</summary>
    public class Sorts
    {
        ///<summary>
        ///Вспомогательный метод, меняет местами два элемента
        ///</summary>
        ///<param name = "aFirstArg">Первый меняемый элемент</param>
        ///<param name = "aSecondArg">Второй меняемый элемент</param>
        public static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            //Временная (вспомогательная) переменная, хранит значение первого элемента
             var tmpParam = aFirstArg;

            aFirstArg = aSecondArg;
            aSecondArg = tmpParam;
        }

        ///<summary>
        ///Метод сортировки пузырьком
        ///</summary>
        ///<param name = "data">Сортируемый массив</param>
        public static void Bubble(int[] data)
        {
            //Основной цикл (количество повторений равно количеству элементов массива)
            for (int i = 0; i < data.Length; i++)
            {
                //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                for (int j = 0; j < data.Length - 1 - i; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        Swap(ref data[j], ref data[j + 1]);
                    }
                }
            }
        }

        ///<summary>
        ///Сортировка методом Шелла
        ///</summary>
        ///<param name = "data">Сортируемый массив</param>
        public static void Shell(int[] data)
        {
            int step; //шаг разбиения массива

            for (step = data.Length / 2; step > 0; step = step / 2)
            {
                for (int i = step; i < data.Length; i++)
                {
                    for (int j = i - step; j >= 0; j = j - step)
                    {
                        if (data[j] > data[j + step])
                        {
                            Swap(ref data[j], ref data[j + step]);
                        }
                    }
                }
            }
        }

        ///<summary>
        ///Метод быстрой сортировки
        ///</summary>
        ///<param name = "data">Сортируемый массив</param>
        public static void Quick(int[] data)
        {
            QuickSort(data, 0, data.Length - 1);
        }

        /// <summary>
        /// Встроенная сортировка
        /// </summary>
        /// <param name="data">Сортируемый массив</param>
        public static void DefaultSort(int[] data)
        {
            Array.Sort(data);
        }

        /// <summary>
        /// Рекурсивный метод быстрой сортировки
        /// </summary>
        /// <param name="arr">Массив сортируемых данных</param>
        /// <param name="first">Индекс первого элемента массива</param>
        /// <param name="last">Индекс последнего элемента массива</param>
        private static void QuickSort(int[] arr, int first, int last)
        {
            var p = arr[(last - first) / 2 + first];
            int i = first, j = last;

            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i;
                while (arr[j] > p && j >= first) --j;
                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    ++i; --j;
                }
            }
            if (j > first)
            {
                QuickSort(arr, first, j);
            }
            if (i < last)
            {
                QuickSort(arr, i, last);
            }
        }
    }
}