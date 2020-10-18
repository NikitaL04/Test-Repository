using System;
using System.Linq;

namespace Defender1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Quantity = new int[] {0, 0, 0, 0, 0, 0};
            //int[] QuantitySort = new int[] {0, 0, 0, 0, 0, 0};
            string[] Name = new string[] {"Гамбургер", "Чикенбургер", "Чизбургер", "Вегангер", "Блючизбургер", "Лосось Тар-тар" };
            double[] PricesStart = new double[] {1.9, 1.7, 2.2, 3.4, 3.9, 6.4};
            double[] PricesFinish = new double[] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0};
            int MenuInput = 0;
            int Intermediate = 0;

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Menu(Name);
            while (MenuInput != 7)
            {
                while (!int.TryParse(Console.ReadLine(), out MenuInput) || (MenuInput <= 0 || MenuInput >= 8))
                    Console.WriteLine("Введите повторно");

                if (MenuInput != 7)
                {
                    Console.WriteLine($"Вы выбрали {Name[MenuInput - 1]}");
                    Console.WriteLine("Введите количество:");
                    Intermediate = Convert.ToInt32(Console.ReadLine());
                    Quantity[MenuInput - 1] += Intermediate;
                }
                else
                {
                    Console.Clear();
                    Output(Quantity, /*QuantitySort,*/ Name, PricesStart, PricesFinish);
                }
            }
        }

        static void Menu(string[] name)
        {
            Console.WriteLine("     Сделать заказ    ");
            Console.WriteLine("****************************");
            Console.WriteLine($"1. - {name[0]}         -1,90 р.");
            Console.WriteLine($"2. - {name[1]}       -1,70 р.");
            Console.WriteLine($"3. - {name[2]}         -2,20 р.");
            Console.WriteLine($"4. - {name[3]}          -3,40 р.");
            Console.WriteLine($"5. - {name[4]}      -3,90 р.");
            Console.WriteLine($"6. - {name[5]}    -6,40 р.");
            Console.WriteLine("7. Получить чек");
        }

        static void Output(int[] quantity,/* int[] quantity_sort,*/ string[] name, double[] prices_start,double[] prices_finish)
        {
            int i = 0;
            double Sum = 0.0;
            Console.WriteLine("        Ваш чек:      ");
            Console.WriteLine("**********************");

            while(i != quantity.Length)
            {
                if (quantity[i] != 0)
                {
                    Console.WriteLine($"{name[i]}   {quantity[i]} * {prices_start[i]} р.");
                    prices_finish[i] = prices_start[i] * quantity[i];
                }
                i++;
            }
            Sum = prices_finish.Sum();
            Console.WriteLine($"Итого: {Sum} р.");
            Console.WriteLine("Приятного аппетита");


            /*
            int temp_element;
            Array.Copy(quantity, 0, quantity_sort, 0, quantity.Length - 1);
            Array.Sort(quantity_sort);
            for (int i = quantity_sort.Length - 1; quantity_sort[i] != 0; i--)
            {
                temp_element = quantity_sort[i];
                int j = 0;
                while (quantity[j] != temp_element)
                    j++; //номер элемента в массиве количества выбранных блюд
                prices_finish[j] = prices_start[j] * quantity[j];
                Console.WriteLine($"{name[j]}   {quantity[j]} * {prices_start[j]}");
            }
            Sum = prices_finish.Sum();
            Console.WriteLine($"Итого: {Sum}");
            Console.WriteLine("Приятного аппетита");
            */
        }
    }
}
