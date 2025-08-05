public class RealizarReserva
{
    public static void Rodar(int[] codigosVoos, string[] destinos, int[] assentosDisponiveis, string[,] reservas)
    {
        Console.WriteLine("\n--- RESERVA DE ASSENTO ---");

        // Pedir código do voo
        Console.Write("Digite o código do voo: ");
        int codigoVoo = int.Parse(Console.ReadLine());

        // Procurar voo
        //Procura também o indice do voo no vetor codigosVoos
        int indiceVoo = -1;
        for (int i = 0; i < codigosVoos.Length; i++)
        {
            if (codigosVoos[i] == codigoVoo)
            {
                indiceVoo = i;
                break;
            }
        }
        //Caso não encontre
        if (indiceVoo == -1)
        {
            Console.WriteLine("Erro: Voo não encontrado!");
            return;
        }

        // Pedir número do assento
        Console.Write("Digite o número do assento (1 a 50): ");
        int numeroAssento = int.Parse(Console.ReadLine());

        //Para evitar que esteja fora dos assentos disponíveis de 1 a 50
        if (numeroAssento < 1 || numeroAssento > 50)
        {
            Console.WriteLine("Erro: Assento inválido!");
            return;
        }

        // Verificar se assento está ocupado
        if (reservas[indiceVoo, numeroAssento - 1] != null)
        {
            Console.WriteLine("Erro: Assento já ocupado!");
            return;
        }

        // Pedir nome do passageiro
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        // Reservar assento
        reservas[indiceVoo, numeroAssento - 1] = nome;
        assentosDisponiveis[indiceVoo]--;

        // Mostrar confirmação
        Console.WriteLine($"Reserva confirmada! Assento {numeroAssento} no voo {codigoVoo} para {nome}.");

        // Atualizar o arquivo voos.txt e reservas.txt
        AtualizarArquivoVoos(codigosVoos, destinos, assentosDisponiveis);
         AdicionarReservaNoReservas(codigoVoo, numeroAssento, nome);
    }

    // Reescreve o arquivo voos.txt com os dados atualizados
    static void AtualizarArquivoVoos(int[] codigos, string[] destinos, int[] assentos)
    {
        using (StreamWriter sw = new StreamWriter("voos.txt"))
        {
            for (int i = 0; i < codigos.Length; i++)
            {
                sw.WriteLine($"{codigos[i]};{destinos[i]};{assentos[i]}");
            }
        }
    }
    static void AdicionarReservaNoReservas(int codigoVoo, int numeroAssento, string nome)
{
    // Abre o arquivo em modo de adição (append)
    StreamWriter sw = new StreamWriter("reservas.txt", true);

    // Escreve a reserva no formato: codigoVoo;numeroAssento;nome
    sw.WriteLine(codigoVoo + ";" + numeroAssento + ";" + nome);

    // Fecha o arquivo manualmente para salvar as alterações
    sw.Close();
}

}
