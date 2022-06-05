using System;
using System.Collections.Generic;


namespace Str_Queue_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "A+(45s-f(X)*(B-C))"; // текст
            Stack<int> position = new Stack<int> { }; // левая скобка
            Stack<int> result = new Stack<int> { }; // все скобки
            int lengthOfMass = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(') // записываю левую скобку
                {
                    position.Push(i+1);
                }
                if (text[i] == ')') // записываю обе скобки
                {
                    result.Push(position.Pop());
                    result.Push(i+1);
                    lengthOfMass++;
                }
            }
            int[,] mass = new int[lengthOfMass, 2]; // двумерный массив в котором упорядочим результат
            for (int i = 0; i < lengthOfMass; i++) // заполняю массив
            {
                for (int j = 0; j < 2; j++)
                {
                    mass[i, j] = result.Pop();
                }
            }

            

            for (int i = 0; i < lengthOfMass; i++) // сортировка массива
            {
                for (int j = 0; j < lengthOfMass - 1; j++)
                {
                    if (mass[j,1] > mass[j+1,1])
                    {
                        int swap1;
                        int swap2;
                        swap1 = mass[j, 1];
                        swap2 = mass[j, 0];
                        mass[j, 1] = mass[j + 1, 1];
                        mass[j + 1, 1] = swap1;
                        mass[j, 0] = mass[j + 1, 0];
                        mass[j + 1, 0] = swap2;
                    }
                }
            }

            for (int i = 0; i < lengthOfMass; i++) // сортировка массива
            {
                for (int j = 1; j >= 0; j --)
                {
                    Console.Write(mass[i, j] + " ");
                }
            }
        }
    }
}
