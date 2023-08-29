//crie um sistema que permita cadastrar e listar os produtos de um
//estoque; será necessário guardar o código do produto, nome e preço.
//A implementação deve utilizar vetores, um while para simular o menu
//de opções e o switch.

namespace Estoque;

class Program
{
    static int capacidadeMaxima = 500;
    static Produto[] produtos = new Produto[capacidadeMaxima];

    static void Main(string[] args)
    {
        int tamanhoDoEstoque = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1 - Cadastrar produto; ");
            Console.WriteLine("2 - Listar produtos; ");
            Console.WriteLine("3 - Sair. ");
            Console.Write("\nSelecione uma opção: ");
            string resposta = Console.ReadLine()!;

            int opcao;
            if (!int.TryParse(resposta, out opcao) || opcao < 1 || opcao > 3)
            {
                Console.WriteLine("Opção inválida! ");
                Thread.Sleep(1500);
                Console.Clear();
                continue;
            }
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    CadastraProduto(tamanhoDoEstoque);
                    tamanhoDoEstoque++;
                    break;
                case 2:
                    if (tamanhoDoEstoque == 0)
                    {
                        Console.WriteLine("Você ainda não cadastrou produtos!");
                        Thread.Sleep(1500);
                        break;
                    }
                    ListaProdutos(tamanhoDoEstoque);
                    break;
                case 3:
                    return;
            }
        }
    }

    static void CadastraProduto(int indice)
    {
        string resposta; //auxiliar para impedir entrada errada de dados 
        int codigo;
        string nome;
        double preco;

        while (true)
        {
            Console.Write("Digite o código do produto: ");
            resposta = Console.ReadLine()!;

            if (!int.TryParse(resposta, out codigo) || codigo <= 0)
            {
                Console.WriteLine("\nCódigo inválido!\n");
                continue;
            }

            if (JaExisteCodigo(codigo, indice))
            {
                Console.WriteLine("\nCódigo já existe!\n");
                continue;
            }
            Console.Clear();
            break;
        }

        while (true)
        {
            Console.Write("Digite o nome do produto: ");
            resposta = Console.ReadLine()!;

            if (string.IsNullOrEmpty(resposta))
            {
                Console.WriteLine("\nO nome não pode estar vazio!\n");
                continue;
            }

            nome = char.ToUpper(resposta[0]) + resposta.Substring(1).ToLower(); //transforma primeira letra em maiúscula
            Console.Clear();
            break;
        }

        while (true)
        {
            Console.Write("Digite o preço do produto: ");
            resposta = Console.ReadLine()!;

            if (!double.TryParse(resposta, out preco) || preco <= 0)
            {
                Console.WriteLine("\nPreço inválido!\n");
                continue;
            }
            Console.Clear();
            break;
        }

        Produto novoProduto = new Produto(codigo, nome, preco);
        produtos[indice] = novoProduto;

        Console.WriteLine("Produto adicionado!");
        Thread.Sleep(1500);
        Console.Clear();
    }

    static bool JaExisteCodigo(int codigo, int tamanhoDoEstoque)
    {
        for (int i = 0; i < tamanhoDoEstoque; i++)
        {
            if (codigo == produtos[i].Codigo)
            {
                return true;
            }
        }
        return false;
    }

    static void ListaProdutos(int tamanhoDoEstoque)
    {
        Console.WriteLine($"Código\t{"Nome".PadRight(20)}\tPreço\n");

        for (int i = 0; i < tamanhoDoEstoque; i++)
        {
            Console.WriteLine($"{produtos[i].Codigo}\t{produtos[i].Nome.PadRight(20)}\t{produtos[i].Preco:C}");
        }

        Console.Write("\n\nPressione qualquer tecla...");
        Console.ReadKey();
    }
}

class Produto
{
    public int Codigo { get; }
    public string Nome { get; }
    public double Preco { get; }
    public Produto(int codigo, string nome, double preco)
    {
        Codigo = codigo;
        Nome = nome;
        Preco = preco;
    }
}