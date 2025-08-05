
public class CancelarReserva
{
    public static void Rodar(int[] codigosVoos, string[] destinos, string[,] reservas, int[] assentosDisponiveis)
    {
        Console.WriteLine("\n--- CANCELAR RESERVA ---");

        // Pedir código do voo
        Console.Write("Digite o código do voo: ");
        int codigoVoo = int.Parse(Console.ReadLine());

        // Procurar voo
        int indiceVoo = -1;
        for (int i = 0; i < codigosVoos.Length; i++)
        {
            if (codigosVoos[i] == codigoVoo)
            {
                indiceVoo = i;
                break;
            }
        }

        if (indiceVoo == -1)
        {
            Console.WriteLine("Erro: Voo não encontrado!");
            return;
        }

        // Pedir número do assento
        Console.Write("Digite o número do assento (1 a 50): ");
        int numeroAssento = int.Parse(Console.ReadLine());

        if (numeroAssento < 1 || numeroAssento > 50)
        {
            Console.WriteLine("Erro: Assento inválido!");
            return;
        }

        // Verificar se o assento está reservado
        if (reservas[indiceVoo, numeroAssento - 1] == null)
        {
            Console.WriteLine("Erro: Assento já está livre!");
        }
        else
        {
            // Cancelar reserva
            Console.WriteLine($"Cancelando reserva de {reservas[indiceVoo, numeroAssento - 1]}...");
            reservas[indiceVoo, numeroAssento - 1] = null;
            assentosDisponiveis[indiceVoo]++;
            Console.WriteLine("Cancelamento concluído!");

            // Atualizar o arquivo voos.txt
            AtualizarArquivoVoos(codigosVoos, destinos, assentosDisponiveis);
            AtualizarReservasTxt(codigosVoos, reservas);
        }
    }

    // Reescreve o arquivo voos.txt com dados atualizados
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

    static void AtualizarReservasTxt(int[] codigosVoos, string[,] reservas)
{
    StreamWriter sw = new StreamWriter("reservas.txt", false); // sobrescreve

    for (int i = 0; i < codigosVoos.Length; i++)
    {
        for (int j = 0; j < 50; j++)
        {
            if (reservas[i, j] != null)
            {
                sw.WriteLine(codigosVoos[i] + ";" + (j + 1) + ";" + reservas[i, j]);
            }
        }
    }

    sw.Close(); // fecha para salvar
}

}
