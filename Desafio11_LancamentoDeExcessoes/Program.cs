using Desafio05_POO;
using System.Text.Json;

namespace Desafio11_LancamentoDeExcessoes;

public class Program
{
    public static void Main(string[] args)
    {
        string caminhoArquivo = "oficina.json";
        DadosOficina dados;

        if (File.Exists(caminhoArquivo))
        {
            try
            {
                string jsonRecuparado = File.ReadAllText(caminhoArquivo);
                dados = JsonSerializer.Deserialize<DadosOficina>(jsonRecuparado)!;
            }
            catch (JsonException ex)
            {
                Console.WriteLine("⚠️ Erro: O arquivo de dados está corrompido. Iniciando com dados padrão.");
                dados = CriarDadosIniciais(); // Método auxiliar para não repetir código
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Erro inesperado ao carregar dados: {ex.Message}");
                dados = CriarDadosIniciais();
            }
            finally
            {
                Console.WriteLine(">>> Inicialização do sistema concluída.");
            }
        }
        else
        {
            dados = CriarDadosIniciais();
        }

        IVeiculo veiculoFocado = dados.Veiculos[0];

        int escolha;

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
                1 => TrocarOleo(veiculoFocado),
                2 => ConversorDePressao(),
                3 => ExibirPecas(dados.Pecas),
                4 => AdicionarPecas(dados.Pecas),
                5 => AtualizarKm(veiculoFocado),
                6 => FiltrarPorMarca(dados.Pecas),
                7 => MenuSelecaoVeiculo(dados.Veiculos, out veiculoFocado), // Usando 'out' para atualizar a variável
                8 => SalvarESair(dados, caminhoArquivo),
                9 => ExibirMetrica(dados.Pecas),
                _ => "Opção não reconhecida pelo sistema."
            };

            Console.WriteLine(servico);

            if (escolha != 8)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
            }

        } while (escolha != 8); // O loop para quando escolha for 3
    }

    private static DadosOficina CriarDadosIniciais()
    {
        List<IVeiculo> veiculosIniciais =
        [
            new Carro("Civic G9", 120000, 110000),
            new Carro("Civic G8", 150000, 100000),
            new Moto("CB 500", 10000, 9000)
        ];

        List<Peca> pecasIniciais =
        [
            new Peca("Filtro de Óleo", "Cofap", 19.90m),
            new Peca("Pastilha de Freio", "Bosch", 150.00m),
            new Peca("Amortecedor", "Monroe", 450.00m)
        ];

        return new DadosOficina(veiculosIniciais, pecasIniciais);
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
        Console.WriteLine("6 - Filtrar por Marca.");
        Console.WriteLine("7 - Selecionar Veículo.");
        Console.WriteLine("8 - Sair \n");
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

    private static string TrocarOleo(IVeiculo carro)
    {
        if (carro.PrecisaTrocarOleo())
        {
            return "Alerta: Realize a troca de óleo!";
        }

        return "Alerta: Troca de oleo em dia!";
    }

    private static string AtualizarKm(IVeiculo carro)
    {
        try
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
        catch (KmInvalidaException ex)
        {
            return $"Erro de negócio: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Erro inesperado: {ex.Message}";
        }
    }

    private static string SalvarESair(DadosOficina dados, string caminhoArquivo)
    {
        // Isso cria um JSON "bonitinho" com espaços e quebras de linha
        var opcoes = new JsonSerializerOptions { WriteIndented = true };
        string jsonParaSalvar = JsonSerializer.Serialize(dados, opcoes);

        File.WriteAllText(caminhoArquivo, jsonParaSalvar);
        return "Dados salvos, Saindo do sistema...";
    }

    private static string FiltrarPorMarca(List<Peca> pecas)
    {
        Console.Write("Qual marca deseja pesquisar: ");
        string marca = Console.ReadLine()!;

        IEnumerable<Peca> itensPorMarca = pecas.Where(x => x.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase));

        foreach (var item in itensPorMarca)
        {
            Console.WriteLine($"- {item.Nome,-20} | {item.Marca,-10} | {item.Valor:C2}");
        }

        return "Peças filtradas com sucesso";
    }

    private static string ExibirMetrica(List<Peca> pecas)
    {
        if (!pecas.Any())
        {
            return "Nenhuma peça cadastrada para gerar métricas";
        }

        decimal total = pecas.Sum(x => x.Valor);
        decimal quantidade = pecas.Count;

        //Aqui pegamos o objeto inteiro que tem o valor máximo
        Peca pecaMaisCara = pecas.OrderByDescending(x => x.Valor).First();

        Console.WriteLine("======= ESTATÍSTICAS DA OFICINA =======");
        Console.WriteLine($"Total investido: {total:C2}");
        Console.WriteLine($"Qtd. de itens:   {quantidade}");
        Console.WriteLine($"Item de luxo:    {pecaMaisCara.Nome} ({pecaMaisCara.Valor:C2})");
        Console.WriteLine("=======================================\n");

        return "Relatório gerado com sucesso.";
    }

    private static string MenuSelecaoVeiculo(List<IVeiculo> veiculos, out IVeiculo veiculoFocado)
    {
        Console.WriteLine("--- Garagem Disponível ---");
        for (int i = 0; i < veiculos.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {veiculos[i].Modelo} ({veiculos[i].GetType().Name})");
        }

        Console.Write("\nSelecione o número do veículo: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= veiculos.Count)
        {
            veiculoFocado = veiculos[index - 1]; // Atualiza a variável do Main
            return $"Sucesso: Você agora está gerenciando o {veiculoFocado.Modelo}.";
        }

        veiculoFocado = veiculos[0]; // Fallback caso o usuário erre
        return "Seleção inválida. Mantendo veículo anterior.";
    }
}
