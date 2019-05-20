namespace Kasyno
{
    public class Gra // Wykaz
    {
        public int IdGry { get;  }
        public string NazwaGry { get; set; }
        public string InformacjeOGrze { get; set; }

        public Gra(int idGry, string nazwaGry, string informacjeOGrze)
        {
            IdGry = idGry;
            NazwaGry = nazwaGry;
            InformacjeOGrze = informacjeOGrze;
        }

        public override string ToString()
        {
            return $"{IdGry}, {NazwaGry}, {InformacjeOGrze}";
        }
    }
}