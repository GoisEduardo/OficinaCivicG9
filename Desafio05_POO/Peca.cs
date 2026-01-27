using System.Text.Json.Serialization;

namespace Desafio05_POO;

[method: JsonConstructor]
public class Peca(string nome, string marca, decimal valor)
{
    public string Nome { get; set; } = nome;
    public string Marca { get; set; } = marca;
    public decimal Valor { get; set; } = valor;

    public override string ToString()
        => $"{Nome.PadRight(20)} | Marca: {Marca.PadRight(10)} | Preço: {Valor:C2}"; 
}

