namespace Atividade_2;

class Program
{
    struct Cliente
    {
        public string Cpf;
        public string Nome;
        public int Senha;
    }

    static Cliente[] fila = new Cliente[100];   //fila de clientes

    static void Main(string[] args)
    {
        int senha = 1;  //senha inicial
        int quantidadeDeClientes = 0;

        while (true)
        {
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("1 - Cadastrar na fila.");
            Console.WriteLine("2 - Listar fila.");
            Console.WriteLine("3 - Atender.");
            Console.WriteLine("4 - Sair.");
            Console.Write("\nEscolha: ");
            string resposta = Console.ReadLine()!;

            int opcao;
            if (!int.TryParse(resposta, out opcao) || opcao < 1 || opcao > 4)   //impede entrada inadequada de dados
            {
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(1500);
                Console.Clear();
                continue;   //volta ao início do loop while
            }

            Console.Clear();
            switch (opcao)
            {
                case 1:
                    CadastrarNaFila(quantidadeDeClientes, senha);
                    quantidadeDeClientes++;
                    senha++;
                    break;
                case 2:
                    ListarFila(quantidadeDeClientes);
                    break;
                case 3:
                    //a função retorna --quantidadeDeClientes caso haja clientes para atender.
                    //Caso a fila esteja vazia, retorna quantidadeDeClientes, ou seja, 0.
                    quantidadeDeClientes = AtendeCliente(quantidadeDeClientes);
                    break;
                case 4:
                    return;
            }
        }
    }

    static void CadastrarNaFila(int quantidadeDeClientes, int senha)
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine()!;

        string cpf;
        while (true)
        {
            Console.Write("Digite o CPF (apenas números): ");
            cpf = Console.ReadLine()!;

            if (CpfEValido(cpf))
            {
                break;
            }

            Console.WriteLine("CPF inválido!");
            Thread.Sleep(1500);
            Console.Clear();
        }

        fila[quantidadeDeClientes].Nome = nome;
        fila[quantidadeDeClientes].Cpf = cpf;
        fila[quantidadeDeClientes].Senha = senha;

        Console.WriteLine($"Cliente {nome} cadastrado com senha {senha}!");
        Thread.Sleep(1500);
        Console.Clear();
    }

    static bool CpfEValido(string cpf)
    {
        if (!cpf.All(char.IsDigit) || cpf.Length != 11) //caso o cpf contenha caracteres que não sejam números ou tenha tamanho diferente de 11, retorna falso
        {
            return false;
        }

        int primeiroVerificador = 0;
        int segundoVerificador = 0;
        int multiplicador = 2;
        int soma = 0;

        for (int i = 8; i >= 0; i--)
        {
            int valorNumerico = cpf[i] - '0'; // Converte o caractere para o valor numérico correto, considerando a tabela ASCII
            soma += valorNumerico * multiplicador;
            multiplicador++;
        }

        primeiroVerificador = (soma * 10) % 11;
        if (primeiroVerificador == 10)
        {
            primeiroVerificador = 0;
        }

        if (primeiroVerificador != (cpf[9] - '0'))
        {
            return false;
        }

        soma = 0;
        multiplicador = 2;

        for (int i = 9; i >= 0; i--)
        {
            int valorNumerico = cpf[i] - '0'; // Converte o caractere para o valor numérico correto, considerando a tabela ASCII
            soma += valorNumerico * multiplicador;
            multiplicador++;
        }

        segundoVerificador = (soma * 10) % 11;
        if (segundoVerificador == 10)
        {
            segundoVerificador = 0;
        }

        if (segundoVerificador != (cpf[10] - '0'))
        {
            return false;
        }

        return true;
    }

    static void ListarFila(int quantidadeDeClientes)
    {
        if (quantidadeDeClientes == 0)
        {
            Console.WriteLine("A fila está vazia!");
            Thread.Sleep(1500);
            Console.Clear();
            return;
        }

        foreach (Cliente cliente in fila)
        {
            if (!string.IsNullOrEmpty(cliente.Cpf)) //só imprime na tela caso o cpf não esteja vazio. Necessário pois o array contém várias posições vazias.
            {
                Console.WriteLine($"Senha: {cliente.Senha} - Nome: {cliente.Nome} - CPF: {cliente.Cpf}");
            }
        }
        Console.Write("\nPressione qualquer tecla...");
        Console.ReadKey();
        Console.Clear();
    }

    static int AtendeCliente(int quantidadeDeClientes)
    {
        if (quantidadeDeClientes > 0)
        {
            Console.WriteLine($"Atendendo cliente com senha {fila[0].Senha}.");

            for (int i = 0; i < quantidadeDeClientes - 1; i++)  //loop que avança em uma posição todos na fila depois da pessoa atendida
            {
                fila[i] = fila[i + 1];
            }

            fila[quantidadeDeClientes - 1] = new Cliente(); //preenche a posição anteriormente ocupada pela última pessoa com um Cliente vazio
            Console.Write("\nPressione qualquer tecla...");
            Console.ReadKey();
            Console.Clear();
            return --quantidadeDeClientes;
        }

        Console.WriteLine("Não há clientes para atender!");
        Thread.Sleep(1500);
        Console.Clear();
        return quantidadeDeClientes;
    }
}
