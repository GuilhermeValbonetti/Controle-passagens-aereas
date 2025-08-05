public class ImportarVoos
{
    // Preenche os vetores com dados iniciais
    public static void Rodar(int[] codigosVoos, string[] destinos, int[] assentosDisponiveis)
    {
        Console.WriteLine("\n--- IMPORTANDO VOOS ---");

        //Verificação da existencia do arquivo
        if (!File.Exists("voos.txt"))
        {
            Console.WriteLine("Erro: Arquivo 'voos.txt' não encontrado!");
            return;
        }
        else
        {
            //ler todo o arquivo
            string[] linhas = File.ReadAllLines("voos.txt");
            //Fazer com q se tiver mais de 5 linhas, carregar somente as 5 primeiras
            int totalVoos = linhas.Length > 5 ? 5 : linhas.Length;

            //Looping para passar pelas 5 linhas
            for (int i = 0; i < totalVoos; i++)
            {
                //cada linha dividida por ;
                string[] dados = linhas[i].Split(';');
                codigosVoos[i] = int.Parse(dados[0]);
                destinos[i] = dados[1];
                assentosDisponiveis[i] = int.Parse(dados[2]);
            }
            //Carrega para o usuário
            
            Console.WriteLine($"{totalVoos} voos carregados com sucesso!");

            for (int i = 0; i < totalVoos; i++)
            {
                Console.WriteLine($"Voo {codigosVoos[i]} - Destino: {destinos[i]} - Assentos disponíveis: {assentosDisponiveis[i]}");
            }
        }
        

    }
}