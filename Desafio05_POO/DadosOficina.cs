namespace Desafio05_POO;

public class DadosOficina
{
    public Veiculo Carro { get; set; }
    public List<string> Pecas { get; set; }

    public DadosOficina()
    { 
    }

    public DadosOficina(Veiculo carro, List<string> pecas)
    {
        Carro = carro;
        Pecas = pecas;
    }
}

