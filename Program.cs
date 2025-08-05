public class Program
{
    /*
 * Trabalho Final - Algoritmos e Técnicas de Programação
 * Aluno: Guilherme Vinicius Valbonetti Andrade Silva
 * Curso: Análise e Desenvolvimento de Sistemas - PUC Minas
 * Objetivo: Sistema de gerenciamento de reservas aéreas usando vetores e matrizes.
 * O programa permite:
 * - Importar voos de um arquivo
 * - Realizar e cancelar reservas
 * - Consultar assentos disponíveis
 * - Gerar relatório de ocupação por voo
 * - Exportar dados ao final da execução
 */


    // Declarações dos vetores e matrizes globais
    public static int[] codigosVoos = new int[5];
    public static string[] destinos = new string[5];
    public static int[] assentosDisponiveis = new int[5];
    public static string[,] reservas = new string[5, 50];

    public static void Main()
    {
        int opcao = 0;

        do
        {
            Console.WriteLine("\n------ MENU PRINCIPAL ------");
            Console.WriteLine("1. Importar dados dos voos");
            Console.WriteLine("2. Realizar reserva");
            Console.WriteLine("3. Cancelar reserva");
            Console.WriteLine("4. Consultar assentos disponíveis");
            Console.WriteLine("5. Relatório de ocupação de voos");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

//corrigir questão de relatorio de ocupacao (colocando esse lembrete para quando eu entrar no codigo novamente)


            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ImportarVoos.Rodar(codigosVoos, destinos, assentosDisponiveis);
                    break;

                // Os cases a seguir verificam se os dados dos voos foram importados (opção 1)
                // antes de permitir continuar.
                case 2:
                    if (!VoosCarregados())
                    {
                        Console.WriteLine("Primeiro importe os dados dos voos (opção 1).");
                    }
                    else
                    {
                        RealizarReserva.Rodar(codigosVoos, destinos, assentosDisponiveis, reservas);
                    }
                    break;

                case 3:
                    if (!VoosCarregados())
                    {
                        Console.WriteLine("Primeiro importe os dados dos voos (opção 1).");
                    }
                    else
                    {
                        CancelarReserva.Rodar(codigosVoos, destinos, reservas, assentosDisponiveis);
                    }
                    break;

                case 4:
                    if (!VoosCarregados())
                    {
                        Console.WriteLine("Primeiro importe os dados dos voos (opção 1).");
                    }
                    else
                    {
                        ConsultarAssentosDisponiveis.Rodar(codigosVoos, destinos, reservas);
                    }
                    break;

                case 5:
                    if (!VoosCarregados())
                    {
                        Console.WriteLine("Primeiro importe os dados dos voos (opção 1).");
                    }
                    else
                    {
                        RelatorioOcupacao.Rodar(codigosVoos, destinos, reservas);
                    }
                    break;

                case 6:
                    if (!VoosCarregados())
                    {
                        Console.WriteLine("Nenhum voo foi importado, não é possível exportar o relatório.");
                    }
                    else
                    {
                        ExportarRelatorioFinal.Rodar(codigosVoos, assentosDisponiveis);
                    }
                    Console.WriteLine("Encerrando o programa.");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

        } while (opcao != 6);
    }

    // Função simples para verificar se os voos foram carregados
    public static bool VoosCarregados()
    {
        return codigosVoos[0] != 0;
    }
}
