/*
Escreva um programa console que exiba todos os números ímpares de uma faixa de
valor informado pelo usuário. O usuário deve solicitar o número inicial e final.
USANDO A ESTRUTURA DE REPETIÇÃO WHILE.
*/

namespace Atividade_6;

class Program
{
    static void Main(string[] args)
    {
        string resposta;
        int valorInicial;
        int valorFinal;
        
        do
        {
            Console.Write("Digite o valor inicial: ");
            resposta = Console.ReadLine()!;

            if (int.TryParse(resposta, out valorInicial))
            {
                break;
            }

            Console.WriteLine("Entrada inválida!");
            Thread.Sleep(1500);
            Console.Clear();
        }while(true);

        do
        {
            Console.Write("Digite o valor final: ");
            resposta = Console.ReadLine()!;

            if (int.TryParse(resposta, out valorFinal))
            {
                break;
            }

            Console.WriteLine("Entrada inválida!");
            Thread.Sleep(1500);
            Console.Clear();
        } while (true);

        Console.Write($"Números ímpares de {valorInicial} a {valorFinal}: ");

        while (valorInicial <= valorFinal)
        {
            if (valorInicial % 2 != 0)
            {
                Console.Write($"{valorInicial} ");
            }
            valorInicial++;
        }

        Console.Write("\n\nPressione qualque tecla para fechar...");
        Console.ReadKey();    
    }
}
