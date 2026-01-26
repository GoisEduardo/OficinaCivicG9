using Desafio05_POO;
using System.Text.Json; // Adicione este using

namespace Desafio07_IntegirdadeAPersistencia;

public class Program
{
    public static void Main(string[] args)
    {
        string caminhoArquivo = "veiculo.json";
        Veiculo carro;

        if (File.Exists(caminhoArquivo))
        {
            string jsonRecuparado = File.ReadAllText(caminhoArquivo);
            carro = JsonSerializer.Deserialize<Veiculo>(jsonRecuparado)!;
        }
        else
        {
            carro = new("Civic G9", 120000, 110000);
        }

        int escolha = 0;
        List<string> pecasParaRevisao = ["Filtro de Óleo", "Pastilha de Freio", "Filtro de Cabine", "Velas de Ignição"];


        do
        {
            string opcao = OpcaoDeMenu();

            if (!int.TryParse(opcao, out escolha))
            {
                Console.WriteLine("Escolha inválida");
                continue; // Pula o restante e volta para o início do menu
            }

            string servico = escolha switch
            {
                1 => TrocarOleo(carro),
                2 => ConversorDePressao(),
                3 => ExibirPecas(pecasParaRevisao),
                4 => AdicionarPecas(pecasParaRevisao),
                5 => AtualizarKm(carro),
                6 => SalvarESair(carro, caminhoArquivo),
                _ => "Opção não reconhecida pelo sistema."
            };

            Console.WriteLine(servico);

            if (escolha != 6)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
            }

        } while (escolha != 6); // O loop para quando escolha for 3
    }

    private static string OpcaoDeMenu()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("Painel de Manutenção");
        Console.WriteLine("--------------------");

        Console.WriteLine("Exibindo menu de serviços...");
        Console.WriteLine("1 - Verificar troca de óleo.");
        Console.WriteLine("2 - Verificar a pressão dos Pneus.");
        Console.WriteLine("3 - Verificar revisão de peças.");
        Console.WriteLine("4 - Adicionar peças a lista de revisão.");
        Console.WriteLine("5 - Atualizar quilometragem.");
        Console.WriteLine("6 - Sair \n");
        Console.Write("Digite opção desejada: ");
        string opcao = Console.ReadLine()!;
        Console.Clear();
        return opcao;
    }

    private static string ConversorDePressao()
    {
        Console.Write("Digite a pressão de deseja converter para Psi: ");
        var resposta = Console.ReadLine()!;

        if (!double.TryParse(resposta, out double libra))
        {
            return "LIBRA ou PSI inválida";
        }

        return Desafio03_ConversorPressao.Program.ConversorDePressao(libra);
    }

    private static string ExibirPecas(List<string> pecasParaRevisao)
    {
        foreach (var item in pecasParaRevisao)
        {
            Console.WriteLine($"- {item}"); ;
        }
        return "- Fim da Listagem";
    }

    private static string AdicionarPecas(List<string> pecasParaRevisao)
    {
        Console.Write("Digite a peça que deseja adicionar a listagem de revisão: ");
        string peca = Console.ReadLine()!;

        if (!pecasParaRevisao.Contains(peca))
        {
            pecasParaRevisao.Add(peca);
        }

        return "Peça adicionada com sucesso";
    }

    private static string TrocarOleo(Veiculo carro)
    {
        if (carro.PrecisaTrocarOleo())
        {
            return "Alerta: Realize a troca de óleo!";
        }

        return "Alerta: Troca de oleo em dia!";
    }

    private static string AtualizarKm(Veiculo carro)
    {
        Console.Write("Digite os Km do veiculo por gentileza: ");
        string quilometragemAtual = Console.ReadLine()!;

        if (!decimal.TryParse(quilometragemAtual, out decimal novaQuilometragem))
        {
            return "Valor inválido";
        }

        carro.AtualizaKm(novaQuilometragem);

        return "Quilometragem atualizada com sucesso";
    }

    private static string SalvarESair(Veiculo carro, string caminhoArquivo)
    {
        string jsonParaSalvar = JsonSerializer.Serialize(carro);
        File.WriteAllText(caminhoArquivo, jsonParaSalvar);

        return "Dados salvos, Saindo do sistema...";
    }
}

