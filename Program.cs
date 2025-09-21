using Projeto_01;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        JogoDomino jogo = new JogoDomino();

        List<Peca> pecas = jogo.GerarDomino();

        foreach (Peca p in pecas)
        {
            Console.WriteLine(p.Mostrar());
        }
    }
}
