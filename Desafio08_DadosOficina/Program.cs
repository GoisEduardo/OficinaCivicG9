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
                Veiculo carroInicial = new("Civic G9", 120000, 110000);
                List<string> pecasIniciais = ["Filtro de Óleo", "Pastilha de Freio", "Filtro de Cabine", "Velas de Ignição"];
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
                    1 => TrocarOleo(dados.Carro),
                    2 => ConversorDePressao(),
                    3 => ExibirPecas(dados.Pecas),
                    4 => AdicionarPecas(dados.Pecas),
                    5 => AtualizarKm(dados.Carro),
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

        private static string SalvarESair(DadosOficina dados, string caminhoArquivo)
        {
            // Isso cria um JSON "bonitinho" com espaços e quebras de linha
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string jsonParaSalvar = JsonSerializer.Serialize(dados, opcoes);

            File.WriteAllText(caminhoArquivo, jsonParaSalvar);
            return "Dados salvos, Saindo do sistema...";
        }
    }
