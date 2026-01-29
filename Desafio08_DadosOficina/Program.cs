using Desafio05_POO;
using System.Text.Json;

namespace Desafio08_DadosOficina;

public class Program
{
    public static void Main(string[] args)
    {
        string caminhoArquivo = "oficina.json";
        DadosOficina dados;

        if (File.Exists(caminhoArquivo))
        {
            string jsonRecuparado = File.ReadAllText(caminhoArquivo);
            dados = JsonSerializer.Deserialize<DadosOficina>(jsonRecuparado)!;
        }
        else
        {
            Carro carroInicial = new("Civic G9", 120000, 110000);
            List<Peca> pecasIniciais = new List<Peca>
            {
                new Peca("Filtro de Óleo", "Cofap", 19.90m),
                new Peca("Pastilha de Freio", "Bosch", 150.00m),
                new Peca("Amortecedor", "Monroe", 450.00m)

            };

            dados = new DadosOficina(carroInicial, pecasIniciais);
        }

        int escolha = 0;

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
                1 => TrocarOleo(dados.Veiculos),
                2 => ConversorDePressao(),
                3 => ExibirPecas(dados.Pecas),
                4 => AdicionarPecas(dados.Pecas),
                5 => AtualizarKm(dados.Veiculos),
                6 => SalvarESair(dados, caminhoArquivo),
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

    private static string ExibirPecas(List<Peca> pecasParaRevisao)
    {
        foreach (var item in pecasParaRevisao)
        {
            // O :C2 formata automaticamente para moeda (R$ 19,90)
            // O {0,-20} reserva 20 espaços à esquerda para o nome ficar alinhado
            Console.WriteLine($"- {item.Nome,-20} | {item.Marca,-10} | {item.Valor:C2}");
        }
        return $"\n- Fim da Listagem";
    }

    private static string AdicionarPecas(List<Peca> pecasParaRevisao)
    {
        Console.Write("Nome da peça: ");
        string nome = Console.ReadLine()!;

        Console.Write("Marca: ");
        string marca = Console.ReadLine()!;

        Console.Write("Valor: ");
        decimal.TryParse(Console.ReadLine(), out decimal valor);

        pecasParaRevisao.Add(new Peca(nome, marca, valor));

        return "Peça adicionada com sucesso ao inventário";
    }

    private static string TrocarOleo(Carro carro)
    {
        if (carro.PrecisaTrocarOleo())
        {
            return "Alerta: Realize a troca de óleo!";
        }

        return "Alerta: Troca de oleo em dia!";
    }

    private static string AtualizarKm(Carro carro)
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

    private static string SalvarESair(DadosOficina dados, string caminhoArquivo)
    {
        // Isso cria um JSON "bonitinho" com espaços e quebras de linha
        var opcoes = new JsonSerializerOptions { WriteIndented = true };
        string jsonParaSalvar = JsonSerializer.Serialize(dados, opcoes);

        File.WriteAllText(caminhoArquivo, jsonParaSalvar);
        return "Dados salvos, Saindo do sistema...";
    }
}
