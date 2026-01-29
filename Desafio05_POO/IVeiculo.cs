using System.Text.Json.Serialization;

namespace Desafio05_POO;

[JsonDerivedType(typeof(Carro), typeDiscriminator: "carro")]
[JsonDerivedType(typeof(Moto), typeDiscriminator: "moto")]
public interface IVeiculo
{
    string Modelo { get; set; }
    decimal QuilometragemAtual { get; set; }

    // O contrato: todo veículo deve saber dizer se precisa de troca de óleo
    bool PrecisaTrocarOleo();

    // Todo veículo deve permitir atualizar Km
    void AtualizaKm(decimal novaKm);
}

