public class ExportarRelatorioFinal
{
    // Gera um arquivo com o resumo da ocupação de todos os voos
    public static void Rodar(int[] codigosVoos, int[] assentosDisponiveis)
    {
        Console.WriteLine("\n--- GERANDO RELATÓRIO FINAL ---");

        // Cria (ou sobrescreve) o arquivo relatorio_final.txt para escrever o relatório
        using (StreamWriter writer = new StreamWriter("relatorio_final.txt"))
        {
            writer.WriteLine("=== RELATÓRIO DE VOOS ===");

            // Percorre todos os voos cadastrados
            for (int i = 0; i < codigosVoos.Length; i++)
            {
                // Se o voo existe (foi importado), gera a linha do relatório
                if (codigosVoos[i] != 0)
                {
                    int reservados = 50 - assentosDisponiveis[i]; // Calcula quantos assentos foram reservados
                    writer.WriteLine($"Voo {codigosVoos[i]}: {reservados} reservados | {assentosDisponiveis[i]} livres");
                }
            }
        }

        // Mensagem de confirmação no console
        Console.WriteLine("Relatório salvo em 'relatorio_final.txt'!");
    }
}
