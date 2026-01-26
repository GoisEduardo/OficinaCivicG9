namespace Desafio02_CalculadoraPecas;

public class Program
{
    static void Main(string[] args)
    {
        const decimal ValorDireitoDesconto = 1000m;
        const decimal PorcentagemDesconto = 0.10m;

        Console.Write("Caro cliente quantos amortecedores gostaria de comprar: ");
        string valores = Console.ReadLine()!;

        if (!int.TryParse(valores, out int quantidade))
        {
            Console.WriteLine("Quantidade inválida!");
            return;
        }

        decimal precoUnitario = 430.76m;

        Console.Write($"\nO preço de cada unidade está {precoUnitario:C}\n");

        decimal valorTotal = quantidade * precoUnitario;

        //if (valorTotal > ValorDireitoDesconto)
        //{
        //    valorTotal -= (valorTotal * PorcentagemDesconto);
        //    Console.WriteLine($"Valor com o desconto de 10% é: {valorTotal:C}");
        //}
        //else
        //{
        //    Console.WriteLine($"Valor é: {valorTotal:C}");
        //}

        //decimal valorFinal = valorTotal > ValorDireitoDesconto 
        //    ? valorTotal - (valorTotal * PorcentagemDesconto)
        //    : valorTotal;

        decimal valorFinal = valorTotal switch
        {
            > ValorDireitoDesconto => valorTotal - (valorTotal * PorcentagemDesconto), // Se for > 1000 aplica desconto
            _ => valorTotal // padrão (else), no caso aqui retorna o valor cheio
        };

        Console.WriteLine($"Valor é: {valorFinal:C}");
    }
}

