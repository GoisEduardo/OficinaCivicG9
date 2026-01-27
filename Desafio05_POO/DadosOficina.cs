namespace Desafio05_POO;

public class DadosOficina
{
    public Veiculo Carro { get; set; }
    public List<Peca> Pecas { get; set; }

    public DadosOficina()
    { 
    }

    public DadosOficina(Veiculo carro, List<Peca> pecas)
    {
        Carro = carro;
        Pecas = pecas;
    }
}

