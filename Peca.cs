namespace Projeto_01
{
    public class Peca
    {
        public int Lado1 { get; }
        public int Lado2 { get; }

        public Peca(int lado1, int lado2)
        {
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public string Mostrar()
        {
            return $"[{Lado1}|{Lado2}]";
        }

        public Peca Virar()
        {
            return new Peca(Lado2, Lado1);
        }
    }
}
