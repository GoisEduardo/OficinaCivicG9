namespace Desafio05_POO;

public class DadosOficina
{
    public List<IVeiculo> Veiculos { get; set; }
    public List<Peca> Pecas { get; set; }

    public DadosOficina()
    { 
    }

    public DadosOficina(List<IVeiculo> veiculos, List<Peca> pecas)
    {
        Veiculos = veiculos;
        Pecas = pecas;
    }
}

