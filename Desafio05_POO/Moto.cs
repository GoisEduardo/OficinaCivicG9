using System.Text.Json.Serialization;

namespace Desafio05_POO;

[method: JsonConstructor]
public class Moto(string modelo, decimal quilometragemAtual, decimal ultimaTrocaDeOleo) : IVeiculo
{
    // Regra da moto é mais rigorosa
    private const decimal KmTrocaMoto = 3000m;

    public string Modelo { get; set; } = modelo;
    public decimal QuilometragemAtual { get; set; } = quilometragemAtual;
    public decimal UltimaTrocaDeOleo { get; set; } = ultimaTrocaDeOleo;

    public void AtualizaKm(decimal novaKm)
    {
        if(novaKm > QuilometragemAtual)
        {
            QuilometragemAtual = novaKm;
        }
    }

    public bool PrecisaTrocarOleo()
        => (QuilometragemAtual - UltimaTrocaDeOleo) >= KmTrocaMoto;
}

