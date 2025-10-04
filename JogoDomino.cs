namespace Projeto_01
{
    public class JogoDomino
    {
        private List<Peca> mesa;
        private Random random;  // único gerador aleatório

        public JogoDomino()
        {
            mesa = new List<Peca>();
            random = new Random();
        }

        public List<Peca> GerarDomino()
        {
            List<Peca> pecas = new List<Peca>();

            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    pecas.Add(new Peca(i, j));
                }
            }

            return pecas;
        }

        public Jogador PrimeiroJogador(Jogador j1, Jogador j2)
        {
            // mesma lógica que você já fez (estava correta)
            Peca duplaJ1 = null;
            Peca duplaJ2 = null;

            foreach (Peca p in j1.Mao)
                if (p.Lado1 == p.Lado2 && (duplaJ1 == null || p.Lado1 > duplaJ1.Lado1))
                    duplaJ1 = p;

            foreach (Peca p in j2.Mao)
                if (p.Lado1 == p.Lado2 && (duplaJ2 == null || p.Lado1 > duplaJ2.Lado1))
                    duplaJ2 = p;

            if (duplaJ1 != null && duplaJ2 != null)
                return (duplaJ1.Lado1 >= duplaJ2.Lado1) ? j1 : j2;
            if (duplaJ1 != null) return j1;
            if (duplaJ2 != null) return j2;

            // caso não tenha dupla, quem tem a maior soma
            Peca maiorJ1 = j1.Mao.OrderByDescending(p => p.Lado1 + p.Lado2).First();
            Peca maiorJ2 = j2.Mao.OrderByDescending(p => p.Lado1 + p.Lado2).First();

            return (maiorJ1.Lado1 + maiorJ1.Lado2 >= maiorJ2.Lado1 + maiorJ2.Lado2) ? j1 : j2;
        }

        public void MostrarMesa()
        {
            Console.Write("Mesa: ");
            foreach (var p in mesa)
            {
                Console.Write(p.Mostrar() + " ");
            }
            Console.WriteLine();
        }

        public int EsquerdaDaMesa() => mesa.Count == 0 ? -1 : mesa.First().Lado1;
        public int DireitaDaMesa() => mesa.Count == 0 ? -1 : mesa.Last().Lado2;

        public bool ColocarEsquerda(Peca p)
        {
            if (mesa.Count == 0)
            {
                mesa.Add(p);
                return true;
            }

            int valorE = EsquerdaDaMesa();

            if (p.Lado2 == valorE)
            {
                mesa.Insert(0, p);
                return true;
            }
            else if (p.Lado1 == valorE)
            {
                mesa.Insert(0, p.Virar());
                return true;
            }

            return false;
        }

        public bool ColocarDireita(Peca p)
        {
            if (mesa.Count == 0)
            {
                mesa.Add(p);
                return true;
            }

            int valorD = DireitaDaMesa();

            if (p.Lado1 == valorD)
            {
                mesa.Add(p);
                return true;
            }
            else if (p.Lado2 == valorD)
            {
                mesa.Add(p.Virar());
                return true;
            }

            return false;
        }

        public void ComprarPeca(Jogador jogador, List<Peca> pecas)
        {
            int index = random.Next(pecas.Count);
            Peca peca = pecas[index];
            jogador.Mao.Add(peca);
            pecas.RemoveAt(index);
        }
    }
}
