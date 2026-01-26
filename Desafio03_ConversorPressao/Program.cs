namespace Desafio03_ConversorPressao;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite quantos PSI ou LIBRAS deseja converter: ");
        string valorRecebido = Console.ReadLine()!;

        if (!double.TryParse(valorRecebido, out double libra))
        {
            Console.WriteLine("LIBRA ou PSI inválida");
            return;
        }

        Console.WriteLine(ConversorDePressao(libra));
    }

    public static string ConversorDePressao(double libra)
    {
        double bar =  libra * 0.068947;
        return $"A conversão de PSI para BAR é {bar:N2}"; 
    }
}

