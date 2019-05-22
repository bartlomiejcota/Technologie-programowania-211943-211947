using System;

namespace Kasyno
{
    public class Gracz //Wykaz
    {
        public int IdGracza { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set;}
        public DateTime DataUrodzin { get; set; }

        public Gracz(int idGracza, string imie, string nazwisko, DateTime dataUrodzin)
        {
            IdGracza = idGracza;
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzin = dataUrodzin;
        }

        public override string ToString()
        {
            return $"{IdGracza}, {Imie}, {Nazwisko}, {DataUrodzin.ToString("dd/mm/yyyy")}";
        }
    }
}