namespace Projeto_01
{
    public class JogoDomino
    {
        private List<Peca> mesa;

        public JogoDomino()
        {
            mesa = new List<Peca>();
        }

        // Gera as 28 peças do dominó
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

        // Decide quem é o primeiro jogador
        public Jogador PrimeiroJogador(Jogador j1, Jogador j2)
        {
            Peca MaiorDuplaJ1 = null;
            Peca MaiorDuplaJ2 = null;

            foreach (Peca peca in j1.Mao)
            {
                if (peca.Lado1 == peca.Lado2)
                {
                    if (MaiorDuplaJ1 == null || peca.Lado1 > MaiorDuplaJ1.Lado1)
                    {
                        MaiorDuplaJ1 = peca;
                    }
                }
            }

            foreach (Peca peca in j2.Mao)
            {
                if (peca.Lado1 == peca.Lado2)
                {
                    if (MaiorDuplaJ2 == null || peca.Lado1 > MaiorDuplaJ2.Lado1)
                    {
                        MaiorDuplaJ2 = peca;
                    }
                }
            }

            if (MaiorDuplaJ1 != null && MaiorDuplaJ2 != null)
            {
                if (MaiorDuplaJ1.Lado1 >= MaiorDuplaJ2.Lado1)
                {
                    Console.WriteLine($"{j1.Nome} começa porque tem a maior dupla: {MaiorDuplaJ1.Mostrar()}");
                    return j1;
                }
                else
                {
                    Console.WriteLine($"{j2.Nome} começa porque tem a maior dupla: {MaiorDuplaJ2.Mostrar()}");
                    return j2;
                }
            }

            if (MaiorDuplaJ1 != null)
            {
                Console.WriteLine($"{j1.Nome} começa porque possui a dupla {MaiorDuplaJ1.Mostrar()}");
                return j1;
            }

            if (MaiorDuplaJ2 != null)
            {
                Console.WriteLine($"{j2.Nome} começa porque possui a dupla {MaiorDuplaJ2.Mostrar()}");
                return j2;
            }

            // Nenhuma dupla -> decide pela maior soma
            Peca PecaMaiorj1 = null;
            int somaPecaj1 = -1;

            foreach (Peca peca in j1.Mao)
            {
                int soma = peca.Lado1 + peca.Lado2;
                if (soma > somaPecaj1)
                {
                    somaPecaj1 = soma;
                    PecaMaiorj1 = peca;
                }
            }

            Peca PecaMaiorj2 = null;
            int somaPecaj2 = -1;

            foreach (Peca peca in j2.Mao)
            {
                int soma = peca.Lado1 + peca.Lado2;
                if (soma > somaPecaj2)
                {
                    somaPecaj2 = soma;
                    PecaMaiorj2 = peca;
                }
            }

            if (somaPecaj1 >= somaPecaj2)
            {
                Console.WriteLine($"{j1.Nome} começa porque tem a peça de maior soma: {PecaMaiorj1.Mostrar()} (soma = {somaPecaj1})");
                return j1;
            }
            else
            {
                Console.WriteLine($"{j2.Nome} começa porque tem a peça de maior soma: {PecaMaiorj2.Mostrar()} (soma = {somaPecaj2})");
                return j2;
            }
        }

        // Mostrar a mesa
        public void MostrarMesa()
        {
            Console.Write("Mesa: ");
            foreach (var peca in mesa)
            {
                Console.Write(peca.Mostrar() + " ");
            }
            Console.WriteLine();
        }

        // Valor da esquerda
        public int EsquerdaDaMesa()
        {
            return mesa.Count == 0 ? -1 : mesa.First().Lado1;
        }

        // Valor da direita
        public int DireitaDaMesa()
        {
            return mesa.Count == 0 ? -1 : mesa.Last().Lado2;
        }

        // Colocar peça à esquerda
        public void ColocarEsquerda(Peca peca)
        {
            if (mesa.Count == 0)
            {
                mesa.Add(peca);
                return;
            }

            int valorEsquerda = EsquerdaDaMesa();

            if (peca.Lado1 == valorEsquerda)
            {
                mesa.Insert(0, new Peca(peca.Lado2, peca.Lado1));
            }
            else if (peca.Lado2 == valorEsquerda)
            {
                mesa.Insert(0, peca);
            }
        }

        // Colocar peça à direita
        public void ColocarDireita(Peca peca)
        {
            if (mesa.Count == 0)
            {
                mesa.Add(peca);
                return;
            }

            int valorDireita = DireitaDaMesa();

            if (peca.Lado1 == valorDireita)
            {
                mesa.Add(peca);
            }
            else if (peca.Lado2 == valorDireita)
            {
                mesa.Add(new Peca(peca.Lado2, peca.Lado1));
            }
        }
    }
}
