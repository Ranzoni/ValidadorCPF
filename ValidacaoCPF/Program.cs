using ValidacaoCPF;

do
{
    Console.Clear();
    Console.WriteLine("Informe o CPF COMPLETO:");
    var cpf = Console.ReadLine();

    Console.Clear();

    if (Cpf.Validar(cpf))
        Console.WriteLine("CPF válido");
    else
        Console.WriteLine("CPF inválido");

    Console.WriteLine();
    Console.WriteLine("Deseja continuar?");
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não");
    var opcao = int.Parse(Console.ReadLine() ?? "");
    if (opcao != 1)
        break;

} while (true);
