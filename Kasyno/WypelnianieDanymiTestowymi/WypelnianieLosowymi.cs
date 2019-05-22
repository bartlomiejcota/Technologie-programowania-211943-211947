using System;
using Kasyno;

namespace WypelnianieDanymiTestowymi
{
    public class WypelnianieLosowymi : IWypelnianieDanymi // WypelnianieLosowymi
    {
        private int IloscGraczy;
        private int IloscGier;
        private int IloscRozegranychGier;
        private int IloscZdarzen;

        public WypelnianieLosowymi(int iloscGraczy, int iloscGier, int iloscRozegranychGier, int iloscZdarzen)
        {
            IloscGraczy = iloscGraczy;
            IloscGier = iloscGier;
            IloscRozegranychGier = iloscRozegranychGier;
            IloscZdarzen = iloscZdarzen;
        }

        public void WypelnijDanymi(ref DataContext context)
        {
            // Dodawanie graczy
            for (int i = 0; i < IloscGraczy; i++)
            {
                int idGracza = i;
                string imie = string.Concat("Gracz", i);
                string nazwisko = string.Concat("Graczowski", i);
                DateTime dataUrodzin = new DateTime(1950 + i % 50, i % 11 + 1, i % 28 + 1);

                context.ListaGraczy.Add(new Gracz(idGracza, imie, nazwisko, dataUrodzin));
            }

            // Dodawanie gier
            for (int i = 0; i < IloscGier; i++)
            {
                int idGry = i;
                string nazwaGry = string.Concat("Gra", i);
                string informacjeOGrze = string.Concat("Opis o grze ", i);

                context.ListaGier.Add(i, new Gra(idGry, nazwaGry, informacjeOGrze));
            }

            // Dodawanie rozegranych gier
            for (int i = 0; i < IloscRozegranychGier; i++)
            {
                int idRozegranejGry = i;
                Gra gra = context.ListaGier[i % context.ListaGier.Count + 1];
                DateTime czasRozpoczeciaGry = new DateTime(1950 + i % 50, i % 12 + 1, i % 28 + 1);
                TimeSpan czasTrwaniaGry = new TimeSpan(i % 24, i % 60, i % 59 + 1);
                double oplataWejsciowa = i;
                double minimalnyDepozyt = i;

                context.ListaRozegranychGier.Add(new RozegranaGra(idRozegranejGry, gra, czasRozpoczeciaGry, czasTrwaniaGry, oplataWejsciowa, minimalnyDepozyt));
            }

            // Dodawanie Zdarzeń
            for (int i = 0; i < IloscZdarzen; i++)
            {
                Gracz uczestnikGry = context.ListaGraczy[i % context.ListaGraczy.Count + 1];
                RozegranaGra ukonczonaGra = context.ListaRozegranychGier[i % context.ListaRozegranychGier.Count + 1];
                DateTime czasRozpoczeciaGry = context.ListaRozegranychGier[i % context.ListaRozegranychGier.Count + 1].CzasRozpoczeciaGry;
                TimeSpan czasTrwaniaGry = context.ListaRozegranychGier[i % context.ListaRozegranychGier.Count + 1].CzasTrwaniaGry;
                double wygrana = i % 1000.00;

                context.ListaZdarzen.Add(new Zdarzenie(uczestnikGry, ukonczonaGra, czasRozpoczeciaGry, czasTrwaniaGry, wygrana));
            }
        }
    }
}