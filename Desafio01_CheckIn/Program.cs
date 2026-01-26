namespace Desafio01_CheckIn;

public class Program
{
    static void Main(string[] args)
    {
        string modelo = "Civic G9";
        int ano = 2015;
        double quilometragem = 120000.50;
        bool isLuzInjecaoAcesa = false; // Usar 'is' para bool é uma boa prática
        string statusInjecao = isLuzInjecaoAcesa ? "Acessa" : "Apagada";

        Console.WriteLine($"O modelo do carro: {modelo}, ano: {ano}, Km: {quilometragem: N2} e está com a luz da injeção: {statusInjecao}");
        Console.ReadKey();
    }
}

