using Projeto_01;


class Program
{
    static void Main(string[] args)
    {
        JogoDomino jogo = new JogoDomino();
        List<Peca> pecas = jogo.GerarDomino();

        Jogador j1 = new Jogador("Vinicius");
        Jogador j2 = new Jogador("Terezinho");

        j1.GerarMao(pecas);
        j2.GerarMao(pecas);

        j1.MostrarMao();
        j2.MostrarMao();

        Console.WriteLine();

        jogo.PrimeiroJogador(j1, j2);

        Console.WriteLine("Domino: ");
        foreach (Peca p in pecas)
        {
            Console.Write(p.Mostrar() + " ");
        }
    }
}
