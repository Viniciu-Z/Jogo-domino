using Projeto_01;


class Program
{
    static void Main(string[] args)
    {
        JogoDomino jogo = new JogoDomino();
        List<Peca> pecas = jogo.GerarDomino();

        Jogador j1 = new Jogador("Vinicius");
        Jogador j2 = new Jogador("Terezinho");

        j1.gerarMao(pecas);
        j2.gerarMao(pecas);

        j1.mostrarMao();
        j2.mostrarMao();


        Console.WriteLine("Domino: ");
        foreach (Peca p in pecas)
        {
            Console.Write(p.Mostrar() + " ");
        }
    }
}
