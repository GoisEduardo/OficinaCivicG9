namespace Desafio05_ListasDePecas
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> pecasParaRevisao = ["Filtro de Óleo", "Pastilha de Freio", "Filtro de Cabine", "Velas de Ingnição"];
            var teste = ExibirPecas(pecasParaRevisao);
        }

        private static string ExibirPecas(List<string> pecasParaRevisao)
        {
            foreach (var item in pecasParaRevisao)
            {
                Console.WriteLine($"- {item}");
            }

            return "Fim da Listagem";
        }
    }
}
