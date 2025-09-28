namespace Projeto_01;
public class Jogador
{
    public string Nome { get; private set; }
    public List<Peca> Mao { get; private set; }

    public Jogador(string nome)
    {
        this.Nome = nome;
        this.Mao = new List<Peca>();
    }

    public void GerarMao(List<Peca> pecas)
    {
        Random random = new Random();

        for(int i = 0; i < 7; i++)
        {
            int index = random.Next(pecas.Count);
            Peca peca = pecas[index];
            Mao.Add(peca);
            pecas.Remove(peca);

        }

    }

    public void MostrarMao()
    {
        Console.WriteLine($"Jogador {Nome}");
        foreach (Peca peca in Mao)
        {
            Console.Write(peca.Mostrar() + " ");
        }
        Console.WriteLine();
    }
}
