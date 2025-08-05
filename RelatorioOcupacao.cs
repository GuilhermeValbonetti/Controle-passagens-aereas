using System;

public class RelatorioOcupacao
{
    public static void Rodar(int[] codigosVoos, string[] destinos, string[,] reservas)
    {
        Console.WriteLine("\n--- RELATÓRIO DE OCUPAÇÃO ---");

        // Pedir código do voo
        Console.Write("Digite o código do voo: ");
        int codigoVoo = int.Parse(Console.ReadLine());

        // Verificar se o voo existe
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

        // Mostrar cabeçalho do voo
        Console.WriteLine($"\nVoo {codigoVoo} - Destino: {destinos[indiceVoo]}");

        int totalReservados = 0;

        // Listar os 50 assentos com nome ou "Disponível"
        for (int i = 0; i < 50; i++)
        {
            if (reservas[indiceVoo, i] != null)
            {
                Console.WriteLine($"Assento {i + 1}: {reservas[indiceVoo, i]}");
                totalReservados++;
            }
            else
            {
                Console.WriteLine($"Assento {i + 1}: Disponível");
            }
        }

        // Mostrar resumo
        Console.WriteLine("\n=== RESUMO ===");
        Console.WriteLine($"Total de assentos reservados: {totalReservados}");
        Console.WriteLine($"Total de assentos disponíveis: {50 - totalReservados}");
    }
}
