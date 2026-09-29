internal class Conta
{
    public int Numero { get; }
    public string Titular { get; }
    public decimal Saldo { get; private set; }

    public Conta(int numero, string titular)
    {
        Numero = numero;
        Titular = titular;
        Saldo = 0;
    }

    public void Depositar(decimal deposito)
    {
        if (deposito > 0)
        {
            Saldo += deposito;
        }
    }

    public bool Levantar(decimal levantamento)
    {
        if (levantamento > 0 && levantamento <= Saldo)
        {
            Saldo -= levantamento;
            return true;
        }

        return false;
    }
}


class Program
{
    static void Main()
    {
        Conta conta = new Conta(1, "João Silva");

        int opcao;

        do
        {
            // Escolher uma das opções abaixo
            Console.WriteLine("\n===== BANCO =====");
            Console.WriteLine("1 - Consultar saldo");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Levantar");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    Console.WriteLine($"Consultar Saldo: {conta.Saldo:C}");
                    break;

                case 2:
                    Console.Write("Valor a depositar: ");
                    decimal deposito = decimal.Parse(Console.ReadLine()!);

                    if (deposito > 0)
                    {
                        conta.Depositar(deposito);
                        Console.WriteLine("Depósito efetuado!");
                    }
                    else
                    {
                        Console.WriteLine("O valor deve ser positivo.");
                    }

                    break;

                case 3:
                    Console.Write("Valor a levantar: ");
                    decimal levantamento = decimal.Parse(Console.ReadLine()!);

                    if (conta.Levantar(levantamento))
                    {
                        Console.WriteLine("Levantamento efetuado!");
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente ou valor inválido.");
                    }

                    break;

                case 4:
                    Console.WriteLine("Obrigado por utilizar o banco!");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 4);
    }
}
