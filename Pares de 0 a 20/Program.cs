//Escreva um programa console que exiba todos os números pares de 0 a 20,
//USANDO A ESTRUTURA DE REPETIÇÃO FOR.

namespace Atividade_4;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Números pares de 0 a 20: ");
        for (int i = 0; i <=20; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write($"{i} ");
            }
        }
        Console.Write("\n\nPressione qualquer tecla...");
        Console.ReadKey();
    }
}
