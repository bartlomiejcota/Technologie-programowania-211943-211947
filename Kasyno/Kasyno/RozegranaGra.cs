using System;

namespace Kasyno
{
    public class RozegranaGra //Opis stanu
    {
        public int IdRozegranejGry { get; set; }
        public Gra Gra { get; set; }
        public DateTime CzasRozpoczeciaGry { get; set; }
        public TimeSpan CzasTrwaniaGry { get; set; }
        public double OplataWejsciowa { get; set; }
        public double MinimalnyDepozyt { get; set; }

        public RozegranaGra(int idRozegranejGry, Gra gra, DateTime czasRozpoczeciaGry, TimeSpan czasTrwaniaGry, double oplataWejsciowa, double minimalnyDepozyt)
        {
            IdRozegranejGry = idRozegranejGry;
            Gra = gra;
            CzasRozpoczeciaGry = czasRozpoczeciaGry;
            CzasTrwaniaGry = czasTrwaniaGry;
            OplataWejsciowa = oplataWejsciowa;
            MinimalnyDepozyt = minimalnyDepozyt;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}