using System.Text.Json.Serialization;

namespace Desafio05_POO;

// O 'method:' indica que o atributo vai para o construtor gerado
[method: JsonConstructor]
public class Carro(string modelo, decimal quilometragemAtual, decimal ultimaTrocaOleo) : IVeiculo
{
    const decimal KmTrocaCarro = 10000m;

    public string Modelo { get; set; } = modelo;
    public decimal QuilometragemAtual { get; set; } = quilometragemAtual;
    public decimal UltimaTrocaOleo { get; set; } = ultimaTrocaOleo;

    public bool PrecisaTrocarOleo()
        => (QuilometragemAtual - UltimaTrocaOleo) >= KmTrocaCarro;
 
    public void AtualizaKm(decimal novaKm)
    {
        if (novaKm > QuilometragemAtual)
        {
            QuilometragemAtual = novaKm;
        }
    }
}

