using System;

namespace Kasyno
{
    public class Zdarzenie // Zdarzenie
    {
        public Gracz UczestnikGry { get; set; }
        public RozegranaGra UkonczonaGra { get; set; }
        public DateTime CzasRozpoczeciaGry { get; set; }
        public TimeSpan CzasTrwaniaGry { get; set; }
        public double Wygrana { get; set; }

        public Zdarzenie(Gracz uczestnikGry, RozegranaGra ukonczonaGra, DateTime czasRozpoczeciaGry, TimeSpan czasTrwaniaGry, double wygrana)
        {
            UczestnikGry = uczestnikGry;
            UkonczonaGra = ukonczonaGra;
            CzasRozpoczeciaGry = czasRozpoczeciaGry;
            CzasTrwaniaGry = czasTrwaniaGry;
            Wygrana = wygrana;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}