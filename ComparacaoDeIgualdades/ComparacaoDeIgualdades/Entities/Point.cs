

namespace ComparacaoDeIgualdades.Entities
{
    struct Point //não é classe struct é do tipo valor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
