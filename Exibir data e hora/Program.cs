//Crie um aplicativo console para exibir a data e hora do computador

namespace Atividade_3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Data: {DateTime.Now.ToShortDateString()} - Hora: {DateTime.Now.ToShortTimeString()}");
    }
}
