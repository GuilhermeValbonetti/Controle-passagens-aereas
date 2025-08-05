public class ConsultarAssentosDisponiveis
{
    public static void Rodar(int[] codigosVoos, string[] destinos, string[,] reservas)
    {
        Console.WriteLine("\n--- ASSENTOS DISPONÍVEIS ---");

        // Percorre os voos existentes
        for (int i = 0; i < codigosVoos.Length; i++)
        {
            // Verifica se o voo foi importado (código diferente de 0)
            if (codigosVoos[i] != 0)
            {
                Console.WriteLine($"\nVoo {codigosVoos[i]} - {destinos[i]}:");
                Console.Write("Assentos livres: ");

                // Percorre os 50 assentos do voo
                for (int j = 0; j < 50; j++)
                {
                    // Se o assento está vazio, ele está disponível
                    if (reservas[i, j] == null)
                    {
                        Console.Write($"{j + 1} ");

                        // Quebra de linha a cada 10 assentos
                        if ((j + 1) % 10 == 0)
                            Console.Write("\n");
                    }
                }
            }
        }
    }
}
