using DesignPatterns.Utils;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{

// Une method FindSumPair doit retourner un tableau de deux entiers
//Contenant les indices d'une paire d'entiers dans le tableau dont la somme est k
//Le premier indice dans le tableax est 0,
//Le premier entier de votre sortie doit représenter l'indice inférieur.
//[0,0] doit etre retourné si aucune paire n'est trouvé.
//Dans le cas ou il existe plusieurs paires possibles dont la somme est égale
//à la cible.
//retournez l paire dont l'indice de gauche, privilégiez la paire dont l'indice de droite
//est le plus bas

    public class FindSumPairDemo : IExecuteDemo
    {
        public int[] FindSumPair2(int[] numbers, int k)
        {
            // Initialize output array with default values
            var output = new int[] { 0, 0 };

            // Iterate through the numbers array
            for (int i = 0; i < numbers.Length; i++)
            {
                // Iterate through the array again starting from the next element
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    // Check if the current pair's sum equals k
                    if (numbers[i] + numbers[j] == k)
                    {
                        // If output array has default values, set indices directly
                        if (output[0] == 0 && output[1] == 0)
                        {
                            output[0] = i;
                            output[1] = j;
                        }
                        else
                        {
                            // Compare indices to find the pair with the lower left index
                            if (i < output[0] || (i == output[0] && j < output[1]))
                            {
                                output[0] = i;
                                output[1] = j;
                            }
                        }
                    }
                }
            }

            // Return the output array
            return output;
        }


        public int[] FindSumPair(int[] numbers, int k)
        {
            var output = new int[] { 0,0 };
           for(int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == j)
                        continue;

                    if(numbers[i] + numbers[j] == k)
                    {
                        if (output[0] == 0 && output[1] == 0)
                        {
                            output.SetValue(Math.Min(i, j), 0);
                            output.SetValue(Math.Max(i, j), 1);
                        }
                        else
                        {
                            if (output[0] < Math.Min(i, j))
                            {
                                continue;
                            }
                            else if(output[0] == Math.Min(i, j) && output[1] < Math.Max(i, j))
                            {
                                continue;
                            }
                            else
                            {
                                output.SetValue(Math.Min(i, j), 0);
                                output.SetValue(Math.Max(i, j), 1);
                            }
                        }
                    }
                }
            }
            

            return output;
        }
        public void Execute()
        {
            var numbers = new int[] { 10, 2, 8, 4, 5 };
            int k = 13;
            var result1 = FindSumPair(numbers, k);
            Console.WriteLine($"[{result1[0]}, {result1[1]}]");

            var result2 = FindSumPair2(numbers, k);
            Console.WriteLine($"[{result2[0]}, {result2[1]}]");
        }
    }
}
