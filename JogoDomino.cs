using System.Collections.Generic;

namespace Projeto_01
{
    public class JogoDomino
    {
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

    }
}
