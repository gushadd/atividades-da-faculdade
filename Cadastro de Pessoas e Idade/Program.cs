/*
Crie um programa console que simule um menu com as opções (1) Cadastrar, (2)
Listar,(3) Mais Velho (4) Sair. O Sistema deve cadastrar pelo menos 5 pessoas
com nome e idade, ao final da execução o programa deve exibir a pessoa mais
velha.
*/

namespace Atividade_1;

class Program
{
    //lista que armazena o nome e a idade da pessoa
    static List<(string Nome, int Idade)> pessoas = new List<(string nome, int idade)>();
    static void Main(string[] args)
    {
        bool rodaPrograma = true;   

        do
        {
            string resposta;
            //loop repete sempre que a opção for inválida
            do
            {
                Console.Clear();
                ExibeMenu();
                Console.Write("\nEscolha uma opção: ");
                resposta = Console.ReadLine()!;

            } while (OpcaoErrada(resposta));

            int opcao = Convert.ToInt32(resposta);
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    CadastraPessoa();
                    break;
                case 2:
                    ListaNomesEIdades();
                    break;
                case 3:
                    MostraMaisVelho();
                    break;
                case 4:
                    rodaPrograma = false;
                    Console.Clear();
                    Console.WriteLine("Tchau!");
                    Thread.Sleep(2000);
                    break;
            }
        } while (rodaPrograma);
    }

    static void ExibeMenu ()
    {
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Mais Velho");
        Console.WriteLine("4 - Sair");
    }

    static bool OpcaoErrada (string resposta)
    {
        //caso a resposta tiver mais de um caracter, ou não for um número, ou for número menor que 1 ou maior que 4, retorna verdadeiro,
        //ou seja, a opção escolhida não existe
        if (resposta.Length != 1 || !char.IsDigit(Convert.ToChar(resposta)) || Convert.ToInt32(resposta) < 1 || Convert.ToInt32(resposta) > 4)
        {
            Console.WriteLine("Opção Inválida!");
            Thread.Sleep(2000);
            return true;
        }
        //caso contrário, retorna falso, e a opção é válida
        return false;
    }

    static void CadastraPessoa ()
    {   
        Console.Write("Digite o nome da pessoa: ");
        string resposta = Console.ReadLine()!;    
        string nome = LetraInicialMaiuscula(resposta);

        int idade;
        do
        {
            Console.Write("Digite a idade da pessoa: ");
            resposta = Console.ReadLine()!;

            //caso resposta for número inteiro maior ou igual a zero
            if (int.TryParse(resposta, out idade) && Convert.ToInt32(resposta) >= 0)
            {   
                //sai do loop
                break;
            }

            //caso contrário, a idade é inválida
            Console.WriteLine("Idade inválida! ");
            
        } while (true); 

        pessoas.Add((nome, idade));
    }

    static string LetraInicialMaiuscula (string resposta)
    {
        //array de strings que armazena cada nome digitado separado por espaços
        string[] auxiliar = resposta.Split(' ');
        //loop que percorre cada elemento no array
        for (int i = 0; i < auxiliar.Length; i++)
        {
            if (!string.IsNullOrEmpty(auxiliar[i]))
            {
                //converte a primeira letra de cada nome em maiúscula e concatena com o 
                //restante do nome
                auxiliar[i] = char.ToUpper(auxiliar[i][0]) + auxiliar[i].Substring(1);
            }
        }

        //retorna os nomes todos juntos, separados por espaços, em uma única string
        return string.Join(" ", auxiliar);
    }

    static void ListaNomesEIdades ()
    {
        foreach (var pessoa in pessoas)
        {
            Console.WriteLine($"{pessoa.Nome} - {pessoa.Idade} anos");
        }
        Console.Write("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void MostraMaisVelho ()
    {
        int maisVelhoIdade = 0;
        string maisVelhoNome = "";
        
        foreach (var pessoa in pessoas)
        {
            if (pessoa.Idade > maisVelhoIdade)
            {
                maisVelhoIdade = pessoa.Idade;
                maisVelhoNome = pessoa.Nome;
            }
        }

        Console.WriteLine($"Pessoa mais velha: {maisVelhoNome} - {maisVelhoIdade} anos.");
        Console.Write("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
