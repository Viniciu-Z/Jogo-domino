using Projeto_01;

class Program
{
    static void Main(string[] args)
    {
        JogoDomino jogo = new JogoDomino();
        List<Peca> pecas = jogo.GerarDomino();

        Console.Write("Jogador 1, digite seu nome: ");
        string nome1 = Console.ReadLine();
        Jogador j1 = new Jogador(nome1);

        Console.Write("Jogador 2, digite seu nome: ");
        string nome2 = Console.ReadLine();
        Jogador j2 = new Jogador(nome2);

        Console.Clear();

        j1.GerarMao(pecas, new Random());
        j2.GerarMao(pecas, new Random());

        Jogador atual = jogo.PrimeiroJogador(j1, j2);
        Jogador outro = (atual == j1) ? j2 : j1;
        Jogador temp;

        Console.WriteLine();

        while (true)
        {
            bool jogadaValida = false;

            while(jogadaValida is false)
            {
                Console.WriteLine("Domino: ");
                foreach (Peca p in pecas)
                {
                    Console.Write(p.Mostrar() + " ");
                }

                Console.WriteLine();
                jogo.MostrarMesa();
                Console.WriteLine();

                int i = 1;
                foreach (Peca p in atual.Mao)
                {
                    Console.Write($"{i}){p.Mostrar()} ");
                    i++;
                }

                Console.WriteLine();
                Console.Write("Escolha uma peça para jogar ou 0 para comprar/pular a vez: ");
                int escolha = int.Parse(Console.ReadLine());

                if(escolha == 0)
                {
                    Console.Clear();
                    if (pecas.Count != 0)
                    {
                        Console.WriteLine($"Jogador {atual.Nome} compra uma peça");
                        jogo.ComprarPeca(atual, pecas);
                    }
                    else
                    {
                        Console.WriteLine($"Jogador {atual.Nome} pulou a vez");
                        temp = atual;
                        atual = outro;
                        outro = temp;
                    }
                }
                else
                {
                    Peca escolhida = atual.Mao[escolha - 1];

                    Console.Write("Colocar na Esquerda (E) ou Direita (D) da mesa? ");
                    string lado = Console.ReadLine().ToUpper();

                    Console.Clear();

                    if (lado == "E")
                    {
                        int antes = jogo.EsquerdaDaMesa();
                        jogo.ColocarEsquerda(escolhida);

                        if (antes == escolhida.Lado1 || antes == escolhida.Lado2 || antes == -1)
                        {
                            atual.Mao.Remove(escolhida);
                            Console.WriteLine($"{atual.Nome} Jogou {escolhida.Mostrar()} na mesa");
                            jogadaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Peça Inválida");
                        }
                    }
                    else if (lado == "D")
                    {
                        int antes = jogo.DireitaDaMesa();
                        jogo.ColocarDireita(escolhida);

                        if (antes == escolhida.Lado1 || antes == escolhida.Lado2 || antes == -1)
                        {
                            atual.Mao.Remove(escolhida);
                            Console.WriteLine($"{atual.Nome} Jogou {escolhida.Mostrar()} na mesa");
                            jogadaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Peça Inválida");
                        }
                    }
                }
            }

            if (atual.Mao.Count == 0)
            {
                Console.WriteLine($"\n{atual.Nome} venceu o jogo!");
                break;
            }

            temp = atual;
            atual = outro;
            outro = temp;
        }
    }
}
